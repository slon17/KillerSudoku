using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class Figure
    {
        private List<Cell> cells;
        private int operation;
        private int operationResult;
        private int idFigure;

        public Figure(int operation)
        {
            cells = new List<Cell>();
            this.operation = operation;
            operationResult = int.MaxValue;
        }

        public List<Cell> getCells()
        {
            return cells;
        }

        public void setIdFigure(int idFigure)
        {
            this.idFigure = idFigure;
        }
    }
}
