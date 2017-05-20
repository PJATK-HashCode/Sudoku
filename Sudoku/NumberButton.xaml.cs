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
    /// Interaction logic for NumberButton.xaml
    /// </summary>
    public partial class NumberButton : UserControl
    {
        public Cell Cell { get; set; }

        public NumberButton(Cell cell)
        {
            this.Cell = cell;
            InitializeComponent();
        }

        private void ButtonNumber_Click(object sender, RoutedEventArgs e)
        {
            var value = ButtonNumber.Content.ToString();
            Cell.CellTextBox.Text = value;
            var template = new Sudoku.Template();

            Cell.CellTextBox.Background = value != template.SolvedTemplate[Cell.X, Cell.Y].ToString() ? Brushes.OrangeRed : Brushes.DarkSeaGreen;
            Cell.CloseWindow();
        }
    }
}
