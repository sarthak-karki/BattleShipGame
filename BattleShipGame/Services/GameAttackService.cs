using BattleShipGame.Interfaces;
using System;
using System.Linq;
using static BattleShipGame.Enums;

namespace BattleShipGame.Services
{
    public class GameAttackService : IGameAttackService
    {
        private readonly IConsoleService _ConsoleService;
        public GameAttackService(IConsoleService consoleService)
        {
            _ConsoleService = consoleService;
        }

        private Coordinates ReadAttackCoordinates()
        {
            int row, column;
            bool isAttackCoordinatesRead = false;
            var attackCoordinate = new Coordinates(0, 0);
            while (!isAttackCoordinatesRead)
            {
                _ConsoleService.WriteLine("Enter Attack row Coordinates");                
                row = _ConsoleService.ReadInteger();

                _ConsoleService.WriteLine("Enter Attack column Coordinates");
                column = _ConsoleService.ReadInteger();

                attackCoordinate = new Coordinates(row, column);
                if (!attackCoordinate.IsValidCoodinate)
                {
                    _ConsoleService.WriteLine("Invalid Attack Coordinates");
                    continue;
                }

                isAttackCoordinatesRead = true;
            }

            return attackCoordinate;
        }

        public void HandleAttack(Player player)
        {
            while (!player.HasLost)
            {
                var attackCoordinates = ReadAttackCoordinates();

                if (player.Board.Cells.At(attackCoordinates.Row, attackCoordinates.Column).IsOccupied)
                {
                    var hitCell = player.Board.Cells.At(attackCoordinates.Row, attackCoordinates.Column);
                    hitCell.CellStatus = CellStatus.X;
                    var impactedShip = player.Ships.Where(x => x.ShipType == ShipType.Destroyer).FirstOrDefault();
                    impactedShip.Hits++;
                    _ConsoleService.WriteLine("Got a HIT!");
                }
                else
                {
                    _ConsoleService.WriteLine("You missed the shot!");
                }             

                player.Board.DisplayBoard();
            }

            _ConsoleService.WriteLine(player.Name + " Has All its Ships Destroyed!");
        }

    }
}
