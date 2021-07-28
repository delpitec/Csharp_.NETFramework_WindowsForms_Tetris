using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.Forms;

namespace Tetris
{
    public partial class formEditName : Form
    {
        private formPlay formPBridge;

        public formEditName(formPlay formP)
        {
            formPBridge = formP;
            InitializeComponent();

            this.TextBoxName.Text = formP.boardGame.BackBoardGame.PlayerName;

            // Select text (back blue)
            this.TextBoxName.Focus();
            this.TextBoxName.SelectAll();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            formPBridge.boardGame.BackBoardGame.PlayerName = this.TextBoxName.Text;
            formPBridge.timer1.Enabled = true;
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            formPBridge.timer1.Enabled = true;
            this.Close();
        }

        private void formEditName_FormClosing(object sender, FormClosingEventArgs e)
        {
            formPBridge.timer1.Enabled = true;
        }

 
    }
}
