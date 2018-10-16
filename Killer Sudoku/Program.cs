using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Killer_Sudoku
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form1 = new Form1();
            
            Random r = new Random();
            Console.WriteLine(r.Next(0));
            Board board = new Board(3);
            
            //board.generateBoard();
            board.generateNumbers();
            board.printBoardCoord();
            board.printBoard();
            //board.suffleNumbers(30);
            
            board.generateFigures();
            Console.WriteLine(board.getFigures()[0].getCells()[0].getCoordenate().getX()+" "+ board.getFigures()[0].getCells()[0].getCoordenate().getY());
            board.asignNumberFigure();

            Backtracking backtracking = new Backtracking(board);
            backtracking.resolve(board);

            CreateLabels(form1, board, 3, 3);
            Application.Run(form1);

            /*
            for(int i=0; i<23; i++)
            {
                int red = r.Next(256);
                int green = r.Next(256);
                int blue = r.Next(256);
                Console.WriteLine("red: " + red + " green: " + green + " blue: " + blue);
            }*/

        }

        static void CreateLabels(Form1 form, Board board, int n, int m)
        {
            List<List<Cell>> cells = board.getCells();
            List<Label> labels = new List<Label>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // Here you can modify the value of the textbox which is at textBoxes[i]
                    
                    Label label = new Label();
                    label.BackColor = cells[i][j].getColor();
                    label.Name = "label" + i + "" + j;
                    label.Text = cells[i][j].getNumber().ToString();
                    label.Size = new Size(50, 50);
                    label.Location = new System.Drawing.Point(cells[i][j].getCoordenate().getX() *50, cells[i][j].getCoordenate().getY() * 50);
                    labels.Add(label);
                }
            }
            for (int i = 0; i < n*m; i++)
            {
                
                    form.panel1.Controls.Add(labels[i]);
                
            }
        }
    }
}
