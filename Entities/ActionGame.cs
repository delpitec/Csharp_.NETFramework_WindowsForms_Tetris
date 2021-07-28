using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Entities.Enums;
using Tetris.Entities.BackEnd;
using Tetris.Forms;


namespace Tetris.Entities
{
    public class ActionGame
    {
        public Position StartPiecePosition { get; private set; }
        public Position CurrentPiecePositionOnGameBoard { get; private set; }
        public Piece CurrentPieceOnGameboard { get; private set; }
        public Piece NextPieceOnGameboard { get; private set; }

        public ActionGame()
        {
            StartPiecePosition = new Position();
            CurrentPiecePositionOnGameBoard = new Position();
            CurrentPieceOnGameboard = null;

            // store initial position defined as default (0,1) -> Position() constructor 
            StartPiecePosition.Row = CurrentPiecePositionOnGameBoard.Row;
            StartPiecePosition.Column = CurrentPiecePositionOnGameBoard.Column;
        }

        public ActionGame(int startCurrentPiecePositionRow, int startCurrentPiecePositionColumn)
        {
            StartPiecePosition = new Position(startCurrentPiecePositionRow, startCurrentPiecePositionColumn);
            CurrentPiecePositionOnGameBoard = new Position(startCurrentPiecePositionRow, startCurrentPiecePositionColumn);
            CurrentPieceOnGameboard = null;

            // store initial position defined at ActionGame constructor parameters
            StartPiecePosition.Row = CurrentPiecePositionOnGameBoard.Row;
            StartPiecePosition.Column = CurrentPiecePositionOnGameBoard.Column;
        }

        // Add randon piece
        public MachineStateName AddNewPiece(BackBoardGame backBoardGame)
        {
            // Set the initial position to defined positions on CurrentPiecePositionOnGameBoard
            CurrentPiecePositionOnGameBoard.Row = StartPiecePosition.Row;
            CurrentPiecePositionOnGameBoard.Column = StartPiecePosition.Column;




            ElementID[] PiecetoBeSortedByRandom = new ElementID[] { ElementID.JBlock,
                                                                    ElementID.TBlock,
                                                                    ElementID.LBlock,
                                                                    ElementID.IBlock,
                                                                    ElementID.OBlock,
                                                                    ElementID.SBlock,
                                                                    ElementID.ZBlock
            };

            Random rnd = new Random();
            if (CurrentPieceOnGameboard == null)
            {
                CurrentPieceOnGameboard = new Piece(PiecetoBeSortedByRandom[rnd.Next((int)ElementID.ZBlock + 1)]);
                NextPieceOnGameboard = new Piece(PiecetoBeSortedByRandom[rnd.Next((int)ElementID.ZBlock + 1)]);
            }
            else
            {
                CurrentPieceOnGameboard = NextPieceOnGameboard;
                NextPieceOnGameboard = new Piece(PiecetoBeSortedByRandom[rnd.Next((int)ElementID.ZBlock + 1)]);
            }


            // Design Piece on Next Piece Grid (backEnd)
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 4; i++)
                    backBoardGame.NextPieceMatrix[j, i] = ElementID.NextPieceGrid;
            }
            for (int PiecePixel = 0; PiecePixel < 4; PiecePixel++)
            {
                backBoardGame.NextPieceMatrix[NextPieceOnGameboard.PixelVector[PiecePixel].Row + 1, NextPieceOnGameboard.PixelVector[PiecePixel].Column + 1] = NextPieceOnGameboard.id;
            }


