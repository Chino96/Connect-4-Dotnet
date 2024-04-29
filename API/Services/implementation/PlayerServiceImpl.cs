using Connect4.API.Models;

namespace Connect4.API.Services
{
    public class PlayerServiceImpl : IPlayerService
    {
        List<Player> _Players;
        public PlayerServiceImpl()
        {
            _Players = initPlayers();
        }
        private List<Player> initPlayers()
        {
            List<Player> players = new List<Player>();
            Player player0 = createPlayer(1, "Player1", "password");
            Player player1 = createPlayer(2, "Player2", "password");
            players.Add(player0);
            players.Add(player1);
            return players;
        }
        private Player createPlayer(int PlayerId, String Username, String Password)
        {
            Player player = new Player();
            player.Id = PlayerId;
            player.Username = Username;
            player.Password = Password;
            player.Plays = new List<Row>();
            return player;
        }
        public Task<Row> createPlay(int PlayerId, int ColumnId, int RowId, String Cell)
        {
            Row row = new Row();
            row.Id = RowId;
            Cell = Cell.Insert(ColumnId, PlayerId.ToString());
            Cell = Cell.Remove(ColumnId+1, 1);
            row.Cell = Cell;
            return Task.FromResult(row);
        }
        public Task<List<Player>> getPlayers()
        {
            return Task.FromResult(_Players);
        }
        public Task<Player> getPlayerById(int id)
        {
            return Task.FromResult(_Players.FirstOrDefault(player => player.Id == id));
        }

        public Task<string> getPlayerPassword(int Id)
        {
            Player player = _Players.FirstOrDefault(player => player.Id == Id);
            return Task.FromResult(player.Password);
        }

        public Task<string> getPlayerUsername(int Id)
        {
            Player player = _Players.FirstOrDefault(player => player.Id == Id);
            return Task.FromResult(player.Username);
        }

        public Task<List<Row>> getPlayerPlays(int Id)
        {
            Player player = _Players.FirstOrDefault(player => player.Id == Id);
            return Task.FromResult(player.Plays);
        }
        public void AppendPlay(int Id, int rowId, String play)
        {
            Player player = _Players.FirstOrDefault(player => player.Id == Id);
            Row row = new Row();
            row.Id = rowId;
            row.Cell = play;
            player.Plays.Add(row);
        }
        public void SetPlayerPassword(int Id, string Password)
        {
            _Players.FirstOrDefault(player => player.Id == Id).Password = Password;
        }

        public void SetPlayerUsername(int Id, string Username)
        {
            _Players.FirstOrDefault(player => player.Id == Id).Username = Username;
        }
        
    }
}