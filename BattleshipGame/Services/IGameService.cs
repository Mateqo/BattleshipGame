using BattleshipGame.Models;

namespace BattleshipGame.Services
{
    public interface IGameService
    {
        void GeneratePositionForShips(Player player, Player enem);
        void SelectPosition(int sizeShip, int startPositionV, int startPositionH, char direction, Player player, Player enemy);
        bool CanSelectPosition(int sizeShip, int startPositionV, int startPositionH, char direction, Player player);
        ShootResult Shoot(int positionH, int positionV, Player enemy, Player playerWithTurn);
        Position GenerateRandomShoot(Player player, Player enemy);
    }
}
