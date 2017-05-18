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
        private static readonly Board Board = new Board();

        public MainWindow()
        {
            InitializeComponent();
            InitializeBoard();
        }


        private void InitializeBoard()
        {
            this.BoardCointainer.Child = Board;
        }


        private void New_Game(object sender, RoutedEventArgs e)
        {
            IsGameStarted = true;
            for (int i = 0; i<9; i++)
            {
                for (int j = 0; j<9; j++)
                {
                    Board._sudokuBoard[i, j] = Board._sudokuTemplate[i, j];
                }
            }
            Board.fillBoard();
            Board.counter++;


        }

        private void Check_Game(object sender, RoutedEventArgs e)
        {
            if (IsGameStarted)
            {
                if (Board.check()){
                    Application.Current.Shutdown();
                }
            }

        }

        public static bool IsGameStarted { get; private set; } = false;

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}