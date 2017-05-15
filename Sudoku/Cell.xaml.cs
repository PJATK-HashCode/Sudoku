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
    /// <summary>
    /// Interaction logic for Cell.xaml
    /// </summary>
    public partial class Cell : UserControl
    {
        private Window _window;

        public Cell()
        {
            InitializeComponent();
        }

        public void Content(String s)
        {
            this.CellListBox.Text = s;
        }

        private void CellListBox_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.IsGameStarted)
            {
                CellListBox.Background = Brushes.Aqua;
                ListOfNumber listOfNumber = new ListOfNumber(this);

                var mousePoint = Mouse.GetPosition(Application.Current.MainWindow);

                _window = new Window()
                {
                    ResizeMode = ResizeMode.NoResize,
                    WindowStartupLocation = WindowStartupLocation.Manual,
                    Left = mousePoint.X,
                    Top = mousePoint.Y,
                    Height = 220,
                    Width = 20,
                    Content = listOfNumber
                };

                _window.ShowDialog();
            }
        }

        public void CloseWindow()
        {
            _window.Close();
            CellListBox.Background = Brushes.White;
        }
    }
}