using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Tetris.Entities;
using Tetris.Entities.Enums;



namespace Tetris.Forms
{
    public partial class formPlay : Form
    {
        public MachineStateName State { set; get; }
        public FrontBoardGame boardGame { private set; get; }
        public ActionGame action { private set; get; }
        public string ScoreBoard { set; get; }

        System.Windows.Forms.Panel panel1 = new System.Windows.Forms.Panel();

        public formPlay()
        {
            InitializeComponent();
            boardGame = new FrontBoardGame(this);
            this.action = new ActionGame(1, 6);
            this.action.AddNewPiece(boardGame.BackBoardGame);
            this.action.MovePiece(boardGame.BackBoardGame, MovementName.Down);
            boardGame.RefreshFrontBoardGame(this);
            State = MachineStateName.Move;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (State == MachineStateName.AddNewPiece)
            {
                State = this.action.AddNewPiece(boardGame.BackBoardGame);
                boardGame.RefreshFrontBoardGame(this);
            }
            else if (State == MachineStateName.Move)
            {
                State = this.action.MovePiece(boardGame.BackBoardGame, MovementName.Down);
                boardGame.RefreshFrontBoardGame(this);

                if (State == MachineStateName.TiePiece)
                {
                    this.action.TiePiece(boardGame.BackBoardGame);
                    this.action.CheckFullLine(boardGame.BackBoardGame);

                    State = MachineStateName.AddNewPiece;

                }
            }
            if (State == MachineStateName.GameOver)
            {
                formGameOver _formGameOver = new formGameOver(this);
                this.timer1.Enabled = false;

                // Não deixa selecionar janelas atrás
                _formGameOver.ShowDialog(this);

                this.action.ResetGame(boardGame.BackBoardGame, this);
            }
        }

        private void formPlay_KeyDown(object sender, KeyEventArgs e)
        {
            if (State == MachineStateName.Move)
            {
                if (e.KeyCode == Keys.Left)
                {
                    this.action.MovePiece(boardGame.BackBoardGame, MovementName.Left);
                    boardGame.RefreshFrontBoardGame(this);
                }
                else if (e.KeyCode == Keys.Right)
                {
                    this.action.MovePiece(boardGame.BackBoardGame, MovementName.Right);
                    boardGame.RefreshFrontBoardGame(this);
                }
                else if (e.KeyCode == Keys.Up)
                {
                    this.action.MovePiece(boardGame.BackBoardGame, MovementName.Rotate);
                    boardGame.RefreshFrontBoardGame(this);
                }
                else if (e.KeyCode == Keys.Down)
                {
                    this.action.MovePiece(boardGame.BackBoardGame, MovementName.Down);
                    boardGame.RefreshFrontBoardGame(this);
                }


            }
        }


        private void OpenEditNameForm()
        {
            // Piece movimentation timer
            this.timer1.Enabled = false;

            formEditName _formEditName = new formEditName(this);

            // Não deixa selecionar janelas atrás
            _formEditName.ShowDialog();
        }

        private void OpenHighScoresForm()
        {
            // Piece movimentation timer
            this.timer1.Enabled = false;

            formHighScores _formHighScores = new formHighScores(this);

            // Não deixa selecionar janelas atrás
            _formHighScores.ShowDialog();
        }

        private void playPauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.timer1.Enabled == true)
                this.timer1.Enabled = false;
            else
                this.timer1.Enabled = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.action.ResetGame(boardGame.BackBoardGame, this);
            State = MachineStateName.AddNewPiece;
        }

        private void editNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEditNameForm();
        }

        private void HighScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenHighScoresForm();
        }
    }
}

