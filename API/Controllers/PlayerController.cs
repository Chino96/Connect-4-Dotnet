using Connect4.API.Models;
using Connect4.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Connect4.API.Controllers
{
    [Route("api/Player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private IGameService _gameService;
        private PlayerServiceImpl _playerService;
        public PlayerController(IGameService gameService)
        {
            _gameService = gameService;
            _playerService = new PlayerServiceImpl();
        }

        [HttpGet("CreatePlayer")]
        public Task<Player> CreatePlayer(int Id, String tUsername, String tPassword)
        {
            //create Player Object
            Player player = new Player();
            player.Id = Id;
            player.Username = tUsername;
            player.Password = tPassword;
            return Task.FromResult(player);
        }

        [HttpGet("GetPlayerDetails")]
        public async Task<Player> GetPlayerDetails(int PlayerId)
        {
            Task<Player> playerTsk = _gameService.getPlayerById(PlayerId);
            Player player = playerTsk.Result;
            return player;
        }

        [HttpGet("GetPlayerLastPlay")]
        public Task<Row> GetPlayerLastPlay(int PlayerId)
        {
            Player player = _gameService.getPlayers().Result.FirstOrDefault(player => player.Id == PlayerId);
            Row latestPlay = player.Plays[player.Plays.Count-1];
            return Task.FromResult(latestPlay);
        }

        [HttpGet("CreatePlay")]
        public Task<Row> CreatePlay(int PlayerId, int ColumnId, int RowId, String OldCell)
        {
            Row play = _playerService.createPlay(PlayerId, ColumnId, RowId, OldCell).Result;
            return Task.FromResult(play);
        }

    }
}