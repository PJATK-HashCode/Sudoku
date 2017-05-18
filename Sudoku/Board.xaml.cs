using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sudoku
{
    public partial class Board : UserControl
    {
        private List<Square> squares = new List<Square>(81);
        private int squareNumb = 0;
        private Cell[,] _cells;
        private int[,] _sudokuArray;
        private List<int> _available = new List<int>(81);
        private readonly int CONTROL_NUMBER = 362880;
        private int sum = 1;
        public int counter = 0;
        public int loop = 0;

        public int?[,] _sudokuBoard = new int?[9, 9]
        {
            {null,null,null,null,null,null,null,null,null },
            {null,null,null,null,null,null,null,null,null },
            {null,null,null,null,null,null,null,null,null },
            {null,null,null,null,null,null,null,null,null },
            {null,null,null,null,null,null,null,null,null },
            {null,null,null,null,null,null,null,null,null },
            {null,null,null,null,null,null,null,null,null },
            {null,null,null,null,null,null,null,null,null },
            {null,null,null,null,null,null,null,null,null },
        };

        public int?[,] _sudokuTemplate = new int?[9, 9]
        {
            {2,null,null,6,null,7,5,null,null },
            {null,8,null,3,null,4,null,9,6 },
            {6,null,7,null,null,1,3,null,null },
            {null,5,null,7,3,2,null,null,null },
            {null,7,null,4,6,null,null,2,null },
            {null,null,null,1,8,9,null,7,null },
            {null,null,3,5,null,null,6,null,4 },
            {8,4,null,null,1,null,2,null,7 },
            {null,null,5,2,null,6,null,null,8 },

            };

        public int[,] _solvedTemplate = new int[9, 9]
        {
             {2,3,4,6,9,7,5,8,1 },
            {5,8,1,3,2,4,7,9,6 },
            {6,9,7,8,5,1,3,4,2 },
            {4,5,8,7,3,2,1,6,9 },
            {1,7,9,4,6,5,8,2,3 },
            {3,6,2,1,8,9,4,7,5 },
            {9,2,3,5,7,8,6,1,4 },
            {8,4,6,9,1,3,2,5,7 },
            {7,1,5,2,4,6,9,3,8 },

        };



        public Board()
        {
            InitializeComponent();

            _cells = new Cell[9, 9];

            StackPanel verticalStackPanel = new StackPanel() { Orientation = Orientation.Vertical };

            for (int i = 0; i < 9; i++)
            {
                StackPanel horizontalStackPanel = new StackPanel() { Orientation = Orientation.Horizontal };

                for (int j = 0; j < 9; j++)
                {
                    Cell cell = new Cell();
                    _cells[i, j] = cell;
                    horizontalStackPanel.Children.Add(cell);
                }
                verticalStackPanel.Children.Add(horizontalStackPanel);
            }
            this.CellContainer.Child = verticalStackPanel;
        }




        // Mój piękny algorytm do sudoku! Nie usuwać, kiedyś go naprawię by działał!!!!
        //jMerta

        //public void fillCells()
        //{
        //    for (int i = 0; i < _available.Count; i++)
        //    {
        //        for (int j = 1; j <= 9; j++)
        //        {
        //            _available.Add(j);
        //        }
        //    }

        //    while (squareNumb <= 81)
        //    {
        //        if (_available.Count != 0)
        //        {
        //            Random random = new Random();
        //            int x = random.Next(0, _available.Count);
        //            int z = _available.ElementAt(x);
        //            Square square = new Square();
        //            if (!conflicts(squares, square.getSquareItem(squareNumb, z)))
        //            {
        //                squares.Add(square.getSquareItem(squareNumb, z));
        //                _available.Remove(x);
        //                squareNumb++;
        //            }
        //            else
        //            {
        //                _available.Remove(x);
        //            }
        //        }
        //        else
        //        {
        //            for (int y = 1; y <= 9; y++)
        //            {
        //                _available.Add(y);
        //            }
        //            foreach (Square square in squares)
        //            {
        //                squares.Remove(square);
        //            }
        //            squareNumb -= 1;
        //        }
        //    }
        //    //_cells[h, j].Content(squares.ElementAt(j).value.ToString());
        //    for (int h = 1; h <= 9; h++)
        //    {
        //        int loopCounter = 0;

        //        for (int j = 1; j <= 9; j++)
        //        {
        //            loopCounter++;
        //            try
        //            {
        //                Square square = new Square();

        //                _cells[h, j].Content(squares.ElementAt(loopCounter).value.ToString());
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.Write(ex.Message);
        //            }
        //        }
        //    }
        //}





        //private Boolean conflicts(List<Square> squares, Square test)
        //{
        //    foreach (Square square in squares)
        //    {
        //        if (square.across != 0 && square.across == test.across &&
        //            square.down != 0 && square.down == test.down &&
        //            square.region != 0 && square.region == test.region)
        //        {
        //            if (square.value == test.value)
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}


        public Boolean check()
        {

            int checkCounter = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (_cells[i, j].ToString().Equals( _solvedTemplate[i, j].ToString()))
                    {
                        checkCounter++;
                    }

                }
            }
            if (checkCounter == 81)
            {
                return true;
            }
            return false;

        }


        public void fillBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    _cells[i, j].Content(_sudokuTemplate[i, j].ToString());
                }
            }

        }
    }
}
