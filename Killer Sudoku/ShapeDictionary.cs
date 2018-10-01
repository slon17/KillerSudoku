using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class ShapeDictionary
    {
        ArrayList shapes;

        public ShapeDictionary()
        {
            shapes = new ArrayList();
            generateFigSquare();
            generateFigL0();
            generateFigL1();
            generateFigL2();
            generateFigL3();
            generateFigDoubleLine0();
            generateFigDoubleLine1();
            generateFigTripleLine0();
            generateFigTripleLine1();
            generateFigQuadLine0();
            generateFigQuadLine1();
            generateFigShortL0();
            generateFigShortL1();
            generateFigShortL2();
            generateFigShortL3();
            generateFigT0();
            generateFigT1();
            generateFigT2();
            generateFigT3();
            generateFigS0();
            generateFigS1();
            generateFigS2();
            generateFigS3();
        }

        public Shape generateFigSquare()
        {
            Shape newShape = new Shape(2, 2);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(1, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(1, 1);
            return newShape;
        }

        public Shape generateFigL0()
        {
            Shape newShape = new Shape(3, 2);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(0, 2);
            newShape.addCoordenateToVisit(1, 2);
            return newShape;
        }
        public Shape generateFigL1()
        {
            Shape newShape = new Shape(2, 3);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(1, 0);
            newShape.addCoordenateToVisit(2, 0);
            newShape.addCoordenateToVisit(0, 1);
            return newShape;
        }

        public Shape generateFigL2()
        {
            Shape newShape = new Shape(2, 3);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(1, 1);
            newShape.addCoordenateToVisit(2, 1);
            return newShape;
        }

        public Shape generateFigL3()
        {
            Shape newShape = new Shape(3, 2);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(0, 2);
            newShape.addCoordenateToVisit(-1, 2);
            return newShape;
        }

        public Shape generateFigDoubleLine0()
        {
            Shape newShape = new Shape(2, 1);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            return newShape;
        }

        public Shape generateFigDoubleLine1()
        {
            Shape newShape = new Shape(1, 2);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(1, 0);
            return newShape;
        }

        public Shape generateFigTripleLine0()
        {
            Shape newShape = new Shape(1, 3);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(1, 0);
            newShape.addCoordenateToVisit(2, 0);
            return newShape;
        }

        public Shape generateFigTripleLine1()
        {
            Shape newShape = new Shape(3, 1);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(0, 2);
            return newShape;
        }

        public Shape generateFigQuadLine0()
        {
            Shape newShape = new Shape(1, 4);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(1, 0);
            newShape.addCoordenateToVisit(2, 0);
            newShape.addCoordenateToVisit(3, 0);
            return newShape;
        }

        public Shape generateFigQuadLine1()
        {
            Shape newShape = new Shape(4, 1);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(0, 2);
            newShape.addCoordenateToVisit(0, 3);
            return newShape;
        }

        public Shape generateFigShortL0()
        {
            Shape newShape = new Shape(2, 2);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(1, 1);
            return newShape;
        }

        public Shape generateFigShortL1()
        {
            Shape newShape = new Shape(2, 2);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(1, 0);
            newShape.addCoordenateToVisit(0, 1);
            return newShape;
        }

        public Shape generateFigShortL2()
        {
            Shape newShape = new Shape(2, 2);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(-1, 1);
            return newShape;
        }

        public Shape generateFigShortL3()
        {
            Shape newShape = new Shape(2, 2);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(-1, 0);
            newShape.addCoordenateToVisit(0, 1);
            return newShape;
        }

        public Shape generateFigT0()
        {
            Shape newShape = new Shape(3, 2);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(1, 1);
            newShape.addCoordenateToVisit(0, 2);
            return newShape;
        }

        public Shape generateFigT1()
        {
            Shape newShape = new Shape(2, 3);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(1, 0);
            newShape.addCoordenateToVisit(2, 0);
            newShape.addCoordenateToVisit(1, 1);
            return newShape;
        }

        public Shape generateFigT2()
        {
            Shape newShape = new Shape(3, 2);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(-1, 1);
            newShape.addCoordenateToVisit(0, 2);
            return newShape;
        }

        public Shape generateFigT3()
        {
            Shape newShape = new Shape(2, 3);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(1, 1);
            newShape.addCoordenateToVisit(-1, 1);
            return newShape;
        }

        public Shape generateFigS0()
        {
            Shape newShape = new Shape(2, 3);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(1, 0);
            newShape.addCoordenateToVisit(1, 1);
            newShape.addCoordenateToVisit(2, 1);
            return newShape;
        }

        public Shape generateFigS1()
        {
            Shape newShape = new Shape(3, 2);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(-1, 1);
            newShape.addCoordenateToVisit(-1, 2);
            return newShape;
        }

        public Shape generateFigS2()
        {
            Shape newShape = new Shape(2, 3);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(1, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(-1, 1);
            return newShape;
        }

        public Shape generateFigS3()
        {
            Shape newShape = new Shape(3, 2);
            newShape.addCoordenateToVisit(0, 0);
            newShape.addCoordenateToVisit(0, 1);
            newShape.addCoordenateToVisit(1, 1);
            newShape.addCoordenateToVisit(1, 2);
            return newShape;
        }
    }
}
