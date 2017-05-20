using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// <summary>
    /// Interaction logic for Cell.xaml
    /// </summary>
    public partial class Cell : UserControl
    {
        private Window _window;

        public int X { get; set; }
        public int Y { get; set; }
     
        public Cell()
        {
            InitializeComponent();
        }

        public void Content(string s)
        {
            CellTextBox.Text = s;
        }

        private void CellListBox_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!MainWindow.IsGameStarted) return;
            NumberBoard numberBoard = new NumberBoard(this);

            _window = new Window()
            {
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.Manual,
                Left=200,
                Top = 450,
                WindowStyle = WindowStyle.None,
                Height = 211,
                Width = 211,
                Content = numberBoard
            };
            _window.ShowDialog();
        }

        public void CloseWindow()
        {
            _window.Close();
        }

   
    }
}