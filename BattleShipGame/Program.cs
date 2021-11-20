using System;
using BattleShipGame.Interfaces;
using BattleShipGame.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BattleShipGame
{
    class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = CreateDependencyInjections();

            var gameService = serviceProvider.GetService<IPlayGameService>();

            var player = new Player("Player 1");

            Console.WriteLine(player.Name);

            gameService.Play(player);

            player.Board.DisplayBoard();
        }

        public static ServiceProvider CreateDependencyInjections()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IPlayGameService, PlayGameService>()
                .AddSingleton<IShipOperationService, ShipOperationService>()
                .AddSingleton<IGameAttackService, GameAttackService>()
                .AddSingleton<IConsoleService, ConsoleService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
