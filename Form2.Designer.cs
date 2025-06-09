namespace silbaştanmayin
{
    partial class Form2
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            textBoxName = new TextBox();
            label2 = new Label();
            numericUpDownGridSize = new NumericUpDown();
            label3 = new Label();
            numericUpDownMines = new NumericUpDown();
            buttonStartGame = new Button();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownGridSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMines).BeginInit();
            SuspendLayout();
            
            label1.AutoSize = true;
            label1.BackColor = Color.Yellow;
            label1.Location = new Point(221, 27);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 0;
            label1.Text = "Kullanıcı Adı:";
             
            textBoxName.BackColor = Color.PeachPuff;
            textBoxName.Location = new Point(338, 27);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(140, 27);
            textBoxName.TabIndex = 1;
             
            label2.AutoSize = true;
            label2.BackColor = Color.Red;
            label2.Location = new Point(170, 75);
            label2.Name = "label2";
            label2.Size = new Size(146, 20);
            label2.TabIndex = 2;
            label2.Text = "Grid Boyutu (10-30): ";
            
            numericUpDownGridSize.BackColor = Color.PeachPuff;
            numericUpDownGridSize.Location = new Point(338, 73);
            numericUpDownGridSize.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownGridSize.Name = "numericUpDownGridSize";
            numericUpDownGridSize.Size = new Size(94, 27);
            numericUpDownGridSize.TabIndex = 3;
            numericUpDownGridSize.Value = new decimal(new int[] { 10, 0, 0, 0 });
            
            label3.AutoSize = true;
            label3.BackColor = Color.Chartreuse;
            label3.Location = new Point(219, 125);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 4;
            label3.Text = "Mayın Sayısı: ";
             
            numericUpDownMines.BackColor = Color.PeachPuff;
            numericUpDownMines.Location = new Point(338, 123);
            numericUpDownMines.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownMines.Name = "numericUpDownMines";
            numericUpDownMines.Size = new Size(94, 27);
            numericUpDownMines.TabIndex = 5;
            numericUpDownMines.Value = new decimal(new int[] { 10, 0, 0, 0 });
             
            buttonStartGame.BackColor = Color.MediumOrchid;
            buttonStartGame.Location = new Point(262, 193);
            buttonStartGame.Name = "buttonStartGame";
            buttonStartGame.Size = new Size(140, 30);
            buttonStartGame.TabIndex = 6;
            buttonStartGame.Text = "Oyuna Başla";
            buttonStartGame.UseVisualStyleBackColor = false;
            buttonStartGame.Click += buttonStartGame_Click;
            
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(3, 462);
            label4.Name = "label4";
            label4.Size = new Size(176, 20);
            label4.TabIndex = 7;
            label4.Text = "Seviye Gümüş 220229061";
            
            BackgroundImage = silbaştanmayin.Properties.Resources.a1;
            ClientSize = new Size(720, 491);
            Controls.Add(label4);
            Controls.Add(buttonStartGame);
            Controls.Add(numericUpDownMines);
            Controls.Add(label3);
            Controls.Add(numericUpDownGridSize);
            Controls.Add(label2);
            Controls.Add(textBoxName);
            Controls.Add(label1);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mayın Tarlası - Başlangıç";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownGridSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMines).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownGridSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownMines;
        private System.Windows.Forms.Button buttonStartGame;
        private object Properties;
        private Label label4;
    }
}