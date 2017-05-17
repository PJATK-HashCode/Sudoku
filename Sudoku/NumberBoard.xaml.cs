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
    /// Interaction logic for NumberBoard.xaml
    /// </summary>
    public partial class NumberBoard : UserControl
    {
        private readonly NumberButton[,] _button = new NumberButton[3, 3];
        public Cell Cell { get; set; }

        public NumberBoard(Cell cell)
        {
            this.Cell = cell;
            InitializeComponent();
            int k = 1;
            StackPanel verticalStackPanel = new StackPanel() {Orientation = Orientation.Vertical};

            for (int i = 0; i < 3; i++)
            {
                StackPanel horizonstalStackPanel = new StackPanel() {Orientation = Orientation.Horizontal};
                
                for (int j = 0; j < 3; j++)
                {
                    NumberButton nb = new NumberButton(cell);
                    _button[i, j] = nb;                  
                    nb.ButtonNumber.Content = k.ToString();
                    k++;
                    horizonstalStackPanel.Children.Add(nb);
                }

                verticalStackPanel.Children.Add(horizonstalStackPanel);
            }
            this.NumberContainer.Child = verticalStackPanel;
        }
     
    }
}