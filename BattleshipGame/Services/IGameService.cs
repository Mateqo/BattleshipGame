using BattleshipGame.Models;

namespace BattleshipGame.Services
{
    public interface IGameService
    {
        void GeneratePositionForShips(Player player);
        void SelectPosition(int sizeShip, int startPositionV, int startPositionH, char direction, Player player);
        bool CanSelectPosition(int sizeShip, int startPositionV, int startPositionH, char direction, Player player);
    }
}
