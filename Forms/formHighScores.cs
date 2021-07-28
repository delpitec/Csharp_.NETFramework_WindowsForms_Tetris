using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.Entities;

namespace Tetris.Forms
{
    public partial class formHighScores : Form
    {
        public formPlay formPBridge;

        public formHighScores(formPlay formP)
        {
            formPBridge = formP;
            InterfaceDBandGame ServerScoreboard = new InterfaceDBandGame();

            InitializeComponent();

            ServerScoreboard.RefreshLocalScoreBoard();

            StringBuilder NameString = new StringBuilder();
            StringBuilder ScoreString = new StringBuilder();

            for (int i = 0; i < ServerScoreboard.LocalScoreBoardItemsQty(); i++)
            {
                NameString.AppendLine(ServerScoreboard.ReadLocalScoreBoard(i).PlayerName + "\n");
                ScoreString.AppendLine(ServerScoreboard.ReadLocalScoreBoard(i).Score.ToString() + "\n");
            }
            labelName.Text = NameString.ToString();
            labelScore.Text = ScoreString.ToString();
        }

        private void formHighScores_FormClosing(object sender, FormClosingEventArgs e)
        {
            formPBridge.timer1.Enabled = true;
        }
    }
}
