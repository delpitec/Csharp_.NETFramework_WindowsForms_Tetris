using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Entities.DataBase;
using Tetris.Entities.Enums;


namespace Tetris.Entities
{
    public class InterfaceDBandGame
    {
        public List<ScoreBoardItems> ScoreBoardItemsList { get; set; } = new List<ScoreBoardItems>();
        public ScoreBoardItems NewScoreBoardData { get; private set; } = new ScoreBoardItems();
        public Connection _connection { get; private set; } = new Connection();

        public InterfaceDBandGame()
        {

        }


        public void RefreshLocalScoreBoard()
        {
            _connection.SendCommand(ScoreBoardCommand.read, this);
            Console.WriteLine(this);
        }

        public ScoreBoardItems ReadLocalScoreBoard(int item)
        {
            return ScoreBoardItemsList.ElementAt(item);
        }

        public int LocalScoreBoardItemsQty()
        {
            return ScoreBoardItemsList.Count();
        }

        public ScoreBoardItems ReadDataBaseScoreBoard(int item)
        {
            _connection.SendCommand(ScoreBoardCommand.read, this);
            return ScoreBoardItemsList.ElementAt(item);
        }

        public void WriteScoreBoard(string addName, int addScore)
        {
            NewScoreBoardData.PlayerName = addName;
            NewScoreBoardData.Score = addScore;
            _connection.SendCommand(ScoreBoardCommand.write, this);
        }

        public override string ToString()
        {
            StringBuilder completeString = new StringBuilder();

            completeString.AppendLine("");

            foreach (ScoreBoardItems row in ScoreBoardItemsList)
            {
                completeString.AppendLine(row.PlayerName + " | " + row.Score);
            }

            return completeString.ToString();
        }

    }
}
