namespace silbaştanmayin
{
    partial class FormScoreBoard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblScore = new Label();
            SuspendLayout();
            
            lblScore.AutoSize = true;
            lblScore.BackColor = Color.Transparent;
            lblScore.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblScore.ForeColor = SystemColors.ButtonHighlight;
            lblScore.Location = new Point(120, 51);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(100, 31);
            lblScore.TabIndex = 0;
            lblScore.Text = "Skor: 0";
            
            BackColor = SystemColors.ButtonHighlight;
            BackgroundImage = Properties.Resources.gameover2;
            ClientSize = new Size(348, 251);
            Controls.Add(lblScore);
            Name = "FormScoreBoard";
            Text = "Skor Tablosu";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblScore;
    }
}
