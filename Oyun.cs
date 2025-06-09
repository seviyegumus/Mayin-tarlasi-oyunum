using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace SilbastanMayin
{
    public class Oyun
    {
        public int GridSize { get; set; }        
        public int MineCount { get; set; }       
        public ArrayList Mayinlar { get; set; }  
        public int FlaggedMines { get; set; }    
        public bool GameEnded { get; set; }      
        public int Gpuan { get; set; }           
        public Button[,] Field { get; set; }     

        public Oyun(int gridSize, int mineCount)
        {
            GridSize = gridSize;
            MineCount = mineCount;
            Mayinlar = new ArrayList();
            Field = new Button[GridSize, GridSize];
            FlaggedMines = 0;
            GameEnded = false;
            Gpuan = 0;
        }

        public void CreateField()
        {
            int oTarla = GridSize * GridSize; 
            Random rast = new Random();
            int sayi;

            Mayinlar.Clear();

            for (int i = 0; i < MineCount; i++)
            {
            uret:
                sayi = rast.Next(0, oTarla);
                if (Mayinlar.Contains(sayi))  
                {
                    goto uret;
                }
                else
                {
                    Mayinlar.Add(sayi);
                }
            }

            CalculateNeighborMines();
        }

        public void CalculateNeighborMines()
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    if (Field[i, j].Tag.Equals(-1)) continue; 

                    int mineCount = 0;

                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            int newRow = i + x;
                            int newCol = j + y;

                            if (newRow >= 0 && newRow < GridSize && newCol >= 0 && newCol < GridSize)
                            {
                                if (Field[newRow, newCol].Tag.Equals(-1))
                                {
                                    mineCount++; 
                                }
                            }
                        }
                    }
                    Field[i, j].Tag = mineCount; 
                }
            }
        }

        public void ButtonClick(Button button)
        {
            if (GameEnded) return; 

            if (int.Parse(button.Tag.ToString()) == -1)  
            {
                button.BackgroundImage = Image.FromFile("mayin.png");
                button.BackColor = Color.Red;
                GameEnded = true;
                
                for (int i = 0; i < GridSize; i++)
                {
                    for (int j = 0; j < GridSize; j++)
                    {
                        Field[i, j].Enabled = false;
                        if (int.Parse(Field[i, j].Tag.ToString()) == -1)
                        {
                            Field[i, j].BackgroundImage = Image.FromFile("mayin.png");
                        }
                        else
                        {
                            Field[i, j].Text = Field[i, j].Tag.ToString();
                        }
                    }
                }
            }
            else
            {
                if (button.Text == "")
                {
                    Gpuan += int.Parse(button.Tag.ToString());
                    button.Text = button.Tag.ToString();

                    if (int.Parse(button.Tag.ToString()) == 0)
                    {
                        OpenAdjacentCells(button);
                    }
                }
            }
        }

        private void OpenAdjacentCells(Button button)
        {
            int row = Array.IndexOf(Field, button) / GridSize;
            int col = Array.IndexOf(Field, button) % GridSize;

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int newRow = row + x;
                    int newCol = col + y;

                    if (newRow >= 0 && newRow < GridSize && newCol >= 0 && newCol < GridSize)
                    {
                        Button neighborButton = Field[newRow, newCol];
                        if (neighborButton.Text == "" && neighborButton.BackgroundImage == null) 
                        {
                            neighborButton.Text = neighborButton.Tag.ToString(); 
                            if (neighborButton.Tag.ToString() == "0") 
                            {
                                OpenAdjacentCells(neighborButton); 
                            }
                        }
                    }
                }
            }
        }

        public void PlaceFlag(Button button)
        {
            if (button.Text == "") 
            {
                if (button.BackgroundImage == null) 
                {
                    if (FlaggedMines < MineCount) 
                    {
                        button.BackgroundImage = Image.FromFile("bayrak.png");
                        FlaggedMines++;
                    }
                }
                else
                {
                    button.BackgroundImage = null;
                    FlaggedMines--;
                }
            }
        }

        public bool CheckWin()
        {
            if (FlaggedMines == MineCount)
            {
                foreach (var btn in Field)
                {
                    Button button = (Button)btn;
                    if (button.Tag.Equals(-1) && button.BackgroundImage == null)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
