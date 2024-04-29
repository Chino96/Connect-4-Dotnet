using Connect4.API.Models;
using Connect4.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Connect4.API.Controllers
{
    [Route("api/Game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("CreateGame")]
        public Task<Game> CreateGame()
        {
            Game game = _gameService.getGame();
            return Task.FromResult(game);
        }

        [HttpGet("GetGameLastPlay")]
        public Task<Row> GetPlayerLastPlay(int PlayerId)
        {
            List<Row> plays = _gameService.getPlays().Result;
            Row latestPlay = plays[plays.Count-1];
            return Task.FromResult(latestPlay);
        }

        [HttpGet("GetGameBoard")]
        public Task<Board> GetGameBoard()
        {
            Board board = _gameService.getBoard();
            //get game board from game service
            return Task.FromResult(board);
        }

        [HttpGet("ExecutePlay")]
        public async Task<Board> ExecutePlay( int PlayerId, int RowId, String play)
        {
            Board board = _gameService.getBoard();
            //use game service to execute play
            board = await _gameService.executePlay(PlayerId, RowId, play);
            return board;
        }
    }
}