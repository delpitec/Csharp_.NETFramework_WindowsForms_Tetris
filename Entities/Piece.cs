using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Entities.Enums;

namespace Tetris.Entities
{
    public class Piece
    {

        public ElementID id { private set; get; }
        public Position[] PixelVector { private set; get; } = new Position[4];

        private PieceOrientationName _pieceOrientation;

        public Piece()
        {

        }

        public Piece(ElementID pieceId)
        {
            this.id = pieceId;
            SetPiecePixelVector();
        }

        public Piece(ElementID pieceId, PieceOrientationName pieceOrientation)
        {
            this.id = pieceId;
            this.PieceOrientation = pieceOrientation;
            SetPiecePixelVector();
        }

        public PieceOrientationName PieceOrientation
        {
            get
            {
                return _pieceOrientation;
            }
            set
            {
                if (value > PieceOrientationName.Right)
                    _pieceOrientation = PieceOrientationName.Up;
                else
                    _pieceOrientation = value;
            }
        }

        public static Position[] SetPiecePixelVector(ElementID id, PieceOrientationName pieceOrientation)
        {
            Position[] _pixelVector = new Position[4];
            _pixelVector[0] = new Position();
            _pixelVector[1] = new Position();
            _pixelVector[2] = new Position();
            _pixelVector[3] = new Position();


            if (pieceOrientation > PieceOrientationName.Right)
            {
                pieceOrientation = PieceOrientationName.Up;
            }

            if (id == ElementID.JBlock)
            {
                if (pieceOrientation == PieceOrientationName.Up)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = -1;
                    _pixelVector[1].Row = 0;
                    _pixelVector[1].Column = -1;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = 0;
                    _pixelVector[3].Row = 0;
                    _pixelVector[3].Column = 1;
                }
                else if (pieceOrientation == PieceOrientationName.Left)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = 0;
                    _pixelVector[1].Row = 0;
                    _pixelVector[1].Column = 0;
                    _pixelVector[2].Row = 1;
                    _pixelVector[2].Column = -1;
                    _pixelVector[3].Row = 1;
                    _pixelVector[3].Column = 0;
                }
                else if (pieceOrientation == PieceOrientationName.Down)
                {
                    _pixelVector[0].Row = 0;
                    _pixelVector[0].Column = -1;
                    _pixelVector[1].Row = 0;
                    _pixelVector[1].Column = 0;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = 1;
                    _pixelVector[3].Row = 1;
                    _pixelVector[3].Column = 1;
                }
                else if (pieceOrientation == PieceOrientationName.Right)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = 0;
                    _pixelVector[1].Row = -1;
                    _pixelVector[1].Column = 1;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = 0;
                    _pixelVector[3].Row = 1;
                    _pixelVector[3].Column = 0;
                }
                else
                {
                    _pixelVector[0].Row = default;
                    _pixelVector[0].Column = default;
                    _pixelVector[1].Row = default;
                    _pixelVector[1].Column = default;
                    _pixelVector[2].Row = default;
                    _pixelVector[2].Column = default;
                    _pixelVector[3].Row = default;
                    _pixelVector[3].Column = default;
                }
            }
            else if (id == ElementID.TBlock)
            {
                if (pieceOrientation == PieceOrientationName.Up)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = 0;
                    _pixelVector[1].Row = 0;
                    _pixelVector[1].Column = -1;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = 0;
                    _pixelVector[3].Row = 0;
                    _pixelVector[3].Column = 1;
                }
                else if (pieceOrientation == PieceOrientationName.Left)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = 0;
                    _pixelVector[1].Row = 0;
                    _pixelVector[1].Column = -1;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = 0;
                    _pixelVector[3].Row = 1;
                    _pixelVector[3].Column = 0;
                }
                else if (pieceOrientation == PieceOrientationName.Down)
                {
                    _pixelVector[0].Row = 0;
                    _pixelVector[0].Column = -1;
                    _pixelVector[1].Row = 0;
                    _pixelVector[1].Column = 0;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = 1;
                    _pixelVector[3].Row = 1;
                    _pixelVector[3].Column = 0;
                }
                else if (pieceOrientation == PieceOrientationName.Right)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = 0;
                    _pixelVector[1].Row = 0;
                    _pixelVector[1].Column = 0;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = 1;
                    _pixelVector[3].Row = 1;
                    _pixelVector[3].Column = 0;
                }
                else
                {
                    _pixelVector[0].Row = default;
                    _pixelVector[0].Column = default;
                    _pixelVector[1].Row = default;
                    _pixelVector[1].Column = default;
                    _pixelVector[2].Row = default;
                    _pixelVector[2].Column = default;
                    _pixelVector[3].Row = default;
                    _pixelVector[3].Column = default;
                }
            }
            else if (id == ElementID.LBlock)
            {
                if (pieceOrientation == PieceOrientationName.Up)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = 1;
                    _pixelVector[1].Row = 0;
                    _pixelVector[1].Column = -1;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = 0;
                    _pixelVector[3].Row = 0;
                    _pixelVector[3].Column = 1;
                }
                else if (pieceOrientation == PieceOrientationName.Left)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = -1;
                    _pixelVector[1].Row = -1;
                    _pixelVector[1].Column = 0;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = 0;
                    _pixelVector[3].Row = 1;
                    _pixelVector[3].Column = 0;
                }
                else if (pieceOrientation == PieceOrientationName.Down)
                {
                    _pixelVector[0].Row = 0;
                    _pixelVector[0].Column = -1;
                    _pixelVector[1].Row = 0;
                    _pixelVector[1].Column = 0;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = 1;
                    _pixelVector[3].Row = 1;
                    _pixelVector[3].Column = -1;
                }
                else if (pieceOrientation == PieceOrientationName.Right)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = 0;
                    _pixelVector[1].Row = 0;
                    _pixelVector[1].Column = 0;
                    _pixelVector[2].Row = 1;
                    _pixelVector[2].Column = 0;
                    _pixelVector[3].Row = 1;
                    _pixelVector[3].Column = 1;
                }
                else
                {
                    _pixelVector[0].Row = default;
                    _pixelVector[0].Column = default;
                    _pixelVector[1].Row = default;
                    _pixelVector[1].Column = default;
                    _pixelVector[2].Row = default;
                    _pixelVector[2].Column = default;
                    _pixelVector[3].Row = default;
                    _pixelVector[3].Column = default;
                }
            }
            else if (id == ElementID.IBlock)
            {
                if (pieceOrientation == PieceOrientationName.Up)
                {
                    _pixelVector[0].Row = 0;
                    _pixelVector[0].Column = -1;
                    _pixelVector[1].Row = 0;
                    _pixelVector[1].Column = 0;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = 1;
                    _pixelVector[3].Row = 0;
                    _pixelVector[3].Column = 2;
                }
                else if (pieceOrientation == PieceOrientationName.Left)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = 0;
                    _pixelVector[1].Row = 0;
                    _pixelVector[1].Column = 0;
                    _pixelVector[2].Row = 1;
                    _pixelVector[2].Column = 0;
                    _pixelVector[3].Row = 2;
                    _pixelVector[3].Column = 0;
                }
                else if (pieceOrientation == PieceOrientationName.Down)
                {
                    _pixelVector[0].Row = 0;
                    _pixelVector[0].Column = -1;
                    _pixelVector[1].Row = 0;
                    _pixelVector[1].Column = 0;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = 1;
                    _pixelVector[3].Row = 0;
                    _pixelVector[3].Column = 2;
                }
                else if (pieceOrientation == PieceOrientationName.Right)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = 0;
                    _pixelVector[1].Row = 0;
                    _pixelVector[1].Column = 0;
                    _pixelVector[2].Row = 1;
                    _pixelVector[2].Column = 0;
                    _pixelVector[3].Row = 2;
                    _pixelVector[3].Column = 0;
                }
                else
                {
                    _pixelVector[0].Row = default;
                    _pixelVector[0].Column = default;
                    _pixelVector[1].Row = default;
                    _pixelVector[1].Column = default;
                    _pixelVector[2].Row = default;
                    _pixelVector[2].Column = default;
                    _pixelVector[3].Row = default;
                    _pixelVector[3].Column = default;
                }
            }
            else if (id == ElementID.OBlock)
            {
                if (pieceOrientation == PieceOrientationName.Up)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = 0;
                    _pixelVector[1].Row = -1;
                    _pixelVector[1].Column = 1;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = 0;
                    _pixelVector[3].Row = 0;
                    _pixelVector[3].Column = 1;
                }
                else if (pieceOrientation == PieceOrientationName.Left)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = 0;
                    _pixelVector[1].Row = -1;
                    _pixelVector[1].Column = 1;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = 0;
                    _pixelVector[3].Row = 0;
                    _pixelVector[3].Column = 1;
                }
                else if (pieceOrientation == PieceOrientationName.Down)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = 0;
                    _pixelVector[1].Row = -1;
                    _pixelVector[1].Column = 1;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = 0;
                    _pixelVector[3].Row = 0;
                    _pixelVector[3].Column = 1;
                }
                else if (pieceOrientation == PieceOrientationName.Right)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = 0;
                    _pixelVector[1].Row = -1;
                    _pixelVector[1].Column = 1;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = 0;
                    _pixelVector[3].Row = 0;
                    _pixelVector[3].Column = 1;
                }
                else
                {
                    _pixelVector[0].Row = default;
                    _pixelVector[0].Column = default;
                    _pixelVector[1].Row = default;
                    _pixelVector[1].Column = default;
                    _pixelVector[2].Row = default;
                    _pixelVector[2].Column = default;
                    _pixelVector[3].Row = default;
                    _pixelVector[3].Column = default;
                }
            }
            else if (id == ElementID.SBlock)
            {
                if (pieceOrientation == PieceOrientationName.Up)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = 0;
                    _pixelVector[1].Row = -1;
                    _pixelVector[1].Column = 1;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = -1;
                    _pixelVector[3].Row = 0;
                    _pixelVector[3].Column = 0;
                }
                else if (pieceOrientation == PieceOrientationName.Left)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = -1;
                    _pixelVector[1].Row = 0;
                    _pixelVector[1].Column = -1;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = 0;
                    _pixelVector[3].Row = 1;
                    _pixelVector[3].Column = 0;
                }
                else if (pieceOrientation == PieceOrientationName.Down)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = 0;
                    _pixelVector[1].Row = -1;
                    _pixelVector[1].Column = 1;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = -1;
                    _pixelVector[3].Row = 0;
                    _pixelVector[3].Column = 0;
                }
                else if (pieceOrientation == PieceOrientationName.Right)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = -1;
                    _pixelVector[1].Row = 0;
                    _pixelVector[1].Column = -1;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = 0;
                    _pixelVector[3].Row = 1;
                    _pixelVector[3].Column = 0;
                }
                else
                {
                    _pixelVector[0].Row = default;
                    _pixelVector[0].Column = default;
                    _pixelVector[1].Row = default;
                    _pixelVector[1].Column = default;
                    _pixelVector[2].Row = default;
                    _pixelVector[2].Column = default;
                    _pixelVector[3].Row = default;
                    _pixelVector[3].Column = default;
                }
            }
            else if (id == ElementID.ZBlock)
            {
                if (pieceOrientation == PieceOrientationName.Up)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = -1;
                    _pixelVector[1].Row = -1;
                    _pixelVector[1].Column = 0;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = 0;
                    _pixelVector[3].Row = 0;
                    _pixelVector[3].Column = 1;
                }
                else if (pieceOrientation == PieceOrientationName.Left)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = 0;
                    _pixelVector[1].Row = 0;
                    _pixelVector[1].Column = 0;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = -1;
                    _pixelVector[3].Row = 1;
                    _pixelVector[3].Column = -1;
                }
                else if (pieceOrientation == PieceOrientationName.Down)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = -1;
                    _pixelVector[1].Row = -1;
                    _pixelVector[1].Column = 0;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = 0;
                    _pixelVector[3].Row = 0;
                    _pixelVector[3].Column = 1;
                }
                else if (pieceOrientation == PieceOrientationName.Right)
                {
                    _pixelVector[0].Row = -1;
                    _pixelVector[0].Column = 0;
                    _pixelVector[1].Row = 0;
                    _pixelVector[1].Column = 0;
                    _pixelVector[2].Row = 0;
                    _pixelVector[2].Column = -1;
                    _pixelVector[3].Row = 1;
                    _pixelVector[3].Column = -1;
                }
                else
                {
                    _pixelVector[0].Row = default;
                    _pixelVector[0].Column = default;
                    _pixelVector[1].Row = default;
                    _pixelVector[1].Column = default;
                    _pixelVector[2].Row = default;
                    _pixelVector[2].Column = default;
                    _pixelVector[3].Row = default;
                    _pixelVector[3].Column = default;
                }
            }

            return _pixelVector;
        }

        public void SetPiecePixelVector()
        {
            this.PixelVector[0] = new Position();
            this.PixelVector[1] = new Position();
            this.PixelVector[2] = new Position();
            this.PixelVector[3] = new Position();

            if (this.id == ElementID.JBlock)
            {
                if (this.PieceOrientation == PieceOrientationName.Up)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = -1;
                    this.PixelVector[1].Row = 0;
                    this.PixelVector[1].Column = -1;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = 0;
                    this.PixelVector[3].Row = 0;
                    this.PixelVector[3].Column = 1;
                }
                else if (this.PieceOrientation == PieceOrientationName.Left)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = 0;
                    this.PixelVector[1].Row = 0;
                    this.PixelVector[1].Column = 0;
                    this.PixelVector[2].Row = 1;
                    this.PixelVector[2].Column = -1;
                    this.PixelVector[3].Row = 1;
                    this.PixelVector[3].Column = 0;
                }
                else if (this.PieceOrientation == PieceOrientationName.Down)
                {
                    this.PixelVector[0].Row = 0;
                    this.PixelVector[0].Column = -1;
                    this.PixelVector[1].Row = 0;
                    this.PixelVector[1].Column = 0;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = 1;
                    this.PixelVector[3].Row = 1;
                    this.PixelVector[3].Column = 1;
                }
                else if (this.PieceOrientation == PieceOrientationName.Right)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = 0;
                    this.PixelVector[1].Row = -1;
                    this.PixelVector[1].Column = 1;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = 0;
                    this.PixelVector[3].Row = 1;
                    this.PixelVector[3].Column = 0;
                }
                else
                {
                    this.PixelVector[0].Row = default;
                    this.PixelVector[0].Column = default;
                    this.PixelVector[1].Row = default;
                    this.PixelVector[1].Column = default;
                    this.PixelVector[2].Row = default;
                    this.PixelVector[2].Column = default;
                    this.PixelVector[3].Row = default;
                    this.PixelVector[3].Column = default;
                }
            }
            else if (this.id == ElementID.TBlock)
            {
                if (this.PieceOrientation == PieceOrientationName.Up)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = 0;
                    this.PixelVector[1].Row = 0;
                    this.PixelVector[1].Column = -1;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = 0;
                    this.PixelVector[3].Row = 0;
                    this.PixelVector[3].Column = 1;
                }
                else if (this.PieceOrientation == PieceOrientationName.Left)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = 0;
                    this.PixelVector[1].Row = 0;
                    this.PixelVector[1].Column = -1;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = 0;
                    this.PixelVector[3].Row = 1;
                    this.PixelVector[3].Column = 0;
                }
                else if (this.PieceOrientation == PieceOrientationName.Down)
                {
                    this.PixelVector[0].Row = 0;
                    this.PixelVector[0].Column = -1;
                    this.PixelVector[1].Row = 0;
                    this.PixelVector[1].Column = 0;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = 1;
                    this.PixelVector[3].Row = 1;
                    this.PixelVector[3].Column = 0;
                }
                else if (this.PieceOrientation == PieceOrientationName.Right)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = 0;
                    this.PixelVector[1].Row = 0;
                    this.PixelVector[1].Column = 0;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = 1;
                    this.PixelVector[3].Row = 1;
                    this.PixelVector[3].Column = 0;
                }
                else
                {
                    this.PixelVector[0].Row = default;
                    this.PixelVector[0].Column = default;
                    this.PixelVector[1].Row = default;
                    this.PixelVector[1].Column = default;
                    this.PixelVector[2].Row = default;
                    this.PixelVector[2].Column = default;
                    this.PixelVector[3].Row = default;
                    this.PixelVector[3].Column = default;
                }
            }
            else if (this.id == ElementID.LBlock)
            {
                if (this.PieceOrientation == PieceOrientationName.Up)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = 1;
                    this.PixelVector[1].Row = 0;
                    this.PixelVector[1].Column = -1;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = 0;
                    this.PixelVector[3].Row = 0;
                    this.PixelVector[3].Column = 1;
                }
                else if (this.PieceOrientation == PieceOrientationName.Left)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = -1;
                    this.PixelVector[1].Row = -1;
                    this.PixelVector[1].Column = 0;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = 0;
                    this.PixelVector[3].Row = 1;
                    this.PixelVector[3].Column = 0;
                }
                else if (this.PieceOrientation == PieceOrientationName.Down)
                {
                    this.PixelVector[0].Row = 0;
                    this.PixelVector[0].Column = -1;
                    this.PixelVector[1].Row = 0;
                    this.PixelVector[1].Column = 0;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = 1;
                    this.PixelVector[3].Row = 1;
                    this.PixelVector[3].Column = -1;
                }
                else if (this.PieceOrientation == PieceOrientationName.Right)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = 0;
                    this.PixelVector[1].Row = 0;
                    this.PixelVector[1].Column = 0;
                    this.PixelVector[2].Row = 1;
                    this.PixelVector[2].Column = 0;
                    this.PixelVector[3].Row = 1;
                    this.PixelVector[3].Column = 1;
                }
                else
                {
                    this.PixelVector[0].Row = default;
                    this.PixelVector[0].Column = default;
                    this.PixelVector[1].Row = default;
                    this.PixelVector[1].Column = default;
                    this.PixelVector[2].Row = default;
                    this.PixelVector[2].Column = default;
                    this.PixelVector[3].Row = default;
                    this.PixelVector[3].Column = default;
                }
            }
            else if (this.id == ElementID.IBlock)
            {
                if (this.PieceOrientation == PieceOrientationName.Up)
                {
                    this.PixelVector[0].Row = 0;
                    this.PixelVector[0].Column = -1;
                    this.PixelVector[1].Row = 0;
                    this.PixelVector[1].Column = 0;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = 1;
                    this.PixelVector[3].Row = 0;
                    this.PixelVector[3].Column = 2;
                }
                else if (this.PieceOrientation == PieceOrientationName.Left)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = 0;
                    this.PixelVector[1].Row = 0;
                    this.PixelVector[1].Column = 0;
                    this.PixelVector[2].Row = 1;
                    this.PixelVector[2].Column = 0;
                    this.PixelVector[3].Row = 2;
                    this.PixelVector[3].Column = 0;

                }
                else if (this.PieceOrientation == PieceOrientationName.Down)
                {
                    this.PixelVector[0].Row = 0;
                    this.PixelVector[0].Column = -1;
                    this.PixelVector[1].Row = 0;
                    this.PixelVector[1].Column = 0;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = 1;
                    this.PixelVector[3].Row = 0;
                    this.PixelVector[3].Column = 2;
                }
                else if (this.PieceOrientation == PieceOrientationName.Right)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = 0;
                    this.PixelVector[1].Row = 0;
                    this.PixelVector[1].Column = 0;
                    this.PixelVector[2].Row = 1;
                    this.PixelVector[2].Column = 0;
                    this.PixelVector[3].Row = 2;
                    this.PixelVector[3].Column = 0;
                }
                else
                {
                    this.PixelVector[0].Row = default;
                    this.PixelVector[0].Column = default;
                    this.PixelVector[1].Row = default;
                    this.PixelVector[1].Column = default;
                    this.PixelVector[2].Row = default;
                    this.PixelVector[2].Column = default;
                    this.PixelVector[3].Row = default;
                    this.PixelVector[3].Column = default;
                }
            }
            else if (this.id == ElementID.OBlock)
            {
                if (this.PieceOrientation == PieceOrientationName.Up)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = 0;
                    this.PixelVector[1].Row = -1;
                    this.PixelVector[1].Column = 1;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = 0;
                    this.PixelVector[3].Row = 0;
                    this.PixelVector[3].Column = 1;
                }
                else if (this.PieceOrientation == PieceOrientationName.Left)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = 0;
                    this.PixelVector[1].Row = -1;
                    this.PixelVector[1].Column = 1;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = 0;
                    this.PixelVector[3].Row = 0;
                    this.PixelVector[3].Column = 1;
                }
                else if (this.PieceOrientation == PieceOrientationName.Down)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = 0;
                    this.PixelVector[1].Row = -1;
                    this.PixelVector[1].Column = 1;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = 0;
                    this.PixelVector[3].Row = 0;
                    this.PixelVector[3].Column = 1;
                }
                else if (this.PieceOrientation == PieceOrientationName.Right)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = 0;
                    this.PixelVector[1].Row = -1;
                    this.PixelVector[1].Column = 1;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = 0;
                    this.PixelVector[3].Row = 0;
                    this.PixelVector[3].Column = 1;
                }
                else
                {
                    this.PixelVector[0].Row = default;
                    this.PixelVector[0].Column = default;
                    this.PixelVector[1].Row = default;
                    this.PixelVector[1].Column = default;
                    this.PixelVector[2].Row = default;
                    this.PixelVector[2].Column = default;
                    this.PixelVector[3].Row = default;
                    this.PixelVector[3].Column = default;
                }
            }
            else if (this.id == ElementID.SBlock)
            {
                if (this.PieceOrientation == PieceOrientationName.Up)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = 0;
                    this.PixelVector[1].Row = -1;
                    this.PixelVector[1].Column = 1;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = -1;
                    this.PixelVector[3].Row = 0;
                    this.PixelVector[3].Column = 0;
                }
                else if (this.PieceOrientation == PieceOrientationName.Left)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = -1;
                    this.PixelVector[1].Row = 0;
                    this.PixelVector[1].Column = -1;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = 0;
                    this.PixelVector[3].Row = 1;
                    this.PixelVector[3].Column = 0;
                }
                else if (this.PieceOrientation == PieceOrientationName.Down)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = 0;
                    this.PixelVector[1].Row = -1;
                    this.PixelVector[1].Column = 1;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = -1;
                    this.PixelVector[3].Row = 0;
                    this.PixelVector[3].Column = 0;
                }
                else if (this.PieceOrientation == PieceOrientationName.Right)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = -1;
                    this.PixelVector[1].Row = 0;
                    this.PixelVector[1].Column = -1;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = 0;
                    this.PixelVector[3].Row = 1;
                    this.PixelVector[3].Column = 0;
                }
                else
                {
                    this.PixelVector[0].Row = default;
                    this.PixelVector[0].Column = default;
                    this.PixelVector[1].Row = default;
                    this.PixelVector[1].Column = default;
                    this.PixelVector[2].Row = default;
                    this.PixelVector[2].Column = default;
                    this.PixelVector[3].Row = default;
                    this.PixelVector[3].Column = default;
                }
            }
            else if (this.id == ElementID.ZBlock)
            {
                if (this.PieceOrientation == PieceOrientationName.Up)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = -1;
                    this.PixelVector[1].Row = -1;
                    this.PixelVector[1].Column = 0;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = 0;
                    this.PixelVector[3].Row = 0;
                    this.PixelVector[3].Column = 1;
                }
                else if (this.PieceOrientation == PieceOrientationName.Left)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = 0;
                    this.PixelVector[1].Row = 0;
                    this.PixelVector[1].Column = 0;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = -1;
                    this.PixelVector[3].Row = 1;
                    this.PixelVector[3].Column = -1;
                }
                else if (this.PieceOrientation == PieceOrientationName.Down)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = -1;
                    this.PixelVector[1].Row = -1;
                    this.PixelVector[1].Column = 0;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = 0;
                    this.PixelVector[3].Row = 0;
                    this.PixelVector[3].Column = 1;
                }
                else if (this.PieceOrientation == PieceOrientationName.Right)
                {
                    this.PixelVector[0].Row = -1;
                    this.PixelVector[0].Column = 0;
                    this.PixelVector[1].Row = 0;
                    this.PixelVector[1].Column = 0;
                    this.PixelVector[2].Row = 0;
                    this.PixelVector[2].Column = -1;
                    this.PixelVector[3].Row = 1;
                    this.PixelVector[3].Column = -1;
                }
                else
                {
                    this.PixelVector[0].Row = default;
                    this.PixelVector[0].Column = default;
                    this.PixelVector[1].Row = default;
                    this.PixelVector[1].Column = default;
                    this.PixelVector[2].Row = default;
                    this.PixelVector[2].Column = default;
                    this.PixelVector[3].Row = default;
                    this.PixelVector[3].Column = default;
                }
            }
        }
    }
}
