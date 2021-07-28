using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Entities.Enums
{
    public enum ElementID : int
    {
        JBlock = 0,
        TBlock,
        LBlock,
        IBlock,
        OBlock,
        SBlock,
        ZBlock,
        Free,
        Wall,
        OldPiece,
        NextPieceGrid,
    }
}
