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
    /// Interaction logic for BoardZone.xaml
    /// </summary>
    public partial class BoardZone : UserControl
    {
        private  Cell[,] _cells;

        public BoardZone()
        {
            InitializeComponent();
         
            _cells = new Cell[3, 3];

            StackPanel verticalStackPanel = new StackPanel() {Orientation = Orientation.Vertical};

            for (int i = 0; i < 3; i++)
            {
                StackPanel horizontalStackPanel = new StackPanel() {Orientation = Orientation.Horizontal};

                for (int j = 0; j < 3; j++)
                {
                    Cell cell = new Cell();
                    _cells[i, j] = cell;
                    horizontalStackPanel.Children.Add(cell);
                }
                verticalStackPanel.Children.Add(horizontalStackPanel);
            }
            this.CellContainer.Child = verticalStackPanel;

        }

    }
}