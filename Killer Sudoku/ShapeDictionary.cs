using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class ShapeDictionary
    {
        List<Shape> shapes;

        public ShapeDictionary()
        {
            shapes = new List<Shape>();
            shapes.Add(generateFigSquare());
            shapes.Add(generateFigL0());
            shapes.Add(generateFigL1());
            shapes.Add(generateFigL2());
            shapes.Add(generateFigL3());
            shapes.Add(generateFigDoubleLine0());
            shapes.Add(generateFigDoubleLine1());
            shapes.Add(generateFigTripleLine0());
            shapes.Add(generateFigTripleLine1());
            shapes.Add(generateFigQuadLine0());
            shapes.Add(generateFigQuadLine1());
            shapes.Add(generateFigShortL0());
            shapes.Add(generateFigShortL1());
            shapes.Add(generateFigShortL2());
            shapes.Add(generateFigShortL3());
            shapes.Add(generateFigT0());
            shapes.Add(generateFigT1());
            shapes.Add(generateFigT2());
            shapes.Add(generateFigT3());
            shapes.Add(generateFigS0());
            shapes.Add(generateFigS1());
            shapes.Add(generateFigS2());
            shapes.Add(generateFigS3());
        }

        public List<Shape> getShapes()
        {
            return shapes;
        }

        public Shape getRandomShape(Random random)
        {
            if(shapes.Count() == 0)
            {
                return null;
            }
            else
            {
                int randomShape = random.Next(shapes.Count());
                return shapes[randomShape];
            }
        }

        public Shape generateFigSquare()
        {
            Shape newShape = new Shape(2, 2, 0);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(1, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(1, 1);
            
            int red = 52;
            int green = 3;
            int blue = 188;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigL0()
        {
            Shape newShape = new Shape(3, 2, 1);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(0, 2);
            newShape.addCoordenateToVisit(1, 2);

            int red = 122;
            int green = 50;
            int blue = 49;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }
        public Shape generateFigL1()
        {
            Shape newShape = new Shape(2, 3, 2);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(1, 0);
            newShape.addCoordenateToVisit(2, 0);
            newShape.addCoordenateToVisit(0, 1);

            int red = 122;
            int green = 50;
            int blue = 49;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigL2()
        {
            Shape newShape = new Shape(2, 3, 3);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(1, 1);
            newShape.addCoordenateToVisit(2, 1);

            int red = 122;
            int green = 50;
            int blue = 49;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigL3()
        {
            Shape newShape = new Shape(3, 2, 4);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(0, 2);
            newShape.addCoordenateToVisit(-1, 2);

            int red = 122;
            int green = 50;
            int blue = 49;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigDoubleLine0()
        {
            Shape newShape = new Shape(2, 1, 5);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);

            int red = 22;
            int green = 131;
            int blue = 85;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigDoubleLine1()
        {
            Shape newShape = new Shape(1, 2, 6);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(1, 0);

            int red = 22;
            int green = 131;
            int blue = 85;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigTripleLine0()
        {
            Shape newShape = new Shape(1, 3, 7);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(1, 0);
            newShape.addCoordenateToVisit(2, 0);

            int red = 3;
            int green = 43;
            int blue = 134;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigTripleLine1()
        {
            Shape newShape = new Shape(3, 1, 8);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(0, 2);

            int red = 3;
            int green = 43;
            int blue = 134;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigQuadLine0()
        {
            Shape newShape = new Shape(1, 4, 9);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(1, 0);
            newShape.addCoordenateToVisit(2, 0);
            newShape.addCoordenateToVisit(3, 0);

            int red = 252;
            int green = 222;
            int blue = 144;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigQuadLine1()
        {
            Shape newShape = new Shape(4, 1, 10);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(0, 2);
            newShape.addCoordenateToVisit(0, 3);

            int red = 252;
            int green = 222;
            int blue = 144;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigShortL0()
        {
            Shape newShape = new Shape(2, 2, 11);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(1, 1);

            int red = 192;
            int green = 215;
            int blue = 67;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigShortL1()
        {
            Shape newShape = new Shape(2, 2, 12);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(1, 0);
            newShape.addCoordenateToVisit(0, 1);

            int red = 192;
            int green = 215;
            int blue = 67;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigShortL2()
        {
            Shape newShape = new Shape(2, 2, 13);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(-1, 1);

            int red = 192;
            int green = 215;
            int blue = 67;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigShortL3()
        {
            Shape newShape = new Shape(2, 2, 14);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(-1, 0);
            newShape.addCoordenateToVisit(0, 1);

            int red = 192;
            int green = 215;
            int blue = 67;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigT0()
        {
            Shape newShape = new Shape(3, 2, 15);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(1, 1);
            newShape.addCoordenateToVisit(0, 2);

            int red = 194;
            int green = 158;
            int blue = 252;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigT1()
        {
            Shape newShape = new Shape(2, 3, 16);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(1, 0);
            newShape.addCoordenateToVisit(2, 0);
            newShape.addCoordenateToVisit(1, 1);

            int red = 194;
            int green = 158;
            int blue = 252;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigT2()
        {
            Shape newShape = new Shape(3, 2, 17);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(-1, 1);
            newShape.addCoordenateToVisit(0, 2);

            int red = 194;
            int green = 158;
            int blue = 252;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigT3()
        {
            Shape newShape = new Shape(2, 3, 18);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(1, 1);
            newShape.addCoordenateToVisit(-1, 1);

            int red = 194;
            int green = 158;
            int blue = 252;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigS0()
        {
            Shape newShape = new Shape(2, 3, 19);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(1, 0);
            newShape.addCoordenateToVisit(1, 1);
            newShape.addCoordenateToVisit(2, 1);

            int red = 53;
            int green = 81;
            int blue = 102;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigS1()
        {
            Shape newShape = new Shape(3, 2, 20);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(-1, 1);
            newShape.addCoordenateToVisit(-1, 2);

            int red = 53;
            int green = 81;
            int blue = 102;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigS2()
        {
            Shape newShape = new Shape(2, 3, 21);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(1, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(-1, 1);

            int red = 53;
            int green = 81;
            int blue = 102;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigS3()
        {
            Shape newShape = new Shape(3, 2, 22);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(1, 1);
            newShape.addCoordenateToVisit(1, 2);

            int red = 53;
            int green = 81;
            int blue = 102;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }

        public Shape generateFigDot()
        {
            Shape newShape = new Shape(1, 1, 23);
            newShape.addCoordenateToVisit(0, 0);

            int red = 222;
            int green = 34;
            int blue = 190;

            Color BackColor = Color.FromArgb(120, red, green, blue);
            newShape.setColor(BackColor);

            return newShape;
        }
    }
}
