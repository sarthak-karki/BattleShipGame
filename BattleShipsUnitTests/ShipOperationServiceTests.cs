using BattleShipGame;
using BattleShipGame.Entities;
using BattleShipGame.Services;
using NSubstitute;
using System;
using System.Linq;
using Xunit;

namespace BattleShipsUnitTests
{
    public class ShipOperationServiceTests
    {
        private readonly IConsoleService _ConsoleService;
        private readonly ShipOperationService _sut;

        public ShipOperationServiceTests()
        {
            _ConsoleService = Substitute.For<IConsoleService>();
            _sut = new ShipOperationService(_ConsoleService);
        }

        [Theory]
        [InlineData(6,5)]
        [InlineData(6, 6)]
        [InlineData(9, 9)]
        public void Should_Read_Ship_Coordiantes_If_Coordinates_Are_Valid(int row, int column)
        {
            var ship = new Destroyer();

            _ConsoleService.ReadInteger().Returns(row, column);

            var result = _sut.ReadShipCoordinates(ship);

            Assert.Equal(row, result.Row);
            Assert.Equal(column, result.Column);
        }

        // [Theory]
        [InlineData(0, 0)]
        [InlineData(11, 11)]
        [InlineData(99, 99)]
        public void Should_Not_Read_Ship_Coordiantes_If_Coordinates_Are_InValid(int row, int column)
        {
            var ship = new Destroyer();

            _ConsoleService.ReadInteger().Returns(row, column);

            Assert.Throws<Exception>(() => _sut.ReadShipCoordinates(ship));
        }

        [Theory]
        [InlineData("d")]
        [InlineData("D")]
        [InlineData("u")]
        [InlineData("U")]
        public void Should_Read_Ship_Coordiantes_If_Direction_Is_Valid(string direction)
        {
            var ship = new Destroyer();

            _ConsoleService.ReadString().Returns(direction);

            var result = _sut.ReadShipDirectionPlacement(ship);

            Assert.Equal(direction.ToUpper() , result.ToString());
        }

        // [Theory]
        [InlineData("z")]
        [InlineData("Z")]
        [InlineData("k")]
        [InlineData("K")]
        public void Should_Not_Read_Ship_Coordiantes_If_Direction_Is_InValid(string direction)
        {
            var ship = new Destroyer();

            _ConsoleService.ReadString().Returns(direction);

            Assert.Throws<Exception>(() => _sut.ReadShipDirectionPlacement(ship));
        }

        [Fact]
        public void Place_Ship_If_All_Inputs_Are_As_Expected()
        {
            var player = new Player("Test");

            _ConsoleService.ReadInteger().Returns(6, 6);
            _ConsoleService.ReadString().Returns("l");

            _sut.PlaceShips(player);

            var cells = player.Board.Cells.Where(x => x.CellStatus == Enums.CellStatus.C);

            Assert.Equal(player.Ships.Sum(s => s.Size), cells.Count());
        }
    }
}
