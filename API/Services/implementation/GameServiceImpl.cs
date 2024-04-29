
using Connect4.API.Models;
using Connect4.API.Services;
public class GameServiceImpl : IGameService
{
    private Board board;
    private Game game;
    private PlayerServiceImpl playerService;
    private List<Player> players = new List<Player>();
    public GameServiceImpl()
    {
        playerService = new PlayerServiceImpl();
        players = playerService.getPlayers().Result;
        createGame();
    }
    public Game getGame()
    {
        return game;
    }
    public Board getBoard()
    {
        return board;
    }
    public Task<List<Player>> getPlayers()
    {
        return Task.FromResult(players);
    }
    public Task<Player> getPlayerById(int PlayerId)
    {
        return Task.FromResult(players.FirstOrDefault(player => player.Id == PlayerId));
    }
    public Task<List<Row>> getPlays()
    {
        return Task.FromResult(game.Plays);
    }
    public Task<Game> createGame()
    {
        game = new Game();
        game.Plays = new List<Row>();
        board = new Board();
        board.Rows = new List<Row>();
        for(int i = 0; i < 6; i++)
        {
            Row row = new Row();
            row.Id = i;
            row.Cell = "0000000";
            board.Rows.Add(row);
        }
        game.GameBoard = board;
        game.Players = playerService.getPlayers().Result;
        return Task.FromResult(game);
    }
    public Task<Board> executePlay(int PlayerId, int RowId, string Play)
    {
        //get game
        Game _game = this.getGame();
        _game.Plays.Add(new Row(Play));
        //get row based on id
        Board _board = this.getBoard();
        foreach(Row row in _board.Rows)
        {
            if(row.Id == RowId)
            {
                row.Cell = Play;
                Player player = playerService.getPlayerById(PlayerId).Result;
                player.Plays.Add(row);
                break;
            }
        }
        return Task.FromResult(board);
    }
}
