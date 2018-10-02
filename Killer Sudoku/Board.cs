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
                    Cell newCell = new Cell(j, i, true);
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
                            Console.WriteLine("entro");
                            shapeDictionary.getShapes().Add(shapeDictionary.generateFigDot());
                            randomShape = shapeDictionary.getRandomShape();
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
                                    figures.Add(newFigure);
                                }
                                else
                                {
                                    revert(newFigure); //revertir usando figure cells
                                    j--;
                                    shapeDictionary.getShapes().Remove(randomShape);
                                    Console.WriteLine(shapeDictionary.getShapes().Count());
                                    break;
                                }
                            }
                        }
                        else
                        {
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

        public void printBoard()
        {
            for(int i=0; i<size; i++)
            {
                for(int j=0; j<size; j++)
                {
                    Console.WriteLine(cells[i][j].getIsAvailable());
                }
            }
        }
    }

    
}
