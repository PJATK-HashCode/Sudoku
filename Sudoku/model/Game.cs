using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku.service;

namespace Sudoku.model
{
    class Game
    {
        public int Score { get; set; }
        public BoardService BoardService { get; set; }
        public bool IsFinished { get; set; }
    }
}

