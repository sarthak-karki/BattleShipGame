using BattleShipGame;
using BattleShipGame.Services;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BattleShipsUnitTests
{
    public class GameAttackServiceTests
    {
        private readonly IConsoleService _ConsoleService;
        private readonly GameAttackService _sut;

        public GameAttackServiceTests()
        {
            _ConsoleService = Substitute.For<IConsoleService>();
            _sut = new GameAttackService(_ConsoleService);
        }

        [Fact]
        public void Handle_Attack_And_Notify_Hit_If_Ship_Is_Found()
        {
            var player = new Player("Test");
            player.Ships.ToList().ForEach(x => x.Size = 2);

            foreach (var ship in player.Ships)
            {
                int row = 6;
                int column = 6;
                for (int i = 0; i < ship.Size; i++)
                {              
                    player.Board.Cells.At(row, column).CellStatus = Enums.CellStatus.C;
                    column--;
                }
            }

            var attackCoordinates = BuildAttackCoordaintes();

            _ConsoleService.ReadInteger().Returns(attackCoordinates[0].Row, attackCoordinates[0].Column, attackCoordinates[1].Row, attackCoordinates[1].Column);

            _sut.HandleAttack(player);

            _ConsoleService.Received(2).WriteLine("Got a HIT!");
            Assert.Equal(Enums.CellStatus.X, player.Board.Cells.At(attackCoordinates[0].Row, attackCoordinates[0].Row).CellStatus);
            Assert.Equal(Enums.CellStatus.X, player.Board.Cells.At(attackCoordinates[1].Row, attackCoordinates[1].Row).CellStatus);
        }
     
        public IList<Coordinates> BuildAttackCoordaintes()
        {
            var attackCoordinates = new List<Coordinates>();
            attackCoordinates.Add(new Coordinates(6, 6));
            attackCoordinates.Add(new Coordinates(6, 5));

            return attackCoordinates;
        }
    }
}
