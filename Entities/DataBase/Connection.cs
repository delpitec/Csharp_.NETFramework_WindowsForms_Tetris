using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Entities.DataBase;
using Tetris.Entities.Enums;

namespace Tetris.Entities
{
    public class Connection
    {

        public SqlConnection _connection { get; set; } = new SqlConnection();
        public SqlCommand _command { get; set; } = new SqlCommand();
        public SqlDataReader _dataReader { get; set; }

        public Connection()
        {
            //SQL server connection string
            _connection.ConnectionString = @"Persist Security Info=False;User ID=sa;Initial Catalog=TetrisDataBase;Data Source=(local)";
        }

        public void SendCommand(ScoreBoardCommand command, InterfaceDBandGame interfaceDBandGame)
        {
            if (command == ScoreBoardCommand.read)
            {
                try
                {
                    _command.Connection = Connect();
                    _command.CommandText = "select * from dbo.HighScores order by Pontuation desc";
                    _dataReader = _command.ExecuteReader();

                    // read all lines that contains data
                    while (_dataReader.Read())
                    {
                        string _playerName = _dataReader[0].ToString();
                        int _score = Convert.ToInt32(_dataReader[1]);
                        interfaceDBandGame.ScoreBoardItemsList.Add(new ScoreBoardItems(_playerName, _score));
                    }
                }
                catch (SqlException Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
                finally
                {
                    _command.Connection = Disconnect();
                }
            }
            else if (command == ScoreBoardCommand.write)
            {
                try
                {
                    _command.Connection = Connect();
                    
                    // Add to SQL Server table new name and pontuation (according passing class)
                    _command.CommandText = $"insert into dbo.HighScores values ('{interfaceDBandGame.NewScoreBoardData.PlayerName}',{interfaceDBandGame.NewScoreBoardData.Score})";
                    _command.ExecuteNonQuery();
                    
                    // Delete last row (according last pontuation)
                    _command.CommandText = "with cte as(select top 1 * from dbo.HighScores order by Pontuation) delete from cte";
                    _command.ExecuteNonQuery();
                }
                catch (SqlException Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
                finally
                {
                    _command.Connection = Disconnect();
                }
            }
            else
                ;
        }

        private SqlConnection Connect()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
            return _connection;
        }

        private SqlConnection Disconnect()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
            return _connection;
        }
    }
}
