using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class Cell
    {
        private int number;
        private int numberBT;
        private Coordenate coordenates;
        private bool isAvailable;
        private List<int> availableNumbers;
        private Color color;
        //private int form;

        public Cell(int number, int coordenateX, int coordenateY, bool isAvailable)
        {
            this.number = number;
            coordenates = new Coordenate(coordenateX, coordenateY);
            this.isAvailable = isAvailable;
        }

        public Cell(int coordenateX, int coordenateY, bool isAvailable, int boardSize)
        {
            coordenates = new Coordenate(coordenateX, coordenateY);
            this.isAvailable = isAvailable;
            availableNumbers = new List<int>();
            for(int i=0; i<boardSize; i++)
            {
                availableNumbers.Add(i);
            }
            number = -1;
            numberBT = -1;
        }

        public bool getIsAvailable()
        {
            return isAvailable;
        }

        public void setIsAvailable(bool value)
        {
            isAvailable = value;
        }

        public int getNumber()
        {
            return number;
        }

        public void setNumber(int number)
        {
            this.number = number;
        }

        public List<int> getAvailableNumbers()
        {
            return availableNumbers;
        }

        public void setAvailableNumbers(List<int> availableNumbers)
        {
            this.availableNumbers = availableNumbers;
        }

        public Color getColor()
        {
            return color;
        }

        public void setColor(Color colorNew)
        {
            color = colorNew;
        }

        public int getNumberBT()
        {
            return numberBT;
        }

        public void setNumberBT(int numberBT)
        {
            this.numberBT = numberBT;
        }

        public Coordenate getCoordenate()
        {
            return coordenates;
        }
    }
}
