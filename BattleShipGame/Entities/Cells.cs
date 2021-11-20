using static BattleShipGame.Enums;

namespace BattleShipGame
{
    public class Cells
    {
        public Coordinates Coordinates { get; set; }
        public CellStatus CellStatus { get; set; }

        public Cells(int row, int column)
        {
            Coordinates = new Coordinates(row, column);
        }

        public bool IsOccupied
        {
            get
            {
                return CellStatus == CellStatus.C;
            }
        }
    }
}
