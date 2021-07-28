using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Entities.Enums;



namespace Tetris.Entities.BackEnd
{
    public class BackBoardGame
    {
        public string PlayerName { get; set; }
        public int ScoreBoard { get; set; }
        public ElementID[,] Matrix { get; set; }
        public ElementID[,] NextPieceMatrix { get; set; }
        public int RowQty { get; private set; }
        public int ColunmQty { get; private set; }


        public BackBoardGame()
        {
            this.ScoreBoard = 0;
            this.PlayerName = "Default Name";

            this.RowQty = 21;
            this.ColunmQty = 13;

            this.Matrix = new ElementID[this.RowQty, this.ColunmQty];

            // initializes all board game grid 
            for (int j = 0; j < this.RowQty; j++)
            {
                for (int i = 0; i < this.ColunmQty; i++)
                {
                    if (i == 0 || i == (this.ColunmQty - 1))
                    {
                        this.Matrix[j, i] = ElementID.Wall;
                    }
                    else if (j == (this.RowQty - 1))
                    {
                        this.Matrix[j, i] = ElementID.Wall;
                    }
                    else
                    {
                        this.Matrix[j, i] = ElementID.Free;
                    }
                }
            }

            this.NextPieceMatrix = new ElementID[this.RowQty, this.ColunmQty];

            // initializes all board game grid 
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    this.NextPieceMatrix[j, i] = ElementID.NextPieceGrid;
                }
            }

        }

        public void ResetBackBoardGame()
        {
            // initializes all board game grid 
            for (int j = 0; j < this.RowQty; j++)
            {
                for (int i = 0; i < this.ColunmQty; i++)
                {
                    if (i == 0 || i == (this.ColunmQty - 1))
                        ;
                    else if (j == (this.RowQty - 1))
                        ;
                    else
                    {
                        this.Matrix[j, i] = ElementID.Free;
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder completeString = new StringBuilder();
            completeString.AppendLine("");
            completeString.AppendLine(PlayerName);
            completeString.AppendLine(ScoreBoard.ToString());
            completeString.AppendLine("");
            completeString.AppendLine("Next Piece:");

            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    completeString.Append(((int)this.NextPieceMatrix[j, i]).ToString("D2") + " ");
                }
                completeString.AppendLine(" ");
            }

            completeString.AppendLine("");

            for (int j = 0; j < this.RowQty; j++)
            {
                for (int i = 0; i < this.ColunmQty; i++)
                {
                    completeString.Append(((int)this.Matrix[j, i]).ToString() + " ");
                }
                completeString.AppendLine(" ");
            }
            return completeString.ToString();
        }

    }
}
