
namespace Sudoku
{
    public class Template
    {
        public  int?[,] SudokuBoard =
        {
            {null, null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null, null},
        };

        public int?[,] SudokuTemplate =
        {
            {2, null, null, 6, null, 7, 5, null, null},
            {null, 8, null, 3, null, 4, null, 9, 6},
            {6, null, 7, null, null, 1, 3, null, null},
            {null, 5, null, 7, 3, 2, null, null, null},
            {null, 7, null, 4, 6, null, null, 2, null},
            {null, null, null, 1, 8, 9, null, 7, null},
            {null, null, 3, 5, null, null, 6, null, 4},
            {8, 4, null, null, 1, null, 2, null, 7},
            {null, null, 5, 2, null, 6, null, null, 8},
        };

        public int[,] SolvedTemplate =
        {
            {2, 3, 4, 6, 9, 7, 5, 8, 1},
            {5, 8, 1, 3, 2, 4, 7, 9, 6},
            {6, 9, 7, 8, 5, 1, 3, 4, 2},
            {4, 5, 8, 7, 3, 2, 1, 6, 9},
            {1, 7, 9, 4, 6, 5, 8, 2, 3},
            {3, 6, 2, 1, 8, 9, 4, 7, 5},
            {9, 2, 3, 5, 7, 8, 6, 1, 4},
            {8, 4, 6, 9, 1, 3, 2, 5, 7},
            {7, 1, 5, 2, 4, 6, 9, 3, 8},
        };
    }
}