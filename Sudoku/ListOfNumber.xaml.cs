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
    /// Interaction logic for ListOfNumber.xaml
    /// </summary>
    public partial class ListOfNumber : UserControl
    {
        public Cell Cell { get; set; }

        public ListOfNumber(Cell cell)
        {
            this.Cell = cell;
            InitializeComponent();
            FillBox();
        }

        private void FillBox()
        {
            for (int i = 1; i < 10; i++)
            {
                List.Items.Add(i);
            }
        }

        private void ListOfNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cell.CellListBox.Text = List.SelectedItem.ToString();
            Cell.CloseWindow();
        }
    }
}