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
        private List<Square>  squares = new List<Square>(81);
        private int squareNumb = 0;
        private Cell[,] _cells;
        private int[,] _sudokuArray;
        private List<int> _available = new List<int>(81);
        private readonly int CONTROL_NUMBER = 362880;
        private int sum = 1;
        public int counter = 0;
        public int loop = 0;


        public Board()
        {
            InitializeComponent();

            _cells = new Cell[3,3];

            StackPanel verticalStackPanel = new StackPanel() {Orientation = Orientation.Vertical};

            for (int i = 0; i < 3; i++)
            {
                StackPanel horizontalStackPanel = new StackPanel() {Orientation = Orientation.Horizontal};

                for (int j = 0; j < 3; j++)
                {
                    Cell cell = new Cell();
                    _cells[i,j] = cell;
                    horizontalStackPanel.Children.Add(cell);
                }
                verticalStackPanel.Children.Add(horizontalStackPanel);
            }
            this.CellContainer.Child = verticalStackPanel;
        }
 


        public void fillCells()
        {
            for(int i = 0; i<_available.Count; i++)
            {
                for(int j=1; j <=9; j++)
                {
                    _available.Add(j);
                }
                
            }

            while(squareNumb <=81)
            {
                if( _available.Count != 0)
                {
                    Random random = new Random();
                    int x = random.Next(0, _available.Count );
                    int z = _available.ElementAt(x);
                    Square square = new Square();
                    if(!conflicts(squares, square.getSquareItem(squareNumb, z) ))
                        {
                        squares.Add(square.getSquareItem(squareNumb, z));
                        _available.Remove(x);
                        squareNumb++;
                    }
                    else
                    {
                        _available.Remove(x);
                    }
                }
                else
                {
                    for(int y = 1; y <=9; y++)
                    {
                        _available.Add(y);
                    }
                    foreach(Square square in squares)
                    {
                        squares.Remove(square);
                    }
                    squareNumb -= 1;
                }

            }
            //_cells[h, j].Content(squares.ElementAt(j).value.ToString());
            //for (int h = 1; h <=9; h++)
            //{
            //    int loopCounter = 0;

            //for (int j=1; j <= 9;j++)
            //{
            //        loopCounter++;
            //    try
            //    {
            //            Square square = new Square();

            //            _cells.Content(squares.ElementAt(loopCounter).value.ToString());
            //        }
            //    catch (Exception ex)
            //    {
            //        Console.Write(ex.Message);
            //    }
            //}
            
            foreach( Cell cell in _cells)
            {
                counter++;
                cell.Content(squares.ElementAt(counter).value.ToString());
            }
            
        }
        

        

        private Boolean conflicts(List<Square> squares,  Square test)
        {
            foreach(Square square in squares)
            {
                if(square.across != 0 && square.across == test.across &&
                    square.down != 0 && square.down == test.down &&
                    square.region != 0 && square.region == test.region)
                {
                    if (square.value == test.value)
                    {
                        return true;
                    }
                }
            }
            return false;
        }



       

        

        
    }
}