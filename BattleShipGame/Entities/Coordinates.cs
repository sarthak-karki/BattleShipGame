namespace BattleShipGame
{
    public class Coordinates
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public bool IsValidCoodinate 
        {
            get
            {
                if ((Row > 10 || Row < 1))
                {
                    return false;
                }

                if ((Column > 10 || Column < 1))
                {
                    return false;
                }

                return true;
            }
        }

        public Coordinates(int rows, int columns)
        {
            Row = rows;
            Column = columns;
        }
    }
}
