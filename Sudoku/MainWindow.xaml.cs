using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;


namespace Sudoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Board[,] _board;
        private static Boolean _isGameStarted = false;

        public MainWindow()
        {
            InitializeComponent();
            InitializeBoard();
        }


        private void InitializeBoard()
        {
            _board = new Board[3, 3];
            StackPanel verticalStackPanel = new StackPanel() {Orientation = Orientation.Vertical};

            for (int i = 0; i < 3; i++)
            {
                StackPanel horizonstalStackPanel = new StackPanel() {Orientation = Orientation.Horizontal};

                for (int j = 0; j < 3; j++)
                {
                    Board zone = new Board();
                    _board[i, j] = zone;
                    horizonstalStackPanel.Children.Add(zone);
                }

                verticalStackPanel.Children.Add(horizonstalStackPanel);
            }
            this.BoardCointainer.Child = verticalStackPanel;
        }


        private void New_Game(object sender, RoutedEventArgs e)
        {
            _isGameStarted = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _board[i, j].PopulateBoard();
                }
            }
        }

        public static bool IsGameStarted => _isGameStarted;
    }
}