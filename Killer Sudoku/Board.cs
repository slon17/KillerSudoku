using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Killer_Sudoku
{
    class Board
    {
        private ArrayList cells;
        private ArraySegment<Figure> figures;
        private ArraySegment<Sector> sectors;
        private int size;

        public Board(int size)
        {
            cells = generateCells(size);
            this.size = size;
        }

        public ArrayList generateCells(int size)
        {
            ArrayList newMatrix = new ArrayList();
            for (int i = 0; i < size; i++)
            {
                ArrayList newRow = new ArrayList();
                for (int j = 0; j < size; j++)
                {
                    Cell newCell = new Cell(j, i, true);
                    newRow.Add(newCell);
                }
                newMatrix.Add(newRow);
            }
            return newMatrix;
        }
    }

    
}
