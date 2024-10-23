using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Windows.Forms;

namespace Mindsweeper
{
    public class Controller
    {
        private Model model;
        private Form1 view;

        public Controller(Form1 view)
        {
            this.view = view;
            model = new Model();
        }


        public void OnCellClicked(int row, int col)
        {
            int cellValue = model.GetCell(row, col);
            if (cellValue == 1)
            {
                view.GameOver(row, col);
            }
            else
            {
                view.RevealCell(row, col);
            }
        }
            
        public int MineProximity(int row, int col)
        {
            return model.MineProximity(row, col);
        }


        public int GetCell(int row, int col)
        {
            return model.GetCell(row, col);
        }

    }
}

