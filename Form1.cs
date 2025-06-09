using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace silbaştanmayin
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer;
        private int hamlesayisi;  

        private int gridSize;    
        private int mineCount;   
        private ArrayList mayinlar = new ArrayList();  
        private int totalCells; 
        private int openedCells; 
        private int flaggedMines; 
        private bool gameEnded; 

        public Form1(int size, int mines)
        {
            InitializeComponent();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; 
            timer.Tick += Timer_Tick;
            timer.Start();

            gridSize = size;
            mineCount = mines;
            totalCells = gridSize * gridSize;
            openedCells = 0;
            flaggedMines = 0;
            gameEnded = false;
            hamlesayisi = 0;  
        }

        private int seconds = 0; 

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (gameEnded)
            {
                timer.Stop(); 
                return;
            }

            seconds++;  
            lblTime.Text = seconds.ToString();  
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = $"Hamle Sayısı: {hamlesayisi}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoScroll = false;
            this.HorizontalScroll.Enabled = false;
            this.VerticalScroll.Enabled = false;

            tableLayoutPanel1.ColumnCount = gridSize;
            tableLayoutPanel1.RowCount = gridSize;

            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            for (int i = 0; i < gridSize; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30f));  
            }

            for (int i = 0; i < gridSize; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));  
            }

            this.ClientSize = new Size(32 * gridSize + 7, 32 * gridSize + 50);  

            tableLayoutPanel1.Size = new Size(32 * gridSize, 32 * gridSize);

            CreateField(mineCount);
        }

        private void CreateField(int oMayin)
        {
            int oTarla = gridSize * gridSize;
            mayinlar.Clear();
            Random rast = new Random();
            int sayi;

            for (int i = 0; i < oMayin; i++)
            {
            uret:
                sayi = rast.Next(0, oTarla);
                if (mayinlar.Contains(sayi))
                {
                    goto uret;
                }
                else
                {
                    mayinlar.Add(sayi);
                }
            }

            for (int i = 0; i < oTarla; i++)
            {
                Button button = new Button();
                button.Size = new Size(30, 30);
                button.Tag = mayinlar.Contains(i) ? -1 : 0; 
                button.Click += button_Click;
                button.MouseDown += button_MouseDown;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                button.Text = "";  
                button.Enabled = true;

                button.BackColor = Color.LightGray;  
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0; 

                tableLayoutPanel1.Controls.Add(button);
            }

            CalculateNeighborMines(); 
        }

        private void CalculateNeighborMines()
        {
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                Button button = (Button)tableLayoutPanel1.Controls[i];
                if (button.Tag.Equals(-1)) continue; 

                int mineCount = 0;
                int row = i / gridSize;
                int col = i % gridSize;

                for (int j = -1; j <= 1; j++)
                {
                    for (int k = -1; k <= 1; k++)
                    {
                        if (j == 0 && k == 0) continue;
                        int neighborRow = row + j;
                        int neighborCol = col + k;
                        if (neighborRow >= 0 && neighborRow < gridSize && neighborCol >= 0 && neighborCol < gridSize)
                        {
                            int neighborIndex = neighborRow * gridSize + neighborCol;
                            Button neighborButton = (Button)tableLayoutPanel1.Controls[neighborIndex];
                            if (neighborButton.Tag.Equals(-1)) mineCount++;  
                        }
                    }
                }

                button.Tag = mineCount;
                if (mineCount > 0)
                {
                    button.Text = "";  
                }
            }
        }

        private void button_Click(object? sender, EventArgs e)
        {
            hamlesayisi++; 
            label2.Text = $"Hamle Sayısı: {hamlesayisi}";  

            if (gameEnded) return;

            Button clickedButton = (Button)sender;

            if (clickedButton.BackgroundImage != null && clickedButton.BackgroundImage.Tag == "bayrak")
            {
                return;  
            }

            if (int.Parse(clickedButton.Tag.ToString()) == -1)
            {
                clickedButton.BackgroundImage = Image.FromFile("mayin.png");
                clickedButton.BackColor = Color.Red;

                gameEnded = true;
                timer.Stop();

                for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
                {
                    tableLayoutPanel1.Controls[i].Enabled = false;
                    if (int.Parse(tableLayoutPanel1.Controls[i].Tag.ToString()) == -1)
                    {
                        tableLayoutPanel1.Controls[i].BackgroundImage = Image.FromFile("mayin.png");
                    }
                    else
                    {
                        tableLayoutPanel1.Controls[i].Text = tableLayoutPanel1.Controls[i].Tag.ToString();
                    }
                }

                double score = (flaggedMines / (double)seconds) * 1000;
                FormScoreBoard scoreBoardForm = new FormScoreBoard(score);
                scoreBoardForm.Show();

                this.Hide();
            }
            else
            {
                if (clickedButton.Text == "")
                {
                    clickedButton.Text = clickedButton.Tag.ToString();
                    openedCells++;

                    if (clickedButton.Tag.ToString() == "0")
                    {
                        OpenAdjacentCells(clickedButton);
                    }

                    CheckForWin();
                }
            }
        }

        private void OpenAdjacentCells(Button button)
        {
            int index = tableLayoutPanel1.Controls.IndexOf(button);
            int row = index / gridSize;
            int col = index % gridSize;

            for (int j = -1; j <= 1; j++)
            {
                for (int k = -1; k <= 1; k++)
                {
                    if (j == 0 && k == 0) continue;
                    int neighborRow = row + j;
                    int neighborCol = col + k;
                    if (neighborRow >= 0 && neighborRow < gridSize &&
                        neighborCol >= 0 && neighborCol < gridSize)
                    {
                        Button neighborButton = (Button)tableLayoutPanel1.GetControlFromPosition(neighborCol, neighborRow);
                        if (neighborButton.Text == "" && neighborButton.BackgroundImage == null)
                        {
                            neighborButton.Text = neighborButton.Tag.ToString();
                            openedCells++;
                            if (neighborButton.Tag.ToString() == "0")
                            {
                                OpenAdjacentCells(neighborButton);
                            }
                        }
                    }
                }
            }
        }

        private void CheckForWin()
        {
            if (openedCells == totalCells - mineCount && flaggedMines == mineCount)
            {
                MessageBox.Show("Oyunu Kazandınız!");
                DisableAllButtons();
                gameEnded = true;
            }
        }

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button clickedButton = (Button)sender;
                if (clickedButton.Text == "")
                {
                    if (clickedButton.BackgroundImage == null)
                    {
                        clickedButton.BackgroundImage = Image.FromFile("bayrak.png");
                        clickedButton.BackgroundImage.Tag = "bayrak";
                        flaggedMines++;
                    }
                    else
                    {
                        clickedButton.BackgroundImage = null;
                        flaggedMines--;
                    }
                }
            }
        }

        private void DisableAllButtons()
        {
            foreach (Button btn in tableLayoutPanel1.Controls)
            {
                btn.Enabled = false;
            }
        }
    }
}
