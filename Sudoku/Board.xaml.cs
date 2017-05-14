using System;
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
        private Cell[,] _cells;
        private int[,] _sudokuArray;
        private readonly int CONTROL_NUMBER = 362880;
        private int sum = 1;


        public Board()
        {
            InitializeComponent();

            _cells = new Cell[3, 3];

            StackPanel verticalStackPanel = new StackPanel() {Orientation = Orientation.Vertical};

            for (int i = 0; i < 3; i++)
            {
                StackPanel horizontalStackPanel = new StackPanel() {Orientation = Orientation.Horizontal};

                for (int j = 0; j < 3; j++)
                {
                    Cell cell = new Cell();
                    _cells[i, j] = cell;
                    horizontalStackPanel.Children.Add(cell);
                }
                verticalStackPanel.Children.Add(horizontalStackPanel);
            }
            this.CellContainer.Child = verticalStackPanel;
        }

        public void PopulateBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _cells[i, j].Content(Puzzles()[i, j].ToString());
                }
            }
        }

        private int[,] Puzzles()
        {
            _sudokuArray = GenerateArray();

            int sum2 = 1;
            sum = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sum *= _sudokuArray[i, j];
                }
            }
            if (sum != CONTROL_NUMBER)
            {
                sum = 1;
                Puzzles();
            }
            return _sudokuArray;
        }

        private int[,] GenerateArray()
        {
            int[,] arr = new int[3, 3];
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arr[i, j] = random.Next(1, 10);
                }
            }
            return arr;
        }
    }
}
