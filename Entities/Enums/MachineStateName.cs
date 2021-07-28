using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Entities.Enums
{
    public enum MachineStateName : int
    {
        AddNewPiece,
        Move,
        TiePiece,
        GameOver,
    }
}
