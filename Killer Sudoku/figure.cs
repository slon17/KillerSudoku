using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class Figure
    {
        private ArraySegment<Cell> cells;
        private int operation;
        private int operationResult;
        private int idFigure;

        public Figure(int operation, int idFigure)
        {
            cells = new ArraySegment<Cell>();
            this.operation = operation;
            operationResult = int.MaxValue;
            this.idFigure = idFigure;
        }
    }
}
