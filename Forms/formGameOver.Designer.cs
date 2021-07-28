
namespace Tetris.Forms
{
    partial class formGameOver
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelGameOverMsg = new System.Windows.Forms.Label();
            this.LabelGameOverScore = new System.Windows.Forms.Label();
            this.ButtonYes = new System.Windows.Forms.Button();
            this.ButtonNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelGameOverMsg
            // 
            this.LabelGameOverMsg.AutoSize = true;
            this.LabelGameOverMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGameOverMsg.Location = new System.Drawing.Point(60, 96);
            this.LabelGameOverMsg.Name = "LabelGameOverMsg";
            this.LabelGameOverMsg.Size = new System.Drawing.Size(397, 64);
            this.LabelGameOverMsg.TabIndex = 0;
            this.LabelGameOverMsg.Text = "< Game over message row 1 >\r\n< Game over message row 2 >";
            // 
            // LabelGameOverScore
            // 
            this.LabelGameOverScore.AutoSize = true;
            this.LabelGameOverScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGameOverScore.Location = new System.Drawing.Point(97, 25);
            this.LabelGameOverScore.Name = "LabelGameOverScore";
            this.LabelGameOverScore.Size = new System.Drawing.Size(342, 32);
            this.LabelGameOverScore.TabIndex = 1;
            this.LabelGameOverScore.Text = "< Game over pontuation >";
            // 
            // ButtonYes
            // 
            this.ButtonYes.Location = new System.Drawing.Point(33, 239);
            this.ButtonYes.Name = "ButtonYes";
            this.ButtonYes.Size = new System.Drawing.Size(136, 71);
            this.ButtonYes.TabIndex = 2;
            this.ButtonYes.Text = "Yes";
            this.ButtonYes.UseVisualStyleBackColor = true;
            this.ButtonYes.Click += new System.EventHandler(this.ButtonYes_Click);
            // 
            // ButtonNo
            // 
            this.ButtonNo.Location = new System.Drawing.Point(187, 239);
            this.ButtonNo.Name = "ButtonNo";
            this.ButtonNo.Size = new System.Drawing.Size(136, 71);
            this.ButtonNo.TabIndex = 3;
            this.ButtonNo.Text = "No";
            this.ButtonNo.UseVisualStyleBackColor = true;
            this.ButtonNo.Click += new System.EventHandler(this.ButtonNo_Click);
            // 
            // formGameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 342);
            this.Controls.Add(this.ButtonNo);
            this.Controls.Add(this.ButtonYes);
            this.Controls.Add(this.LabelGameOverScore);
            this.Controls.Add(this.LabelGameOverMsg);
            this.Name = "formGameOver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Over";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelGameOverMsg;
        private System.Windows.Forms.Label LabelGameOverScore;
        private System.Windows.Forms.Button ButtonYes;
        private System.Windows.Forms.Button ButtonNo;
    }
}