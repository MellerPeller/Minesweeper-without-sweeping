using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mindsweeper
    {
        public class Model
        {
            private int[,] board; 
            private const int rows = Form1.GridSize;
            private const int cols = Form1.GridSize;
            private Random random = new Random();

            public Model()
            {
                board = new int[rows, cols];
                InitializeBoard();
            }

            private void InitializeBoard()
            {
                
                for (int i = 0; i < Form1.GridSize; i++) 
                {
                    int row, col;
                    do
                    {
                        row = random.Next(rows);
                        col = random.Next(cols);
                    } while (board[row, col] == 1); 
                    board[row, col] = 1; 
                }
            }
            
            public int GetCell(int row, int col)
            {
                return board[row, col]; 
            }

             public int MineProximity(int row, int col)
             {
                int mineCount = 0;

                for (int i = row - 1; i <= row + 1; i++)
                {
                    for (int j = col - 1; j <= col + 1; j++)
                    {
                        if (!(i == row && j == col) && i >= 0 && i < Form1.GridSize && j >= 0 && j < Form1.GridSize)
                        {
                            if (GetCell(i, j) == 1)
                            {
                                mineCount++;
                            }
                        }
                    }
                }
                return mineCount;
             }

    }
    }

