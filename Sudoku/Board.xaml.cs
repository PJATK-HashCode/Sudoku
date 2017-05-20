using System.Windows.Controls;


namespace Sudoku
{
    public partial class Board
    {
        private readonly Cell[,] _cells;
        public int Counter = 0;
        public int Loop = 0;
        private readonly Template _template;

        // private List<int> _available = new List<int>(81);
        // private List<Square> squares = new List<Square>(81);
        //private int _sum = 1;
        //private int _squareNumb = 0;

        public Board(Template template)
        {
            _template = template;
            InitializeComponent();

            _cells = new Cell[9, 9];

            StackPanel verticalStackPanel = new StackPanel() {Orientation = Orientation.Vertical};

            for (int i = 0; i < 9; i++)
            {
                StackPanel horizontalStackPanel = new StackPanel() {Orientation = Orientation.Horizontal};

                for (int j = 0; j < 9; j++)
                {
                    Cell cell = new Cell();
                    _cells[i, j] = cell;
                    horizontalStackPanel.Children.Add(cell);
                }
                verticalStackPanel.Children.Add(horizontalStackPanel);
            }
            CellContainer.Child = verticalStackPanel;
        }

        public bool Check()
        {
            int checkCounter = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (string.IsNullOrEmpty(_cells[i, j].CellTextBox.Text)) continue;
                    if (_cells[i, j].CellTextBox.Text == _template.SolvedTemplate[i, j].ToString())

                    {
                        checkCounter++;
                    }
                }
            }
            return checkCounter == 81;
        }


        public void FillBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    _cells[i, j].Content(_template.SudokuTemplate[i, j].ToString());
                }
            }
        }
    }
    // Mój piękny algorytm do sudoku! Nie usuwać, kiedyś go naprawię by działał!!!!
    //jMerta

    //public void fillCells()
    //{
    //    for (int i = 0; i < _available.Count; i++)
    //    {
    //        for (int j = 1; j <= 9; j++)
    //        {
    //            _available.Add(j);
    //        }
    //    }

    //    while (squareNumb <= 81)
    //    {
    //        if (_available.Count != 0)
    //        {
    //            Random random = new Random();
    //            int x = random.Next(0, _available.Count);
    //            int z = _available.ElementAt(x);
    //            Square square = new Square();
    //            if (!conflicts(squares, square.getSquareItem(squareNumb, z)))
    //            {
    //                squares.Add(square.getSquareItem(squareNumb, z));
    //                _available.Remove(x);
    //                squareNumb++;
    //            }
    //            else
    //            {
    //                _available.Remove(x);
    //            }
    //        }
    //        else
    //        {
    //            for (int y = 1; y <= 9; y++)
    //            {
    //                _available.Add(y);
    //            }
    //            foreach (Square square in squares)
    //            {
    //                squares.Remove(square);
    //            }
    //            squareNumb -= 1;
    //        }
    //    }
    //    //_cells[h, j].Content(squares.ElementAt(j).value.ToString());
    //    for (int h = 1; h <= 9; h++)
    //    {
    //        int loopCounter = 0;

    //        for (int j = 1; j <= 9; j++)
    //        {
    //            loopCounter++;
    //            try
    //            {
    //                Square square = new Square();

    //                _cells[h, j].Content(squares.ElementAt(loopCounter).value.ToString());
    //            }
    //            catch (Exception ex)
    //            {
    //                Console.Write(ex.Message);
    //            }
    //        }
    //    }
    //}


    //private Boolean conflicts(List<Square> squares, Square test)
    //{
    //    foreach (Square square in squares)
    //    {
    //        if (square.across != 0 && square.across == test.across &&
    //            square.down != 0 && square.down == test.down &&
    //            square.region != 0 && square.region == test.region)
    //        {
    //            if (square.value == test.value)
    //            {
    //                return true;
    //            }
    //        }
    //    }
    //    return false;
    //}
}