using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class Shape
    {
        private ArrayList coordenatesToVisit;
        private int height;
        private int width;

        public Shape(int height, int width)
        {
            coordenatesToVisit = new ArrayList();
            this.height = height;
            this.width = width;
        }

        public ArrayList getCoordenatesToVisit()
        {
            return coordenatesToVisit;
        }

        public void addCoordenateToVisit(int x, int y)
        {
            Coordenate newCoordenate = new Coordenate(x, y);
            coordenatesToVisit.Add(newCoordenate);
        }
    }
}
