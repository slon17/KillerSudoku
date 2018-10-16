using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class Backtracking
    {
        Board board;

        public Backtracking(Board board)
        {
            this.board = board;
        }

        public Board resolve(Board board)
        {
            //Console.WriteLine("entro");
            Random random = new Random();
            if(board.isFull() == true)
            {
                board.printBoardBT();
                return board;
            }
            else
            {
                Figure figure = null;
                for (int i=0; i< board.getFigures().Count(); i++)
                {
                    figure = board.getFigures().ElementAt(i);
                    if (figure.notFull() && figure.getIsBusy() == false)
                    {
                        Cell cell = null;
                        bool isLastCell = false;
                        figure.setIsBusy(true);
                        
                        for(int j=0; j<figure.getCells().Count(); j++)
                        {
                            if(figure.getCells().ElementAt(j).getNumberBT() == -1)
                            {
                                cell = figure.getCells().ElementAt(j);
                                if (j + 1 == figure.getCells().Count())
                                {
                                    isLastCell = true;
                                }
                                break;
                            }
                        }
                        List<int> possibles = possibleNumbers(cell.getCoordenate().getY(), cell.getCoordenate().getX(), figure, isLastCell);
                        if(possibles.Count() > 1)
                        {
                            int possibleNum = possibles.ElementAt(random.Next(possibles.Count() - 1));
                            cell.setNumberBT(possibleNum);
                            figure.setIsBusy(false);
                            board.printBoardBT();
                            resolve(board);
                        }
                        cell.setNumberBT(-1);
                        figure.setIsBusy(false);
                    }
                }

            }
            return board;
        }

        public List<int> possibleNumbers(int i, int j, Figure figure, bool isLastCell)
        {
            List<int> possibleNumbers = generatePossibleNumbers();
            for(int k=0; k<board.getSize(); k++)
            {
                
                if(isInPossible(possibleNumbers, board.getCells()[k][j].getNumberBT()) && board.getCells()[k][j].getNumberBT() != -1)
                {
                    //Console.WriteLine("borro columna " + possibleNumbers.Count()+ " numero borrado" + board.getCells()[k][j].getNumberBT());
                    deletePossibleNumber(possibleNumbers, board.getCells()[k][j].getNumberBT());
                    printPossible(possibleNumbers);
                }
                if (isInPossible(possibleNumbers, board.getCells()[i][k].getNumberBT()) && board.getCells()[i][k].getNumberBT() != -1)
                {
                    //Console.WriteLine("borro fila " + possibleNumbers.Count()+" numero borrado" + board.getCells()[i][k].getNumberBT());
                    deletePossibleNumber(possibleNumbers, board.getCells()[i][k].getNumberBT());
                    printPossible(possibleNumbers);
                }
            }
            /*
            int partialTotal = operate(figure.getCells(), figure.getOperation());
            for(int k=0; k<possibleNumbers.Count(); k++)
            {
                if (possibleNumbers[k] != -1)
                {
                    if(figure.getOperation() == 0)
                    {
                        if (isLastCell)
                        {
                            if(partialTotal+possibleNumbers[k] != figure.getOperationResult())
                            {
                                deletePossibleNumber(possibleNumbers, possibleNumbers[k]);
                            }
                        }
                        else
                        {
                            if(partialTotal+possibleNumbers[k] >= figure.getOperationResult())
                            {
                                deletePossibleNumber(possibleNumbers, possibleNumbers[k]);
                            }
                        }
                    }
                    else if(figure.getOperation() == 1)
                    {
                        if (isLastCell)
                        {
                            if (partialTotal * possibleNumbers[k] != figure.getOperationResult())
                            {
                                deletePossibleNumber(possibleNumbers, possibleNumbers[k]);
                            }
                        }
                        else
                        {
                            if (partialTotal * possibleNumbers[k] > figure.getOperationResult())
                            {
                                deletePossibleNumber(possibleNumbers, possibleNumbers[k]);
                            }
                        }
                    }
                }
            }*/
            return possibleNumbers;
        }

        public void printPossible(List<int> possible)
        {
            String str = " ";
            for(int i=0; i<possible.Count(); i++)
            {
                str += possible.ElementAt(i)+" ";
            }
            Console.WriteLine(str);
        }

        public int operate(List<Cell> cells, int operation)
        {
            int partialTotal = 0;

            if(operation == 0)
            {
                partialTotal = 0;
            }
            else if(operation == 1)
            {
                partialTotal = 1;
            }

            for(int i=0; i<cells.Count(); i++)
            {
                if(cells[i].getNumberBT() != -1)
                {
                    if(operation == 0)
                    {
                        partialTotal += cells[i].getNumberBT();
                    }
                    else if(operation == 1)
                    {
                        partialTotal = partialTotal * cells[i].getNumberBT();
                    }
                }
            }
            return partialTotal;
        }

        public List<int> generatePossibleNumbers()
        {
            List<int> possibleNumbers = new List<int>();
            for(int i=0; i<board.getSize(); i++)
            {
                possibleNumbers.Add(i+1);
            }
            possibleNumbers.Add(-1);
            return possibleNumbers;
        }

        public bool isInPossible(List<int> possibleNumbers, int number)
        {
            if (possibleNumbers.Contains(number))
            {
                return true;
            }
            return false;
        }

        public void deletePossibleNumber(List<int> possibleNumbers, int number)
        {
            possibleNumbers.Remove(number);
        }
    }
}
