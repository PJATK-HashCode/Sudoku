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
        private static Template _template = new Template();
        private static readonly Board Board = new Board(_template);

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
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                   _template.SudokuBoard[i, j] = _template.SudokuTemplate[i, j];
                }
            }
            Board.FillBoard();
            Board.Counter++;
        }

        private void Check_Game(object sender, RoutedEventArgs e)
        {
            if (IsGameStarted)
            {
                MessageBox.Show(Board.Check() ? "Gratulacje! Prawidłowe rozwiązanie!" : "Błąd. Spróbuj jeszcze raz");
            }
        }

        public static bool IsGameStarted { get; private set; } = false;

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}