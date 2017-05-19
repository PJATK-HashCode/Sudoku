using System;
using System.Windows;

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
                }
            }
            Board.FillBoard();
            Board.Counter++;
        }

        private void Check_Game(object sender, RoutedEventArgs e)
        {
            if (!IsGameStarted) return;
            SetCheckButtonWindow(Board.Check()
                ? "Gratulacje! Poprawnie rozwiązałęś planszę!"
                : "Niestety, to nie jest prawidłowe rozwiązanie :<");
        }

        private void SetCheckButtonWindow(string msg)
        {
            CheckButtonWindow checkButtonWindow =
                new CheckButtonWindow(this) {EndGame = {Content = msg}};

            _window = new Window()
            {
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                WindowStyle = WindowStyle.None,
                Height = 75,
                Width = 500,
                Content = checkButtonWindow
            };
            _window.Show();
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