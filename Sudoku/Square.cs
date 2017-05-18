using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{

    /// <summary>
    /// Moja piękna struktura do mojego pięknego algorytmu, nie usuwać kiedyś naprawie
    /// jMerta
    /// </summary>
    struct Square
    {
        public int across { get; set; }
        public int down { get; set; }
        public int region { get; set; }
        public int value { get; set; }
        public int index { get; set; }
        public Square getSquareItem(int n, int v)
        {
            
            n += 1;
            this.across = getAcrossFromNumber(n);
            this.down = getDownFromNumber(n);
            this.region = getRegionFromNumber(n);
            this.value = v;
            this.index = n - 1;
            return this;
        }

        private int getRegionFromNumber(int n)
        {
            int k = 0;
            int a = getAcrossFromNumber(n);
            int d = getDownFromNumber(n);

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

        private int getDownFromNumber(int n)
        {
            int k;
            if (getAcrossFromNumber(n) == 9) return k = n / 9;
            else return k = n / 9 + 1;
        }

        private int getAcrossFromNumber(int n)
        {
            int k;
            k = n % 9;
            if (k == 0) return 9;
            return k;
        }
    }
}
