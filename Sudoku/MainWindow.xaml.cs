using System;
using System.Windows;
using System.Windows.Media;

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private new static readonly Template Template = new Template();
        private static readonly Board Board = new Board(Template);
        private Window _window;

        public MainWindow()
        {
            InitializeComponent();
            InitializeBoard();
        }


        private void InitializeBoard()
        {
            BoardCointainer.Child = Board;
        }


        private void New_Game(object sender, RoutedEventArgs e)
        {
            IsGameStarted = true;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Template.SudokuBoard[i, j] = Template.SudokuTemplate[i, j];
                    Board.Cells[i, j].CellTextBox.Background = Brushes.WhiteSmoke;
                }
            }
            Board.FillBoard();
            Board.Counter++;
        }

    
        public static bool IsGameStarted { get; private set; }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void CloseCheckButtonWindow()
        {
            _window.Close();
        }
    }
}