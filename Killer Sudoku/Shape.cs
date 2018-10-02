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
        private List<Coordenate> coordenatesToVisit;
        private int height;
        private int width;

        public Shape(int height, int width)
        {
            coordenatesToVisit = new List<Coordenate>();
            this.height = height;
            this.width = width;
        }

        public List<Coordenate> getCoordenatesToVisit()
        {
            return coordenatesToVisit;
        }

        public void addCoordenateToVisit(int x, int y)
        {
            Coordenate newCoordenate = new Coordenate(x, y);
            coordenatesToVisit.Add(newCoordenate);
        }

        public int getHeight()
        {
            return height;
        }

        public int getWidth()
        {
            return width;
        }
    }
}
