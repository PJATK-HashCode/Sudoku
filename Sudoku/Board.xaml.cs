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
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class Board : UserControl
    {
        private BoardZone[,] _zones;

        public Board()
        {
            InitializeComponent();
           
            _zones = new BoardZone[3,3];
            StackPanel verticalStackPanel = new StackPanel() { Orientation = Orientation.Vertical };

            for (int i = 0; i < 3; i++)
            {
                StackPanel horizontalStackPanel = new StackPanel() { Orientation = Orientation.Horizontal };

                for (int j = 0; j <3 ; j++)
                {
                    BoardZone zone = new BoardZone();
                    _zones[i, j] = zone;
                    horizontalStackPanel.Children.Add(zone);
                }

                verticalStackPanel.Children.Add(horizontalStackPanel);
            }
            this.SudokuBoardContainer.Child = verticalStackPanel;

        }

    }
}
