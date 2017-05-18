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
            Board.fillCells();
            Board.counter++;


        }

        public static bool IsGameStarted { get; private set; } = false;

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}