using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
        private int id;
        private Color color;

        public Shape(int height, int width, int id)
        {
            coordenatesToVisit = new List<Coordenate>();
            this.height = height;
            this.width = width;
            this.id = id;
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

        public void setColor(Color color)
        {
            this.color = color;
        }

        public Color getColor()
        {
            return color;
        }

        public int getHeight()
        {
            return height;
        }

        public int getWidth()
        {
            return width;
        }

        public int getId()
        {
            return id;
        }
    }
}
