namespace Connect4.API.Models
{
    public class Player
    {
        public int? Id {get; set;}
        public string? Username {get; set;}
        public string? Password {get; set;}
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