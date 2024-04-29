namespace Connect4.API.Models
{
    public class Row
    {
        public Row(){}
        public Row(String cell)
        {
            Cell = cell;
        }
        public int? Id {get; set;}
        public String? Cell {get; set;}
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