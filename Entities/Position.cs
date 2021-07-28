using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Entities
{
    public class Position
    {
        public int Row;
        public int Column;

        public Position()
        {
            this.Row = 0;
            this.Column = 1;
        }

        public Position(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}
