using Connect4.API.Models;

namespace Connect4.API.Services
{
    public interface IPlayerService
    {
        Task<Player> getPlayerById(int id);
        Task<String> getPlayerUsername(int Id);
        Task<String> getPlayerPassword(int Id);
        Task<List<Row>> getPlayerPlays(int Id);
        void SetPlayerUsername(int Id, String Username);
        void SetPlayerPassword(int Id, String Password);
        void AppendPlay(int Id, int rowId, String play);
        Task<Row> createPlay(int PlayerId, int ColumnId, int RowId, String Cell);
    }
}