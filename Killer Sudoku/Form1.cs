using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Killer_Sudoku
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        Board board;
        Backtracking backtracking;
        double clues = 100;
        int size = 3;
        int threads = 1;
        List<Thread> listThread;

        public Form1()
        {
            InitializeComponent();
            board = null;
            listThread = new List<Thread>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            board = generateGame(size, clues);
            backtracking = new Backtracking(board);
            CreateLabelsNotSolved(this, board, size, size);
        }

        private void tbarClues_Scroll(object sender, EventArgs e)
        {
            clues = tbarClues.Value;
        }

        private void tbarSize_Scroll(object sender, EventArgs e)
        {
            size = tbarSize.Value;
        }

        private void btnResolve_Click(object sender, EventArgs e)
        {
            //Thread mainTh = new Thread(() => updateBoard(this, board, size));
            //mainTh.IsBackground = true;
            //mainTh.Start();
            //updateBoard(this, board, size);
            for (int i = 0; i < threads; i++)
            {
                Thread th = new Thread(() => backtracking.resolve(board));
                th.Name = i.ToString();
                listThread.Add(th);
            }
            for (int i = 0; i < threads; i++)
            {
                listThread[i].Start();
                Thread.Sleep(10);
                listThread[i].Join();
                Console.WriteLine(i);
            }
            //backtracking.resolve(board);
            CreateLabelsSolved(this, board, size, size);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            threads = trackBar1.Value;
        }

        public Board generateGame(int size, double clues)
        {
            Board board = new Board(size);
            board.generateNumbers();
            board.suffleNumbers(30);
            board.generateFigures();
            board.setClues(clues);
            board.asignNumberFigure();

            return board;
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
                        if(board.getFigures()[i].getOperation() == 0)
                            label.Text = label.Text + "\n\n(" + board.getFigures()[i].getOperationResult().ToString() + "+)";
                        else
                            label.Text = label.Text + "\n\n(" + board.getFigures()[i].getOperationResult().ToString() + "*)";
                    }
                }
            }
            /*
            for (int i = 0; i < board.getFigures().Count(); i++)
            {
                for (int j = 0; j < board.getFigures()[i].getCells().Count(); j++)
                {
                    Label label = new Label();
                    label.BackColor = board.getFigures()[i].getCells()[j].getColor();
                    label.Name = "label" + i + "" + j;
                    label.Text = board.getFigures()[i].getCells()[j].getNumberBT().ToString(); ;
                    label.Size = new Size(50, 50);
                    label.Location = new Point(board.getFigures()[i].getCells()[j].getCoordenate().getX() * 50 + 800, board.getFigures()[i].getCells()[j].getCoordenate().getY() * 50);
                    labels.Add(label);

                    if (j == 0)
                    {
                        label.Text = label.Text + "\n\n(" + board.getFigures()[i].getOperationResult().ToString() + board.getFigures()[i].getOperation().ToString() + ")";
                    }
                }
            }*/
            for (int i = 0; i < (/*2 * */n * m); i++)
            {
                form.panel1.Controls.Add(labels[i]);
            }
        }

        static void CreateLabelsSolved(Form1 form, Board board, int n, int m)
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

            for (int i = 0; i < board.getFigures().Count(); i++)
            {
                for (int j = 0; j < board.getFigures()[i].getCells().Count(); j++)
                {
                    Label label = new Label();
                    label.BackColor = board.getFigures()[i].getCells()[j].getColor();
                    label.Name = "label" + i + "" + j;
                    label.Text = board.getFigures()[i].getCells()[j].getNumberBT().ToString();
                    label.Size = new Size(50, 50);
                    label.Location = new Point(board.getFigures()[i].getCells()[j].getCoordenate().getX() * 50+800, board.getFigures()[i].getCells()[j].getCoordenate().getY() * 50);
                    labels.Add(label);

                    if (j == 0)
                    {
                        if (board.getFigures()[i].getOperation() == 0)
                            label.Text = label.Text + "\n\n(" + board.getFigures()[i].getOperationResult().ToString() + "+)";
                        else
                            label.Text = label.Text + "\n\n(" + board.getFigures()[i].getOperationResult().ToString() + "*)";
                    }
                }
            }
            /*
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // Here you can modify the value of the textbox which is at textBoxes[i]

                    Label label = new Label();
                    label.BackColor = cells[i][j].getColor();
                    label.Name = "label" + i * 2 + "" + j * 2;
                    label.Text = cells[j][i].getNumberBT().ToString();
                    label.Size = new Size(50, 50);
                    label.Location = new Point(cells[i][j].getCoordenate().getX() * 50 + 800, cells[i][j].getCoordenate().getY() * 50);
                    labels.Add(label);

                }
            }*/
            for (int i = 0; i < (2 * n * m); i++)
            {
                form.panel1.Controls.Add(labels[i]);
                labels[i].Refresh();
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
                Thread.Sleep(100);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            listThread.Clear();
            board = null;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
    /*
    public labelsRefresh()
    {
        Thread.Sleep(100);
        for (int i=0; i<)
    }*/
}
