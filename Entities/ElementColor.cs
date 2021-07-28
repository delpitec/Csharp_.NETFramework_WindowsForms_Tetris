using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Entities.Enums;

namespace Tetris.Entities.Enums
{
    public class ElementColor
    {
        public System.Drawing.Color[] SystemDrawingColor { private set; get; } = new System.Drawing.Color[11];

        public ElementColor()
        {
            SystemDrawingColor[(int)ElementID.JBlock] = System.Drawing.SystemColors.Highlight;
            SystemDrawingColor[(int)ElementID.TBlock] = System.Drawing.Color.DarkOrchid;
            SystemDrawingColor[(int)ElementID.LBlock] = System.Drawing.Color.DarkOrange;
            SystemDrawingColor[(int)ElementID.IBlock] = System.Drawing.Color.Aqua;
            SystemDrawingColor[(int)ElementID.OBlock] = System.Drawing.Color.Yellow;
            SystemDrawingColor[(int)ElementID.SBlock] = System.Drawing.Color.Lime;
            SystemDrawingColor[(int)ElementID.ZBlock] = System.Drawing.Color.Red;
            SystemDrawingColor[(int)ElementID.Wall] = System.Drawing.Color.DarkGray;
            SystemDrawingColor[(int)ElementID.Free] = System.Drawing.SystemColors.Desktop;
            SystemDrawingColor[(int)ElementID.OldPiece] = System.Drawing.Color.Gainsboro;
            SystemDrawingColor[(int)ElementID.NextPieceGrid] = System.Drawing.SystemColors.WindowFrame;
        }
    }
}
