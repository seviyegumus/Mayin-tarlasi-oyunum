using System;
using System.Windows.Forms;

namespace silbaştanmayin
{
    public partial class FormScoreBoard : Form
    {
        public FormScoreBoard(double score)
        {
            InitializeComponent();

            lblScore.Text = $"Skor: {((int)score)}"; 
        }
    }
}
