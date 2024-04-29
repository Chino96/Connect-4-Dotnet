namespace Connect4.API.Models
{
    public class Game
    {
        public Board? GameBoard {get; set;}
        public List<Player>? Players {get; set;}
        public List<Row>? Plays {get; set;} 
    }

    /*public class PlayerMap : ClassMap<Player>}
    {
        public Player()
        {
            Map(m => m.Username);
            Map(m => m.Password);
        }
    }*/
}