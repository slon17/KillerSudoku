﻿using System;
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
            int size = 5;
            Random r = new Random();
            Console.WriteLine(r.Next(0));
            Board board = new Board(size);
            
            //board.generateBoard();
            board.generateNumbers();
            //board.printBoardCoord();
            board.printBoard();
            board.suffleNumbers(30);
            //board.printBoardCoord();
            board.printBoard();
            
            board.generateFigures();
            //Console.WriteLine(board.getFigures()[0].getCells()[0].getCoordenate().getX()+" "+ board.getFigures()[0].getCells()[0].getCoordenate().getY());
            board.asignNumberFigure();

            Backtracking backtracking = new Backtracking(board);
            
            List<Thread> list = new List<Thread>();
            for(int i=0; i<3; i++)
            {
                Thread th = new Thread(()=>method(backtracking, board));
                th.Name = i.ToString();
                list.Add(th);
            }

            for(int i=0; i<3; i++)
            {
                list[i].Start();
                Thread.Sleep(10);
                //list[i].Join();
                Console.WriteLine(i);
            }
            
            //backtracking.resolve(board);
            CreateLabels(form1, board, size, size);
            
            //Application.Run(form1);

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
                    label.BackColor = cells[j][i].getColor();
                    label.Name = "label" + i + "" + j;
                    label.Text = cells[j][i].getNumber().ToString();
                    label.Size = new Size(50, 50);
                    label.Location = new System.Drawing.Point(cells[j][i].getCoordenate().getX() *50, cells[j][i].getCoordenate().getY() * 50);
                    labels.Add(label);
                }
            }
            for (int i = 0; i < n*m; i++)
            {
                
                    form.panel1.Controls.Add(labels[i]);
                
            }
        }

        public static void method(Backtracking backtracking, Board board)
        {
            backtracking.resolve(board);
        }
    }
}
