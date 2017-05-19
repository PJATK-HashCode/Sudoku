using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

namespace SudokuTests
{
    [TestClass]
    public class SudokuTests
    {
        [TestMethod]
        public void check_if_check_works()
        {
            Board board = new Board();

            Cell[,] cell = new Cell[9, 9];

            int checker = 1;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    cell[i, j].Content(board._solvedTemplate[i,j].ToString());
                    checker *= int.Parse(cell[i, j].getBox().Text);
                }
            }


            Assert.AreEqual(362880 * 9,checker);
        }
    }
}