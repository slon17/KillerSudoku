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
        private List<List<Cell>> cells;
        private List<Figure> figures;
        private ArrayList sectors;
        private ShapeDictionary shapeDictionary;
        private int size;

        public Board(int size)
        {
            cells = generateCells(size);
            shapeDictionary = new ShapeDictionary();
            this.size = size;
            figures = new List<Figure>();
        }

        public List<List<Cell>> generateCells(int size)
        {
            List<List<Cell>> newMatrix = new List<List<Cell>>();
            for (int i = 0; i < size; i++)
            {
                List<Cell> newRow = new List<Cell>();
                for (int j = 0; j < size; j++)
                {
                    Cell newCell = new Cell(j, i, true, size);
                    newRow.Add(newCell);
                }
                newMatrix.Add(newRow);
            }
            return newMatrix;
        }

        public void generateFigures()
        {
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //Console.WriteLine(j);
                    if (cells[i][j].getIsAvailable())
                    {
                        Shape randomShape = shapeDictionary.getRandomShape();
                        if (shapeDictionary.getShapes().Count() == 0)
                        {
                            //Console.WriteLine("entro");
                            shapeDictionary.getShapes().Add(shapeDictionary.generateFigDot());
                            randomShape = shapeDictionary.getShapes()[0];
                        }
                        if (j + randomShape.getWidth()-1 < size && i + randomShape.getHeight()-1 < size)
                        {
                            Figure newFigure = new Figure(0);
                            for (int k = 0; k < randomShape.getCoordenatesToVisit().Count(); k++)
                            {
                                if (j + randomShape.getCoordenatesToVisit()[k].getX() >= 0 &&
                                    cells[i + randomShape.getCoordenatesToVisit()[k].getY()][j + randomShape.getCoordenatesToVisit()[k].getX()].getIsAvailable()) //que no se salga de la izquierda del board
                                {
                                    cells[i + randomShape.getCoordenatesToVisit()[k].getY()][j + randomShape.getCoordenatesToVisit()[k].getX()].setIsAvailable(false);
                                    newFigure.getCells().Add(cells[i + randomShape.getCoordenatesToVisit()[k].getY()][j + randomShape.getCoordenatesToVisit()[k].getX()]);
                                }
                                else
                                {
                                    revert(newFigure); //revertir usando figure cells
                                    newFigure = null;
                                    j--;
                                    shapeDictionary.getShapes().Remove(randomShape);
                                    //Console.WriteLine(shapeDictionary.getShapes().Count());
                                    break;
                                }
                            }
                            if(newFigure != null)
                            {
                                figures.Add(newFigure);
                                newFigure.setIdFigure(randomShape.getId());
                            }
                        }
                        else
                        {
                            j--;
                            shapeDictionary.getShapes().Remove(randomShape);
                        }
                    }
                }
                shapeDictionary = new ShapeDictionary();
            }
            printBoard();
        }

        public void revert(Figure figure)
        {
            for(int i=0; i<figure.getCells().Count(); i++)
            {
                figure.getCells()[i].setIsAvailable(true);
            }
        }

        public void generateBoard()
        {
            Random random = new Random();
            for(int i=0; i<size; i++)
            {
                Stack<int> stack = new Stack<int>();
                for (int j=0; j<size; j++)
                {
                    if(cells.ElementAt(i).ElementAt(j).getAvailableNumbers().Count() != 0)
                    {
                        int randomNumberIdx = random.Next(cells.ElementAt(i).ElementAt(j).getAvailableNumbers().Count());
                        int number = cells.ElementAt(i).ElementAt(j).getAvailableNumbers().ElementAt(randomNumberIdx);
                        stack.Push(number);
                        cells.ElementAt(i).ElementAt(j).setNumber(number);
                        deleteNumberRow(number, i);
                        deleteNumberColumn(number, j);
                    }
                    
                    

                    
                    //cells.ElementAt(i).ElementAt(j).getAvailableNumbers().RemoveAt(randomNumberIdx);
                    Console.WriteLine(cells.ElementAt(i).ElementAt(j).getNumber());
                    printBoard();
                }
            }
            printBoard();
        }

        public void deleteNumberRow(int number, int x)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < cells[x][i].getAvailableNumbers().Count(); j++)
                {
                    if (number == cells[x][i].getAvailableNumbers().ElementAt(j))
                    {
                        cells[x][i].getAvailableNumbers().RemoveAt(j);
                        break;
                    }
                }
            }
        }

        public void deleteNumberColumn(int number, int y)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < cells[i][y].getAvailableNumbers().Count(); j++)
                {
                    if (number == cells[i][y].getAvailableNumbers().ElementAt(j))
                    {
                        cells[i][y].getAvailableNumbers().RemoveAt(j);
                        break;
                    }
                }
            }
        }

        //prebas
        public void generateAvailableNumbers()
        {
            for(int i=0; i<size; i++)
            {
                List<int> newAvailable = generateAvaialableAux();
                for(int j=0; j<size; j++)
                {
                    cells[i][j].setAvailableNumbers(newAvailable);
                }
            }
        }

        //pruebas
        public List<int> generateAvaialableAux()
        {
            List<int> newAvailableNumbers = new List<int>();
            for(int i=0; i<size; i++)
            {
                newAvailableNumbers.Add(i);
            }
            return newAvailableNumbers;
        }

        public int getRandomNumber()
        {
            List<int> availableNumbers = new List<int>();
            return 0;
        }

        //pruebas
        public List<int> getAvailableColumnNumbers(int column, List<int> availableNumbers)
        {
            for(int i=0; i<size; i++)
            {
                if(cells[i][column].getNumber() != -1)
                {
                    //delete number from available numbers
                }
            }
            return null;
        }

        public void printBoard()
        {
            for(int i=0; i<size; i++)
            {
                String row = "";
                for(int j=0; j<size; j++)
                {
                    row += cells[i][j].getNumber() + " ";
                    //Console.WriteLine(cells[i][j].getIsAvailable());
                }
                Console.WriteLine(row);
            }
            //Console.WriteLine(figures.Count());
        }

    }

    
}
