using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Entities.DataBase
{
    public class ScoreBoardItems
    {
        public string PlayerName { get; set; }

        public int Score { get; set; }

        public ScoreBoardItems()
        {
            PlayerName = "";
            Score = 0;
        }

        public ScoreBoardItems(string playerName, int score)
        {
            PlayerName = playerName;
            Score = score;
        }
    }
}
