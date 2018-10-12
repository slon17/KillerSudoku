﻿using System;
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
            Board board = new Board(9);
            board.generateFigures();
            //board.generateBoard();
            board.generateNumbers();
            board.suffleNumbers(30);

            CreateLabels(form1, board, 9, 9);
            Application.Run(form1);

        }

        static void CreateLabels(Form1 form, Board board, int n, int m)
        {
            List<List<Cell>> cells = board.getCells();
            Label[,] labels = new Label[n, m];
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
                    label.Location = new System.Drawing.Point(i * 50, j * 50);
                    labels[i, j] = label;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    form.panel1.Controls.Add(labels[i, j]);
                }
            }
        }
    }
}
