using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class Cell
    {
        private int number;
        private Coordenate coordenates;
        private bool isAvailable;
        //private int form;

        public Cell(int number, int coordenateX, int coordenateY, bool isAvailable)
        {
            this.number = number;
            coordenates = new Coordenate(coordenateX, coordenateY);
            this.isAvailable = isAvailable;
        }

        public Cell(int coordenateX, int coordenateY, bool isAvailable)
        {
            coordenates = new Coordenate(coordenateX, coordenateY);
            this.isAvailable = isAvailable;
        }

        public bool getIsAvailable()
        {
            return isAvailable;
        }

        public void setIsAvailable(bool value)
        {
            isAvailable = value;
        }
    }
}
