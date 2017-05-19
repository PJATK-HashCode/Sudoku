
namespace Sudoku
{
    /// <summary>
    /// Moja piękna struktura do mojego pięknego algorytmu, nie usuwać kiedyś naprawie
    /// jMerta
    /// </summary>
    internal struct Square
    {
        public int Across { get; set; }
        public int Down { get; set; }
        public int Region { get; set; }
        public int Value { get; set; }
        public int Index { get; set; }

        public Square GetSquareItem(int n, int v)
        {
            n += 1;
            Across = GetAcrossFromNumber(n);
            Down = GetDownFromNumber(n);
            Region = GetRegionFromNumber(n);
            Value = v;
            Index = n - 1;
            return this;
        }

        private static int GetRegionFromNumber(int n)
        {
            int k = 0;
            int a = GetAcrossFromNumber(n);
            int d = GetDownFromNumber(n);

            if (1 <= a && a < 4 && 1 <= d && d < 4) k = 1;
            else if (4 <= a && a < 7 && 1 <= d && d < 4) k = 2;
            else if (7 <= a && a < 10 && 1 <= d && d < 4) k = 3;
            else if (1 <= a && a < 4 && 4 <= d && d < 7) k = 4;
            else if (4 <= a && a < 7 && 4 <= d && d < 7) k = 5;
            else if (7 <= a && a < 10 && 4 <= d && d < 7) k = 6;
            else if (1 <= a && a < 4 && 7 <= d && d < 10) k = 7;
            else if (4 <= a && a < 7 && 7 <= d && d < 10) k = 8;
            else if (7 <= a && a < 10 && 7 <= d && d < 10) k = 9;

            return k;
        }

        private static int GetDownFromNumber(int n)
        {
            if (GetAcrossFromNumber(n) == 9) return n / 9;
            return n / 9 + 1;
        }

        private static int GetAcrossFromNumber(int n)
        {
            var k = n % 9;
            return k == 0 ? 9 : k;
        }
    }
}