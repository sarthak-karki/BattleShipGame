using BattleShipGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using static BattleShipGame.Enums;

namespace BattleShipGame
{

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Board Board { get; set; }
        public bool HasLost 
        {
            get 
            {
                if (Ships.All(x => x.IsSunk == true))
                {
                    return true;
                }
                return false;
            } 
            
        }
        public IList<Ship> Ships { get; set; }

        public Player(string name)
        {
            Id = 1;
            Name = name;
            Board = new Board();
            Ships = CreateShips();
        }

        private IList<Ship> CreateShips()
        {
            var shipList = new List<Ship>();
            foreach (var ship in Enum.GetValues(typeof(ShipType)).Cast<ShipType>())
            {
                shipList.Add(CreateShip(ship));
            }

            return shipList;
        }

        private Ship CreateShip(ShipType shipType)
        {
            switch (shipType)
            {
                case ShipType.Destroyer:
                    return new Destroyer();

                default:
                    return new Destroyer();
            }
        }
    }
}

