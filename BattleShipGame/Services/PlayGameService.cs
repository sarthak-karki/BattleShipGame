using BattleShipGame.Interfaces;

namespace BattleShipGame
{
    public class PlayGameService : IPlayGameService
    {
        private readonly IShipOperationService _ShipOperationService;
        private readonly IGameAttackService _GameAttackService;

        public PlayGameService(IShipOperationService shipOperationService, IGameAttackService gameAttackService)
        {
            _ShipOperationService = shipOperationService;
            _GameAttackService = gameAttackService;
        }

        public void Play(Player player)
        {
            _ShipOperationService.PlaceShips(player);
            _GameAttackService.HandleAttack(player);
        }

        // Multi Player Logic Should be handled in this Service
        
    }
}
