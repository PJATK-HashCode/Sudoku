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
using Sudoku.model;
using Sudoku.service;

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Board _board = new Board();
        private static BoardZone[,] _zones;

        public MainWindow()
        {
            InitializeComponent();
          //  this.GridCointainer.Child = _board;
            InitializeComponent();

            _zones = new BoardZone[3, 3];
            StackPanel gridStackPanel = new StackPanel() { Orientation = Orientation.Vertical };

            for (int i = 0; i < 3; i++)
            {
                StackPanel rowStackPanel = new StackPanel() { Orientation = Orientation.Horizontal };

                for (int j = 0; j < 3; j++)
                {
                    BoardZone zone = new BoardZone();
                    _zones[i, j] = zone;
                    rowStackPanel.Children.Add(zone);
                }

                gridStackPanel.Children.Add(rowStackPanel);
            }
            this.GridCointainer.Child = gridStackPanel;

        }
    }

  

     
        
      
    
}
