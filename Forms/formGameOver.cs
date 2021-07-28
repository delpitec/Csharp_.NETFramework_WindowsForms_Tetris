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
    public partial class formGameOver : Form
    {
        public formPlay formPlayBridge { private set; get; }

        public formGameOver(formPlay formP)
        {
            formPlayBridge = formP;
            InterfaceDBandGame ServerScoreboard = new InterfaceDBandGame();

            InitializeComponent();
            
            LabelGameOverMsg.Text = formP.boardGame.BackBoardGame.PlayerName + ",\nYour game is over.\nWould you like try again?";
            LabelGameOverScore.Text = "Final score: " + formP.boardGame.BackBoardGame.ScoreBoard.ToString() + " pts!";
            ServerScoreboard.WriteScoreBoard(formP.boardGame.BackBoardGame.PlayerName, formP.boardGame.BackBoardGame.ScoreBoard);
        }

        private void ButtonNo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonYes_Click(object sender, EventArgs e)
        {
            formPlayBridge.State = Entities.Enums.MachineStateName.AddNewPiece;
            this.Close();
        }
    }
}
