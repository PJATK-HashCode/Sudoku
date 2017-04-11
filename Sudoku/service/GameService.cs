using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku.model;

namespace Sudoku.service
{
    class GameService
    {
        private Game _newGame;

        public GameService(Game newGame)
        {
            this._newGame = newGame;
        }
    }
}