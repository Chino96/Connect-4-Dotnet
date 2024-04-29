using Connect4.API.Models;

namespace Connect4.API.Services
{
    public interface IGameService
    {
        Task<List<Player>> getPlayers();
        Task<Board> executePlay(int PlayerId, int RowId, string Play);
        Task<Game> createGame();
        Game getGame();
        Board getBoard();
        Task<Player> getPlayerById(int PlayerId);
        Task<List<Row>> getPlays();
    }
}