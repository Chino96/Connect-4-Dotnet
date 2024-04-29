using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connect4.API.Models;
using Connect4.API.Services;

namespace Api.Tests.Services
{
    internal class PlayerServiceTest
    {
        private PlayerServiceImpl playerService;

        [SetUp]
        public void Setup()
        {
            playerService = new PlayerServiceImpl();
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Test_GetPlayer(int PlayerId)
        {
            Player player = playerService.getPlayerById(PlayerId).Result;
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

            if(rows.Count > 0 || rows == null)
                Assert.Fail();
            

            Assert.Pass();
        }

        [TestCase(1, 0,"0001000")]
        public void Test_AppendPlay(int PlayerId, int rowId, string play)
        {
            playerService.AppendPlay(PlayerId, rowId, play);
            Player player = playerService.getPlayerById(PlayerId).Result;

            List<Row> rows = player.Plays;
            foreach(Row row in rows)
            {
                if(row.Id == rowId)
                {
                    if(row.Cell != play)
                    {
                        Assert.Fail();
                    }
                }
            }

            Assert.Pass();
        }

        [Test]
        public void Test_GetPlayers()
        {
            List<Player> players = playerService.getPlayers().Result;
            int i = 1;
            foreach(Player player in players)
            {
                if(player.Id != i)
                {
                    Assert.Fail();
                }
                if(player.Plays.Count > 0 || player.Plays == null)
                {
                    Assert.Fail();
                }
                i++;
            }
            Assert.Pass();
        }

        [TestCase(1, 0, 0, "0000000")]
        [TestCase(1, 4, 2, "0000000")]
        public void Test_CreatePlay(int PlayerId, int RowId, int ColumnId, String Play)
        {
            Row play = playerService.createPlay(PlayerId, RowId, ColumnId, Play).Result;
            String cell = play.Cell;
            int i = 0;
            foreach(char c in play.Cell.ToCharArray())
            {
                if(c.Equals(((char)PlayerId)) && i != ColumnId)
                    Assert.Fail();
                i++;
            }
            Assert.Pass();
        }
    }

}
