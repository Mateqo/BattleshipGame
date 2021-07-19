using BattleshipGame.Models;

namespace BattleshipGame.Services
{
    public partial class GameService
    {
        public bool CanSelectPosition(int sizeShip, int startPositionV, int startPositionH, char direction, Player player)
        {
            bool canPlace = true;

            switch (direction)
            {
                case 'N':
                    if (startPositionV - (sizeShip - 1) < 0)
                        canPlace = false;
                    else
                        for (int i = startPositionV; i >= startPositionV - (sizeShip - 1) && canPlace; i--)
                            canPlace = player.Board[i, startPositionH] == '-';
                    break;
                case 'E':
                    if (startPositionH + (sizeShip - 1) >= startPositionH)
                        canPlace = false;
                    for (int i = startPositionH; i <= startPositionH + (sizeShip - 1) && canPlace; i++)
                        canPlace = player.Board[startPositionV, i] == '-';
                    break;
                case 'S':
                    if (startPositionV + (sizeShip - 1) >= startPositionV)
                        canPlace = false;
                    for (int i = startPositionV; i <= startPositionV + (sizeShip - 1) && canPlace; i++)
                        canPlace = player.Board[i, startPositionH] == '-';
                    break;
                case 'W':
                    if (startPositionH - (sizeShip - 1) < 0)
                        canPlace = false;
                    for (int i = startPositionH; i >= startPositionH - (sizeShip - 1) && canPlace; i--)
                        canPlace = player.Board[startPositionV, i] == '-';
                    break;
                default:
                    break;
            }


            return canPlace;
        }
    }
}
