using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connect4.API.Models;
using Connect4.API.Services;

namespace Api.Tests.Services
{
    internal class GameServiceTest
    {
        private GameServiceImpl gameService;

        [SetUp]
        public void Setup()
        {
            gameService = new GameServiceImpl();
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Test_GetPlayerFromGame(int PlayerId)
        {
            Player player = gameService.getPlayerById(PlayerId).Result;
            int? Id = player.Id;
            String? Username = player.Username;
            String? Password = player.Password;
            List<Row>? rows = player.Plays;

            switch(Id)
            {
                case > 2:Assert.Fail(); break;
                case < 1:Assert.Fail(); break; 
            }
            if((Username != "Player1" && Id == 1) || (Username != "Player2" && Id == 2))
                Assert.Fail();

            if(Password.Length > 8 || Password.Length < 6)
                Assert.Fail();

            if(player.Plays.Count > 0 || player.Plays == null)
                Assert.Fail();
            

            Assert.Pass();
        }

        [TestCase(1, 0,"0001000")]
        public void Test_ExecutePlay(int PlayerId, int rowId, string play)
        {
            Game game = gameService.getGame();
            gameService.executePlay(PlayerId, rowId, play);

            int i = 0;
            Board board = game.GameBoard;
            List<Row> rows = board.Rows;
            foreach(Row row in rows)
            {
                if(row.Id == rowId)
                {
                    if(row.Cell != play)
                    {
                        Assert.Fail();
                    }
                }
                i++;
            }

            Assert.Pass();
        }

        [Test]
        public void Test_CreateGame()
        {
            Game game = gameService.getGame();
            int i = 1;
            foreach(Player player in game.Players)
            {
                if(player.Id != i)
                {
                    Assert.Fail();
                }
                i++;
            }

            Board board = game.GameBoard;
            List<Row> rows = board.Rows;
            foreach(Row row in rows)
            {
                if(row.Cell != "0000000")
                {
                    Assert.Fail();
                }
            }

            Assert.Pass();
        }
    }

}
