using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;
using System.Xml.Serialization;

namespace Killer_Sudoku
{
    [XmlRoot("Board", Namespace = "http://www.cpandl.com", IsNullable = false)]
    public class Board
    {
        [XmlArrayAttribute("Cells")]
        private static List<List<Cell>> cells;
        private List<Figure> figures;
        private ArrayList sectors;
        private ShapeDictionary shapeDictionary;
        private int size;
        private bool isOver;
        bool locked;

        public Board()
        {

        }

        public Board(int size)
        {
            cells = generateCells(size);
            shapeDictionary = new ShapeDictionary();
            this.size = size;
            figures = new List<Figure>();
            isOver = false;
            locked = false;
        }

        

        public List<List<Cell>> generateCells(int size)
        {
            List<List<Cell>> newMatrix = new List<List<Cell>>();
            for (int i = 0; i < size; i++)
            {
                List<Cell> newRow = new List<Cell>();
                for (int j = 0; j < size; j++)
                {
                    Cell newCell = new Cell(i, j, true, size);
                    newRow.Add(newCell);
                    //Console.WriteLine(newCell.getCoordenate().getX() + " " + newCell.getCoordenate().getY());
                }
                newMatrix.Add(newRow);
            }
            return newMatrix;
        }

        public void generateFigures()
        {
            Random random = new Random();
            Random r = new Random();
            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //Console.WriteLine(j);
                    if (cells[i][j].getIsAvailable())
                    {
                        Shape randomShape = shapeDictionary.getRandomShape(random);
                        if (shapeDictionary.getShapes().Count() == 0)
                        {
                            Console.WriteLine("dot");
                            shapeDictionary.getShapes().Add(shapeDictionary.generateFigDot());
                            randomShape = shapeDictionary.getShapes()[0];
                        }
                        if (i + randomShape.getWidth()-1 < size && j + randomShape.getHeight()-1 < size)
                        {
                            int red = r.Next(256);
                            int green = r.Next(256);
                            int blue = r.Next(256);
                            //Console.WriteLine("red: " + red + " green: " + green + " blue: " + blue);
                            Color BackColor = Color.FromArgb(120, red, green, blue);

                            Figure newFigure = new Figure(0);
                            for (int k = 0; k < randomShape.getCoordenatesToVisit().Count(); k++)
                            {
                                if (i + randomShape.getCoordenatesToVisit()[k].getX() >= 0 &&
                                    cells[i + randomShape.getCoordenatesToVisit()[k].getX()][j + randomShape.getCoordenatesToVisit()[k].getY()].getIsAvailable()) //que no se salga de la izquierda del board
                                {
                                    cells[i + randomShape.getCoordenatesToVisit()[k].getX()][j + randomShape.getCoordenatesToVisit()[k].getY()].setIsAvailable(false);
                                    newFigure.getCells().Add(cells[i + randomShape.getCoordenatesToVisit()[k].getX()][j + randomShape.getCoordenatesToVisit()[k].getY()]);

                                    cells[i + randomShape.getCoordenatesToVisit()[k].getX()][j + randomShape.getCoordenatesToVisit()[k].getY()].setColor(BackColor);
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
            printFigureCoord();
            //printBoard();
        }

        public void revert(Figure figure)
        {
            for(int i=0; i<figure.getCells().Count(); i++)
            {
                figure.getCells()[i].setIsAvailable(true);
            }
        }

        public void printFigureCoord()
        {
            
            for(int i=0; i<figures.Count(); i++)
            {
                /*Console.WriteLine("Figura");
                for (int j = 0; j < figures[i].getCells().Count(); j++)
                    Console.WriteLine("x: " + figures[i].getCells()[j].getCoordenate().getX()+" y: "+ figures[i].getCells()[j].getCoordenate().getY());*/
            }
        }

        public void asignNumberFigure()
        {
            Random random = new Random();
            int idOperation = random.Next(2);

            for (int i = 0; i < figures.Count(); i++)
            {
                if(idOperation == 0)
                {
                    figures.ElementAt(i).getSumValue();
                }
                else
                {
                    figures.ElementAt(i).getMultValue();
                }
                idOperation = random.Next(2);
            }
        }

        public void asignSumFigure()
        {
            for(int i = 0; i<figures.Count(); i++)
            {
                figures.ElementAt(i).getSumValue();
            }
        }

        public void asignMultFigure()
        {
            for (int i = 0; i < figures.Count(); i++)
            {
                figures.ElementAt(i).getMultValue();
            }
        }

        public void asignDots()
        {
            for(int i=0; i<figures.Count(); i++)
            {
                if(figures[i].getIdFigure() == 23)
                {
                    //Console.WriteLine(figures[i].getCells()[0].getNumber());
                    figures[i].getCells()[0].setNumberBT(figures[i].getOperationResult());
                }
            }
        }

        public void generateNumbers()
        {
            int baseNumber = 0;
            for(int i=0; i<size; i++)
            {
                for(int j=0; j<size; j++)
                {
                    cells[i][j].setNumber((baseNumber + j +1) % size + 1);
                }
                baseNumber++;
                //printBoard();
            }
        }

        public void setClues(double porcentaje)
        {
            double numPistas = figures.Count()*(double)(porcentaje/100.0);
            Console.WriteLine(figures.Count());
            Console.WriteLine(numPistas);
            for (int i = 0; i < numPistas; i++)
            {
                figures[i].getCells()[0].setNumberBT(figures[i].getCells()[0].getNumber());
            }
        }

        public void suffleNumbers(int shuffleLevel)
        {
            Random random = new Random();
            int randomSide;
            for(int i=0; i<shuffleLevel; i++)
            {
                randomSide = random.Next(2);
                if(randomSide == 0) //horizontal
                {
                    int row1 = random.Next(size);
                    int row2 = random.Next(size);

                    //switch rows
                    switchRows(row1, row2);
                }
                else
                {
                    int column1 = random.Next(size);
                    int column2 = random.Next(size);

                    //switch columns
                    switchColumns(column1, column2);
                }
                //printBoard();
            }
        }

        public void switchRows(int row1, int row2)
        {
            List<Cell> firstRow = cells[row1];
            List<Cell> secondRow = cells[row2];

            for (int i=0; i<size; i++)
            {
                int num1 = firstRow[i].getNumber();
                int num2 = secondRow[i].getNumber();

                firstRow[i].setNumber(num2);
                secondRow[i].setNumber(num1);
            }

            //cells[row1] = secondRow;
            //cells[row2] = firstRow;
        }

        public void switchColumns(int column1, int column2)
        {
            for(int i=0; i<size; i++)
            {
                int number1 = cells[i][column1].getNumber();
                int number2 = cells[i][column2].getNumber();

                cells[i][column1].setNumber(number2);
                cells[i][column2].setNumber(number1);
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
            Console.WriteLine(" ");
            //Console.WriteLine(figures.Count());
        }

        public void printBoardCoord()
        {
            for (int i = 0; i < size; i++)
            {
                String row = "";
                for (int j = 0; j < size; j++)
                {
                    row += cells[i][j].getCoordenate().getX() +""+ cells[i][j].getCoordenate().getY()+" ";
                    //Console.WriteLine(cells[i][j].getIsAvailable());
                }
                Console.WriteLine(row);
            }
            Console.WriteLine(" ");
        }

        public void printBoardBT()
        {
            for (int i = 0; i < size; i++)
            {
                String row = "";
                for (int j = 0; j < size; j++)
                {
                    row += cells[i][j].getNumberBT() + " ";
                    //Console.WriteLine(cells[i][j].getIsAvailable());
                }
                Console.WriteLine(row);
            }
            Console.WriteLine(" ");
            //Console.WriteLine(figures.Count());
        }

        public List<List<Cell>> getCells()
        {
            return cells;
        }

        public bool isFull()
        {
            //Console.WriteLine("is full");
            for(int i=0; i<size; i++)
            {
                for(int j=0; j<size; j++)
                {
                    if(cells[i][j].getNumberBT() == -1)
                    {
                        //Console.WriteLine("is full = false");
                        return false;
                    }
                }
            }
            return true;
        }

        public bool isEqual()
        {
            for(int i=0; i<size; i++)
            {
                for(int j=0; j<size; j++)
                {
                    if (cells[i][j].getNumber() != cells[i][j].getNumberBT())
                        return false;
                }
            }
            return true;
        }

        public List<Figure> getFigures()
        {
            return figures;
        }

        public int getSize()
        {
            return size;
        }

        public bool getIsOver()
        {
            return isOver;
        }

        public void setIsOver(bool isOver)
        {
            this.isOver = isOver;
        }
    }

    
}
