namespace Connect4.API.Models
{
    public class Board
    {
        public List<Row>? Rows {get; set;}
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