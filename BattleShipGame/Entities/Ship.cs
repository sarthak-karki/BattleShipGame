using static BattleShipGame.Enums;

namespace BattleShipGame
{
    public abstract class Ship
    {
        public ShipType ShipType { get; set; }
        public int Size { get; set; }
        public int Hits { get; set; }
        public bool IsPlaced { get; set; }
        public bool IsSunk
        {
            get
            {
                return Hits >= Size;
            }
        }

    }
}
