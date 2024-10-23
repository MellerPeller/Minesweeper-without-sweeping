using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mindsweeper
{
    public partial class Form1 : Form
    {   
        public const int GridSize = 10;
        private PictureBox[,] pictureBoxes = new PictureBox[GridSize, GridSize];
        private Controller controller;
        private int score = 0;
        
        public Form1()
        {
            InitializeComponent();
            controller = new Controller(this);
            InitializeBoard();
            timer1.Start();
        }

        private void InitializeBoard()
        {
            for (int row = 0; row < GridSize; row++) // Loop through rows
            {
                for (int col = 0; col < GridSize; col++) // Loop through columns
                {
                    // Create and configure a new PictureBox
                    pictureBoxes[row, col] = new PictureBox
                    {
                        Size = new Size(50, 50),
                        Location = new Point(col * 50, row * 50 + 50),
                        Image = Properties.Resources.HiddenTile,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BorderStyle = BorderStyle.FixedSingle,
                        Tag = new Point(row, col)
                    };

                    pictureBoxes[row, col].Click += new EventHandler(PictureBox_Click);

                    this.Controls.Add(pictureBoxes[row, col]);
                }
            }

            this.ClientSize = new Size(300, 350);
            this.Text = "Minesweeper";
            label1.Text = $"0{GridSize}";
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;
            Point position = (Point)clickedPictureBox.Tag; 
            int row = position.X;
            int col = position.Y;

            
            controller.OnCellClicked(row, col);
        }

        public void GameOver(int row, int col)
        {
            RevealAll();
            pictureBoxes[row, col].Image = Properties.Resources.BombClickedTile;
            MessageBox.Show("You lost! :(");
        }


        public void RevealCell(int row, int col)
        {
            int adjacentMinesAmount = controller.MineProximity(row, col);
            label1.Text = adjacentMinesAmount.ToString();

                if (adjacentMinesAmount == 0)
                {
                    pictureBoxes[row, col].Image = Properties.Resources.RevealTile;
                }
                else if (adjacentMinesAmount == 1)
                {  
                    pictureBoxes[row, col].Image = Properties.Resources.OneTile;
                }
                else if(adjacentMinesAmount == 2)
                {
                    pictureBoxes[row, col].Image = Properties.Resources.TwoTile;
                }
                else if (adjacentMinesAmount == 3)
                {
                    pictureBoxes[row, col].Image = Properties.Resources.ThreeTile;
                }
                else if (adjacentMinesAmount == 4)
                {
                    pictureBoxes[row, col].Image = Properties.Resources.FourTile;
                }
                else if (adjacentMinesAmount == 5)
                {
                    pictureBoxes[row, col].Image = Properties.Resources.FiveTile;
                }
                else if (adjacentMinesAmount == 6)
                {
                    pictureBoxes[row, col].Image = Properties.Resources.SixTile;
                }
                else if (adjacentMinesAmount == 7)
                {
                    pictureBoxes[row, col].Image = Properties.Resources.SevenTile;
                }
                else if (adjacentMinesAmount == 8)
                {
                    pictureBoxes[row, col].Image = Properties.Resources.EightTile;
                } 
        }

        public void RevealAll()
        {
            timer1.Stop();

            for (int row = 0; row < GridSize; row++)
            {
                for (int col = 0; col < GridSize; col++)
                {

                    if (controller.GetCell(row, col) == 1)
                    {
                        pictureBoxes[row, col].Image = Properties.Resources.BombRevealTile;
                    }
                    else
                    {
                        pictureBoxes[row, col].Image = Properties.Resources.RevealTile;
                    }
                }

            }
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {

            score++;

            if (score.ToString().Length == 1)
            {
                label2.Text = "00" + score;
            }
            else if (score.ToString().Length == 2)
            {
                label2.Text = "0" + score;
            }
            else
            {
                label2.Text = score.ToString();
            }

            if (score == 999)
            {
                
                RevealAll();
                MessageBox.Show("Tiden gick slut på något sätt .o.  Omöjligt att du inte hittade alla bomber på 999 sekunder");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
