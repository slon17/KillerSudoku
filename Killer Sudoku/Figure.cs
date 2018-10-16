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
        private bool isBusy;

        public Figure(int operation)
        {
            cells = new List<Cell>();
            this.operation = operation;
            operationResult = int.MaxValue;
            isBusy = false;
        }

        public List<Cell> getCells()
        {
            return cells;
        }

        public void setIdFigure(int idFigure)
        {
            this.idFigure = idFigure;
        }

        public int getSumValue()
        {
            int value = 0;
            for(int i = 0; i<cells.Count(); i++)
            {
                value += cells.ElementAt(i).getNumber();
            }
            operation = 0;
            operationResult = value;
            return value;
        }

        public int getMultValue()
        {
            int value = 0;
            for (int i = 0; i < cells.Count(); i++)
            {
                value = value * cells.ElementAt(i).getNumber();
            }
            operation = 1;
            operationResult = value;
            return value;
        }

        public bool notFull()
        {
            for(int i=0; i<cells.Count(); i++)
            {
                if(cells.ElementAt(i).getNumberBT() == -1)
                {
                    return true;
                }
            }
            return false;
        }

        public void setIsBusy(bool isBusy)
        {
            this.isBusy = isBusy;
        }

        public bool getIsBusy()
        {
            return isBusy;
        }

        public Cell getAvailableCell()
        {
            for(int i = 0; i < cells.Count(); i++)
            {
                if(cells.ElementAt(i).getNumberBT() == -1)
                {
                    return cells.ElementAt(i);
                }
            }
            return null;
        }

        public int getOperation()
        {
            return operation;
        }

        public int getOperationResult()
        {
            return operationResult;
        }
    }
}
