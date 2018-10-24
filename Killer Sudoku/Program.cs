using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
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
            /*int size = 10;
            Random r = new Random();

            Board board = new Board(size);
            
            board.generateNumbers();

            board.suffleNumbers(30);

            board.printBoard();
            
            board.generateFigures();
            board.setClues(100.0);
            board.asignNumberFigure();*/

            //Board board = generateGame(form1);

            //Backtracking backtracking = new Backtracking(board);
            
            //List<Thread> list = new List<Thread>();
            /*for(int i=0; i<5; i++)
            {
                Thread th = new Thread(()=>method(backtracking, board));
                th.Name = i.ToString();
                list.Add(th);
            }

            for(int i=0; i<5; i++)
            {
                list[i].Start();
                Thread.Sleep(10);
                list[i].Join();
                Console.WriteLine(i);
            }*/
            
            //backtracking.resolve(board);
            //CreateLabelsSolved(form1, board, size, size);
            //CreateLabelsNotSolved(form1, board, size, size);
            //board.printBoardBT();

            //XMLHelper.WriteXMLBoard(board);
            Application.Run(form1);

        }

        static void CreateLabelsNotSolved(Form1 form, Board board, int m, int n)
        {
            List<List<Cell>> cells = board.getCells();
            List<Label> labels = new List<Label>();

            for (int i = 0; i < board.getFigures().Count(); i++)
            {
                for (int j = 0; j < board.getFigures()[i].getCells().Count(); j++)
                {
                    Label label = new Label();
                    label.BackColor = board.getFigures()[i].getCells()[j].getColor();
                    label.Name = "label" + i + "" + j;
                    label.Text = board.getFigures()[i].getCells()[j].getNumber().ToString(); ;
                    label.Size = new Size(50, 50);
                    label.Location = new Point(board.getFigures()[i].getCells()[j].getCoordenate().getX() * 50, board.getFigures()[i].getCells()[j].getCoordenate().getY() * 50);
                    labels.Add(label);

                    if (j == 0)
                    {
                        label.Text = label.Text + "\n\n(" + board.getFigures()[i].getOperationResult().ToString() + board.getFigures()[i].getOperation().ToString() + ")";
                    }
                }
            }

            for (int i = 0; i < board.getFigures().Count(); i++)
            {
                for (int j = 0; j < board.getFigures()[i].getCells().Count(); j++)
                {
                    Label label = new Label();
                    label.BackColor = board.getFigures()[i].getCells()[j].getColor();
                    label.Name = "label" + i + "" + j;
                    label.Text = board.getFigures()[i].getCells()[j].getNumberBT().ToString(); ;
                    label.Size = new Size(50, 50);
                    label.Location = new Point(board.getFigures()[i].getCells()[j].getCoordenate().getX() * 50+800, board.getFigures()[i].getCells()[j].getCoordenate().getY() * 50);
                    labels.Add(label);

                    if (j == 0)
                    {
                        label.Text = label.Text + "\n\n(" + board.getFigures()[i].getOperationResult().ToString() + board.getFigures()[i].getOperation().ToString() + ")";
                    }
                }
            }
            for (int i = 0; i < (2*n * m); i++)
            {
                form.panel1.Controls.Add(labels[i]);
            }
        }

        static void CreateLabelsSolved(Form1 form, Board board, int n, int m)
        {
            List<List<Cell>> cells = board.getCells();
            List<Label> labels = new List<Label>();
            /*for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // Here you can modify the value of the textbox which is at textBoxes[i]
                    
                    Label label = new Label();
                    label.BackColor = cells[i][j].getColor();
                    label.Name = "label" + i + "" + j;
                    label.Text = cells[j][i].getNumber().ToString();
                    label.Size = new Size(50, 50);
                    label.Location = new Point(cells[i][j].getCoordenate().getX() *50, cells[i][j].getCoordenate().getY() * 50);
                    labels.Add(label);
                    
                }
            }*/

            for(int i=0; i<board.getFigures().Count(); i++)
            {
                for(int j=0; j< board.getFigures()[i].getCells().Count(); j++)
                {
                    Label label = new Label();
                    label.BackColor = board.getFigures()[i].getCells()[j].getColor();
                    label.Name = "label" + i + "" + j;
                    label.Text = board.getFigures()[i].getCells()[j].getNumber().ToString();
                    label.Size = new Size(50, 50);
                    label.Location = new Point(board.getFigures()[i].getCells()[j].getCoordenate().getX() * 50, board.getFigures()[i].getCells()[j].getCoordenate().getY() * 50);
                    labels.Add(label);

                    if (j == 0)
                    {
                        label.Text = label.Text + "\n\n(" + board.getFigures()[i].getOperationResult().ToString() + board.getFigures()[i].getOperation().ToString() + ")";
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // Here you can modify the value of the textbox which is at textBoxes[i]

                    Label label = new Label();
                    label.BackColor = cells[i][j].getColor();
                    label.Name = "label" + i*2 + "" + j*2;
                    label.Text = cells[j][i].getNumberBT().ToString();
                    label.Size = new Size(50, 50);
                    label.Location = new Point(cells[i][j].getCoordenate().getX() * 50+800, cells[i][j].getCoordenate().getY() * 50);
                    labels.Add(label);

                }
            }
            for (int i = 0; i < (2*n*m); i++)
            {
                    form.panel1.Controls.Add(labels[i]);  
            }
        }

        static int searchPositionLabel(Cell cellFig, Board board, int n, int m)
        {
            int position = 0;
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < m; k++)
                {
                    if (cellFig.Equals(board.getCells()[j][k]))
                    {
                        return position;
                    }
                    position++;
                }

            }
            return position;
        }

        public static void updateBoard(Form1 form, Board board, int size)
        {
            while (true)
            {
                CreateLabelsSolved(form, board, size, size);
            }
        }

        public static void method(Backtracking backtracking, Board board)
        {
            backtracking.resolve(board);
        }
    }
}
