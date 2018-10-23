using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public void resolve(Board board)
        {
            //Console.WriteLine(Thread.CurrentThread.Name);
            Random random = new Random();
            board.asignDots();
            if (board.getIsOver() == true) { 
                return;
            }
            if (board.isFull() == true /*&& board.isEqual()*/)
            {
                Console.WriteLine("end");
                Console.WriteLine("entro");
                board.printBoardBT();
                board.setIsOver(true);
                return;
            }
            else
            {
                Figure figure = null;
                for (int i = 0; i < board.getFigures().Count(); i++)
                {
                    figure = board.getFigures().ElementAt(i);
                    if (figure.getIdFigure() != 23)
                    {
                        if (figure.notFull() && figure.getIsBusy() == false)
                        {
                            figure.setIsBusy(true);
                            break;
                        }
                    }
                    
                }

                Cell cell = null;
                bool isLastCell = false;


                for (int j = 0; j < figure.getCells().Count(); j++)
                {
                    if (figure.getCells().ElementAt(j).getNumberBT() == -1)
                    {
                        cell = figure.getCells().ElementAt(j);
                        if (j + 1 == figure.getCells().Count())
                        {
                            isLastCell = true;
                        }
                        break;
                    }
                }

                List<int> possibles = possibleNumbers(cell.getCoordenate().getX(), cell.getCoordenate().getY(), figure, isLastCell);
                for (int p = 0; p < possibles.Count(); p++)
                {

                    if (possibles[p] != -1)
                    {
                        //Console.WriteLine("Numero escogido " + possibleNum+"en x "+cell.getCoordenate().getX()+ " en y "+ cell.getCoordenate().getY());
                        cell.setNumberBT(possibles[p]);
                        figure.setIsBusy(false);
                        //board.printBoardBT();
                        
                        resolve(board);
                    }
                    else
                    {
                        //Console.WriteLine(possibles[possibles.Count()-1]);
                    }

                }
                //board.printBoardBT();

                cell.setNumberBT(-1);
                figure.setIsBusy(false);
            }
        }

        public List<int> possibleNumbers(int i, int j, Figure figure, bool isLastCell)
        {
            List<int> possibleNumbers = generatePossibleNumbers();
            bool bandera = true;
            if (figure.getCells().Count() == 1)
            {
                /*if (possibleNumbers.Contains(figure.getOperationResult()))
                {
                    possibleNumbers.Clear();
                    possibleNumbers.Add(figure.getOperationResult());
                    possibleNumbers.Add(-1);
                    Console.WriteLine("operation result: " + figure.getOperationResult() + " possible number[0] " + possibleNumbers[0]);
                    bandera = false;
                }*/
                
                
            }
            if(bandera) {
                for (int k = 0; k < board.getSize(); k++)
                {

                    if (isInPossible(possibleNumbers, board.getCells()[k][j].getNumberBT()) && board.getCells()[k][j].getNumberBT() != -1)
                    {
                        //deletePossibleNumber(possibleNumbers, board.getCells()[k][j].getNumberBT());
                        possibleNumbers.Remove(board.getCells()[k][j].getNumberBT());
                        //printPossible(possibleNumbers);
                    }
                    if (isInPossible(possibleNumbers, board.getCells()[i][k].getNumberBT()) && board.getCells()[i][k].getNumberBT() != -1)
                    {
                        //deletePossibleNumber(possibleNumbers, board.getCells()[i][k].getNumberBT());
                        possibleNumbers.Remove(board.getCells()[i][k].getNumberBT());
                        //printPossible(possibleNumbers);
                    }
                }
                
                int partialTotal = operate(figure.getCells(), figure.getOperation());
                for (int k = 0; k < possibleNumbers.Count(); k++)
                {
                    if (possibleNumbers[k] != -1)
                    {
                        if (figure.getOperation() == 0)
                        {
                            //Console.WriteLine("entro suma");
                            if (isLastCell)
                            {
                                //Console.WriteLine("operation result " + figure.getOperationResult() + " figure result " + partialTotal + possibleNumbers[k]);
                                if (partialTotal + possibleNumbers[k] != figure.getOperationResult())
                                {
                                    
                                    deletePossibleNumber(possibleNumbers, possibleNumbers[k]);
                                }
                            }
                            else
                            {
                                if (partialTotal + possibleNumbers[k] >= figure.getOperationResult())
                                {
                                    deletePossibleNumber(possibleNumbers, possibleNumbers[k]);
                                }
                            }
                        }
                        else if (figure.getOperation() == 1)
                        {
                            //Console.WriteLine(figure.getOperationResult());
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
                }
                
            }
            //printPossible(possibleNumbers);
            return possibleNumbers;
        }

        public void printPossible(List<int> possible)
        {
            String str = " ";
            for(int i=0; i<possible.Count(); i++)
            {
                str += possible.ElementAt(i)+" ";
            }
            //Console.WriteLine("Borrados ");
            //Console.WriteLine(str);
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
