# Game Tetris using C# and Windows Forms (.NET Framework)

**Project description:**<br>
The project consists of the development of the world-famous Tetris game. The game implementation was done through matrices running the specific encoding for each board element, that is updated with each action on the form (Frontend). TOP10 scores are recorded in a SQL Server database with name and score fields.

![tetris](https://user-images.githubusercontent.com/58537514/127382046-94da4e51-167d-4a98-96e6-000eaefa2ee6.png)

**Project status:**<br>
⏳ Developing 

**Project steps:**<br>
> Gameboard: <br>
  ✅ Gameboard (front)<br>
  ✅ Gameboard (back)<br>

> Pieces: <br>
  ✅ Pieces design<br>
  ✅ Piece movimentations<br>

> Game intelligence:<br>
  ✅ Piece colision<br>
  ✅ Wall colision<br>
  ❌ Speed acceleration according game time duration <br>
  ✅ Full line detection<br>
  ✅ Scoreboard refresh<br>
  ✅ End game detection<br>
  ✅ Game pause<br>
  ✅ Game restart<br>
  ✅ Game exit<br>
  
> Forms:<br>
  ❌ Init game form<br>
  ✅ Play Form<br>
  ✅ Edit player name form<br>
  ❌ Edit level dificult form<br>
  ❌ Edit window theme form (colors)<br>
  ✅ Game over form<br>
  ✅ Highscores form<br>
 
> SQL Server communication:<br>
  ✅ Read highscores stored - Top10<br>
  ✅ Write new high score<br>
  
  
 &nbsp;<br><br> 

**Create the following SQL Server Data Base and column tables:**<br>

```ruby
CREATE DATABASE TetrisDataBase

CREATE TABLE HighScores (
 PlayerName VARCHAR(50),
 Pontuation INT  
 );

INSERT INTO HighScores (PlayerName,Pontuation)
VALUES 
('None',0),
('None',0),
('None',0),
('None',0),
('None',0),
('None',0),
('None',0),
('None',0),
('None',0),
('None',0);

```

**Connection string info:**<br>
This example I am using defaul user: User: sa | Password: (no password) as we can see in the following String Connection:<br><br>
Tetris>Entities>DataBase>Connection<br>
```ruby
public Connection()
        {
            //SQL server connection string
            _connection.ConnectionString = @"Persist Security Info=False;User ID=sa;Initial Catalog=TetrisDataBase;Data Source=(local)";
        }
```

 &nbsp;<br><br> 

## Contact me:
💼[LinkedIn](https://br.linkedin.com/in/rafaeldelpino)&nbsp;&nbsp;&nbsp;
📹[Youtube](https://www.youtube.com/delpitec)&nbsp;&nbsp;&nbsp;
📸[Instagram](https://www.instagram.com/delpitec_/)&nbsp;&nbsp;&nbsp;
📧[E-mail](delpitec@gmail.com)&nbsp;&nbsp;&nbsp;
