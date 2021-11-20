using BattleShipGame.Interfaces;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using static BattleShipGame.Enums;

[assembly: InternalsVisibleTo("BattleShipsUnitTests")]
namespace BattleShipGame.Services
{
    public class ShipOperationService : IShipOperationService
    {
        private readonly IConsoleService _ConsoleService;
        public ShipOperationService(IConsoleService consoleService)
        {
            _ConsoleService = consoleService;
        }

        internal Coordinates ReadShipCoordinates(Ship ship)
        {
            int row, column;  
            bool isShipCoordinatesRead = false;
            var shipCoordinates = new Coordinates(0, 0);
            while (!isShipCoordinatesRead)
            {
                _ConsoleService.WriteLine("Enter row for " + ship.ShipType.ToString() + ":");

                row = _ConsoleService.ReadInteger();               

                _ConsoleService.WriteLine("Enter column for " + ship.ShipType.ToString() + ":");

                column = _ConsoleService.ReadInteger();

                shipCoordinates.Row = row;
                shipCoordinates.Column = column;

                if (!shipCoordinates.IsValidCoodinate)
                {
                    _ConsoleService.WriteLine("Invalid Starting Coordinates for the Ship");
                    // throw new Exception("Invalid Starting Coordinates for the Ship");
                    continue;
                }

                isShipCoordinatesRead = true;
            }

            return shipCoordinates;
        }

        internal Enums.Direction ReadShipDirectionPlacement(Ship ship)
        {
            bool isShipDirectionRead = false;

            var direction = Direction.L;

            while (!isShipDirectionRead)
            {
                _ConsoleService.WriteLine("Ships can only be placed either U/D/L/R direction from the starting coordinates");
                _ConsoleService.WriteLine("Enter direction to be placed for " + ship.ShipType.ToString() + ":");
                // var directionInput = _ConsoleService.ReadLine().ToUpper();

                var directionInput = _ConsoleService.ReadString();
                
                if (!Enum.TryParse(directionInput.ToString().ToUpper(), out Enums.Direction directionOut))
                {
                    _ConsoleService.WriteLine("Incorrect Direction");
                    // throw new Exception("Incorrect Direction");
                    continue;
                }

                direction = directionOut;
                isShipDirectionRead = true;
            }

            return direction;
        }

        internal Coordinates BuildFinalShipCoordinates(int row, int column, Direction direction, Ship ship, Board board)
        {
            var shipSize = ship.Size - 1;

            int finalRow;
            int finalColumn;
            switch (direction)
            {
                case Direction.U:
                    finalRow = row - shipSize;
                    finalColumn = column;
                    return new Coordinates(finalRow, finalColumn);

                case Direction.D:
                    finalRow = row + shipSize;
                    finalColumn = column;
                    return new Coordinates(finalRow, finalColumn);

                case Direction.L:
                    finalRow = row;
                    finalColumn = column - shipSize;
                    return new Coordinates(finalRow, finalColumn);

                case Direction.R:
                    finalRow = row;
                    finalColumn = column + shipSize;
                    return new Coordinates(finalRow, finalColumn);

                default:
                    finalRow = row;
                    finalColumn = row;
                    return new Coordinates(finalRow, finalColumn);

            }

        }

        public void PlaceShips(Player player)
        {
            foreach (var ship in player.Ships.Where(x => x.IsPlaced == false))
            {
                var startingCoordinates = ReadShipCoordinates(ship);

                var direction = ReadShipDirectionPlacement(ship);

                var finalCoordinates = BuildFinalShipCoordinates(startingCoordinates.Row, startingCoordinates.Column, direction, ship, player.Board);

                if (!finalCoordinates.IsValidCoodinate)
                {
                    _ConsoleService.WriteLine("EndingCoordinates exceeded board");
                    PlaceShips(player);
                }

                var occupiedCells = player.Board.Cells.Range(startingCoordinates.Row, startingCoordinates.Column, finalCoordinates.Row, finalCoordinates.Column);

                if (occupiedCells.Any(x => x.IsOccupied))
                {
                    _ConsoleService.WriteLine("This Cell is occupied");
                    PlaceShips(player);
                }

                foreach (var occupiedCell in occupiedCells)
                {
                    occupiedCell.CellStatus = CellStatus.C;
                }

                ship.IsPlaced = true;
            }

            player.Board.DisplayBoard();
        }       
    }
}