            // If next position is free so design Piece on Boardgame (backEnd)
            if (NextPositionIsFree(backBoardGame, MovementName.Down))
            {
                // Design Piece on Boardgame (backEnd)
                for (int PiecePixel = 0; PiecePixel < 4; PiecePixel++)
                {
                    backBoardGame.Matrix[StartPiecePosition.Row + CurrentPieceOnGameboard.PixelVector[PiecePixel].Row, StartPiecePosition.Column + CurrentPieceOnGameboard.PixelVector[PiecePixel].Column] = CurrentPieceOnGameboard.id;
                }

                return MachineStateName.Move; ;
            }
            else
            {
                Console.WriteLine("GAME OVER");
                return MachineStateName.GameOver;
            }
        }

        // Add Specified piece
        public void AddNewPiece(BackBoardGame backBoardGame, ElementID pieceId)
        {
            CurrentPieceOnGameboard = new Piece(pieceId);

            // Set the initial position to defined positions on CurrentPiecePositionOnGameBoard
            CurrentPiecePositionOnGameBoard.Row = StartPiecePosition.Row;
            CurrentPiecePositionOnGameBoard.Column = StartPiecePosition.Column;

            // Design Piece on Boardgame (backEnd)
            for (int PiecePixel = 0; PiecePixel < 4; PiecePixel++)
            {
                backBoardGame.Matrix[StartPiecePosition.Row + CurrentPieceOnGameboard.PixelVector[PiecePixel].Row, StartPiecePosition.Column + CurrentPieceOnGameboard.PixelVector[PiecePixel].Column] = CurrentPieceOnGameboard.id;
            }
        }

        public MachineStateName MovePiece(BackBoardGame backBoardGame, MovementName movement)
        {
            if (movement == MovementName.Down)
            {
                if (NextPositionIsFree(backBoardGame, movement))
                {
                    // Clean current Position
                    for (int PiecePixel = 0; PiecePixel < 4; PiecePixel++)
                    {
                        backBoardGame.Matrix[CurrentPiecePositionOnGameBoard.Row + CurrentPieceOnGameboard.PixelVector[PiecePixel].Row, CurrentPiecePositionOnGameBoard.Column + CurrentPieceOnGameboard.PixelVector[PiecePixel].Column] = ElementID.Free;
                    }

                    CurrentPiecePositionOnGameBoard.Row++;

                    for (int PiecePixel = 0; PiecePixel < 4; PiecePixel++)
                    {
                        backBoardGame.Matrix[CurrentPiecePositionOnGameBoard.Row + CurrentPieceOnGameboard.PixelVector[PiecePixel].Row, CurrentPiecePositionOnGameBoard.Column + CurrentPieceOnGameboard.PixelVector[PiecePixel].Column] = CurrentPieceOnGameboard.id;
                    }
                }
                else
                {
                    return MachineStateName.TiePiece;
                }
            }
            else if (movement == MovementName.Left)
            {
                if (NextPositionIsFree(backBoardGame, movement))
                {
                    // Clean current Position
                    for (int PiecePixel = 0; PiecePixel < 4; PiecePixel++)
                    {
                        backBoardGame.Matrix[CurrentPiecePositionOnGameBoard.Row + CurrentPieceOnGameboard.PixelVector[PiecePixel].Row, CurrentPiecePositionOnGameBoard.Column + CurrentPieceOnGameboard.PixelVector[PiecePixel].Column] = ElementID.Free;
                    }

                    CurrentPiecePositionOnGameBoard.Column--;

                    for (int PiecePixel = 0; PiecePixel < 4; PiecePixel++)
                    {
                        backBoardGame.Matrix[CurrentPiecePositionOnGameBoard.Row + CurrentPieceOnGameboard.PixelVector[PiecePixel].Row, CurrentPiecePositionOnGameBoard.Column + CurrentPieceOnGameboard.PixelVector[PiecePixel].Column] = CurrentPieceOnGameboard.id;
                    }
                }
            }
            else if (movement == MovementName.Right)
            {
                if (NextPositionIsFree(backBoardGame, movement))
                {
                    // Clean current Position
                    for (int PiecePixel = 0; PiecePixel < 4; PiecePixel++)
                    {
                        backBoardGame.Matrix[CurrentPiecePositionOnGameBoard.Row + CurrentPieceOnGameboard.PixelVector[PiecePixel].Row, CurrentPiecePositionOnGameBoard.Column + CurrentPieceOnGameboard.PixelVector[PiecePixel].Column] = ElementID.Free;
                    }

                    CurrentPiecePositionOnGameBoard.Column++;

                    for (int PiecePixel = 0; PiecePixel < 4; PiecePixel++)
                    {
                        backBoardGame.Matrix[CurrentPiecePositionOnGameBoard.Row + CurrentPieceOnGameboard.PixelVector[PiecePixel].Row, CurrentPiecePositionOnGameBoard.Column + CurrentPieceOnGameboard.PixelVector[PiecePixel].Column] = CurrentPieceOnGameboard.id;
                    }
                }
            }
            else if (movement == MovementName.Rotate)
            {
                if (NextPositionIsFree(backBoardGame, movement))
                {
                    // Clean current Position
                    for (int PiecePixel = 0; PiecePixel < 4; PiecePixel++)
                    {
                        backBoardGame.Matrix[CurrentPiecePositionOnGameBoard.Row + CurrentPieceOnGameboard.PixelVector[PiecePixel].Row, CurrentPiecePositionOnGameBoard.Column + CurrentPieceOnGameboard.PixelVector[PiecePixel].Column] = ElementID.Free;
                    }

                    CurrentPieceOnGameboard.PieceOrientation++;
                    CurrentPieceOnGameboard.SetPiecePixelVector();

                    for (int PiecePixel = 0; PiecePixel < 4; PiecePixel++)
                    {
                        backBoardGame.Matrix[CurrentPiecePositionOnGameBoard.Row + CurrentPieceOnGameboard.PixelVector[PiecePixel].Row, CurrentPiecePositionOnGameBoard.Column + CurrentPieceOnGameboard.PixelVector[PiecePixel].Column] = CurrentPieceOnGameboard.id;
                    }
                }
            }
            else
            {
                ;
            }

            return MachineStateName.Move;
        }

        public void TiePiece(BackBoardGame backBoardGame)
        {
            for (int PiecePixel = 0; PiecePixel < 4; PiecePixel++)
            {
                backBoardGame.Matrix[CurrentPiecePositionOnGameBoard.Row + CurrentPieceOnGameboard.PixelVector[PiecePixel].Row, CurrentPiecePositionOnGameBoard.Column + CurrentPieceOnGameboard.PixelVector[PiecePixel].Column] = ElementID.OldPiece;
            }
        }

        public void ResetGame(BackBoardGame backBoardGame, formPlay formp)
        {
            formp.timer1.Enabled = false;
            CurrentPiecePositionOnGameBoard.Column = StartPiecePosition.Column;
            CurrentPiecePositionOnGameBoard.Row = StartPiecePosition.Row;
            CurrentPieceOnGameboard = null;
            NextPieceOnGameboard = null;
            backBoardGame.ScoreBoard = 0;
            backBoardGame.ResetBackBoardGame();
            formp.timer1.Enabled = true;
        }

        public void CheckFullLine(BackBoardGame backBoardGame)
        {
            int[] RowID = new int[backBoardGame.RowQty];
            int IndexRowID = 0;

            for (int row = 0; row < backBoardGame.RowQty - 1; row++)
            {
                for (int column = 1; column < backBoardGame.ColunmQty - 1; column++)
                {
                    if (backBoardGame.Matrix[row, column] == ElementID.Free)
                    {
                        break;
                    }
                    if (column == backBoardGame.ColunmQty - 2)
                    {
                        RowID[IndexRowID] = row;
                        IndexRowID++;
                    }
                }
            }

            EraseRows(backBoardGame, RowID);


        }

        private bool NextPositionIsFree(BackBoardGame backBoardGame, MovementName movement)
        {
            Position NextVerifyPositionOnGameBoard = new Position(CurrentPiecePositionOnGameBoard.Row, CurrentPiecePositionOnGameBoard.Column);

            if (movement == MovementName.Down)
            {
                NextVerifyPositionOnGameBoard.Row++;
                for (int PiecePixel = 0; PiecePixel < 4; PiecePixel++)
                {
                    if ((backBoardGame.Matrix[NextVerifyPositionOnGameBoard.Row + CurrentPieceOnGameboard.PixelVector[PiecePixel].Row, NextVerifyPositionOnGameBoard.Column + CurrentPieceOnGameboard.PixelVector[PiecePixel].Column] != ElementID.Free)
                        && (backBoardGame.Matrix[NextVerifyPositionOnGameBoard.Row + CurrentPieceOnGameboard.PixelVector[PiecePixel].Row, NextVerifyPositionOnGameBoard.Column + CurrentPieceOnGameboard.PixelVector[PiecePixel].Column] != CurrentPieceOnGameboard.id))
                    {
                        return (false);
                    }
                }
                return (true);
            }
            else if (movement == MovementName.Left)
            {
                NextVerifyPositionOnGameBoard.Column--;
                for (int PiecePixel = 0; PiecePixel < 4; PiecePixel++)
                {
                    if ((backBoardGame.Matrix[NextVerifyPositionOnGameBoard.Row + CurrentPieceOnGameboard.PixelVector[PiecePixel].Row, NextVerifyPositionOnGameBoard.Column + CurrentPieceOnGameboard.PixelVector[PiecePixel].Column] != ElementID.Free)
                        && (backBoardGame.Matrix[NextVerifyPositionOnGameBoard.Row + CurrentPieceOnGameboard.PixelVector[PiecePixel].Row, NextVerifyPositionOnGameBoard.Column + CurrentPieceOnGameboard.PixelVector[PiecePixel].Column] != CurrentPieceOnGameboard.id))
                    {
                        return (false);
                    }
                }
                return (true);
            }
            else if (movement == MovementName.Right)
            {
                NextVerifyPositionOnGameBoard.Column++;
                for (int PiecePixel = 0; PiecePixel < 4; PiecePixel++)
                {
                    if ((backBoardGame.Matrix[NextVerifyPositionOnGameBoard.Row + CurrentPieceOnGameboard.PixelVector[PiecePixel].Row, NextVerifyPositionOnGameBoard.Column + CurrentPieceOnGameboard.PixelVector[PiecePixel].Column] != ElementID.Free)
                        && (backBoardGame.Matrix[NextVerifyPositionOnGameBoard.Row + CurrentPieceOnGameboard.PixelVector[PiecePixel].Row, NextVerifyPositionOnGameBoard.Column + CurrentPieceOnGameboard.PixelVector[PiecePixel].Column] != CurrentPieceOnGameboard.id))
                    {
                        return (false);
                    }
                }
                return (true);
            }
            else if (movement == MovementName.Rotate)
            {
                Position[] NextRotationPositionOnGameboard = new Position[4];
                for (int MemPixel = 0; MemPixel < 4; MemPixel++)
                {
                    NextRotationPositionOnGameboard[MemPixel] = new Position();
                }

                // Rotate CurrentPieceOnGameboard and return piece vector on origin
                NextRotationPositionOnGameboard = Piece.SetPiecePixelVector(CurrentPieceOnGameboard.id, CurrentPieceOnGameboard.PieceOrientation + 1);


                for (int PiecePixel = 0; PiecePixel < 4; PiecePixel++)
                {
                    if ((backBoardGame.Matrix[CurrentPiecePositionOnGameBoard.Row + NextRotationPositionOnGameboard[PiecePixel].Row, CurrentPiecePositionOnGameBoard.Column + NextRotationPositionOnGameboard[PiecePixel].Column] == ElementID.Wall)
                        || backBoardGame.Matrix[CurrentPiecePositionOnGameBoard.Row + NextRotationPositionOnGameboard[PiecePixel].Row, CurrentPiecePositionOnGameBoard.Column + NextRotationPositionOnGameboard[PiecePixel].Column] == ElementID.OldPiece)
                    {
                        return (false);
                    }
                }
                return (true);
            }
            return (false);
        }

        private void EraseRows(BackBoardGame backBoardGame, int[] RowID)
        {
            int qtyEraseRows = 0;

            // paint row with currentpiece color
            for (int row = 0; row < backBoardGame.RowQty; row++)
            {
                if (RowID[row] != 0)
                {
                    qtyEraseRows++;

                    for (int column = 1; column < backBoardGame.ColunmQty - 1; column++)
                    {
                        backBoardGame.Matrix[RowID[row], column] = CurrentPieceOnGameboard.id;
                    }
                }
            }

            if (qtyEraseRows > 0)
            {
                for (int row = 0; row < backBoardGame.RowQty; row++)
                {
                    if (RowID[row] != 0)
                    {
                        for (int eraseRow = RowID[row]; eraseRow > 0; eraseRow--)
                        {
                            for (int column = 1; column < backBoardGame.ColunmQty - 1; column++)
                            {
                                if (eraseRow > 0)
                                    backBoardGame.Matrix[eraseRow, column] = backBoardGame.Matrix[eraseRow - 1, column];
                            }
                        }
                    }
                }
            }

            backBoardGame.ScoreBoard += (10 * qtyEraseRows * qtyEraseRows);
        }
    }
}
