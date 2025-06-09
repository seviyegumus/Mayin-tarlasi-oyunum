namespace silbaştanmayin
{
    partial class Form1
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
            tableLayoutPanel1 = new TableLayoutPanel();
            lblTime = new Label();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
           
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Location = new Point(3, 47);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new Size(500, 500);
            tableLayoutPanel1.TabIndex = 0;
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Microsoft Sans Serif", 12F);
            lblTime.Location = new Point(71, 9);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(62, 25);
            lblTime.TabIndex = 1;
            lblTime.Text = "00:00";
            lblTime.Click += lblTime_Click;
           
            label1.AutoSize = true;
            label1.Location = new Point(20, 9);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 2;
            label1.Text = "Süre: ";
           
            label2.AutoSize = true;
            label2.Location = new Point(165, 14);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 3;
            label2.Text = "Hamle sayısı :";
            label2.Click += label2_Click;
           
            ClientSize = new Size(800, 600);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblTime);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Mayın Tarlası";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void lblTime_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTime;
        private Label label1;
        private Label label2;
    }
}
