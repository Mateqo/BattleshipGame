using BattleshipGame.Models;
using System.Linq;

namespace BattleshipGame.Services
{
    public partial class GameService
    {
        public ShootResult Shoot(int positionH, int positionV, Player enemy, Player playerWithTurn)
        {
            bool isHit = false;
            var shipToHit = enemy.Ships.FirstOrDefault(x => x.Positions.Any(y => y.Horizontal == positionH && y.Vertical == positionV));

            if (shipToHit != null)
            {
                isHit = true;
                shipToHit.Positions.FirstOrDefault(x => x.Horizontal == positionH && x.Vertical == positionV).isHit = true;
                // Trafiony i zatopiony
                if (!shipToHit.Positions.Any(x => x.isHit == false))
                {
                    shipToHit.isDestroyed = true;
                    playerWithTurn.LastHitNoDestroyedPositionH = null;
                    playerWithTurn.LastHitNoDestroyedPositionV = null;
                    playerWithTurn.IsSecondShoot = false;

                }
                // Tylko trafiony
                else
                {
                    // Jeżeli tylko trafimy i nie zatopimy a wcześniej trafiliśmy też bez zatopienia
                    if (playerWithTurn.LastHitNoDestroyedPositionH != null && playerWithTurn.LastHitNoDestroyedPositionV != null)
                    {
                        playerWithTurn.IsSecondShoot = true;
                        playerWithTurn.IsHorizontalInThirdShoot = shipToHit.isHorizontal;
                    }

                    playerWithTurn.LastHitNoDestroyedPositionH = positionH;
                    playerWithTurn.LastHitNoDestroyedPositionV = positionV;
                }

            }

            return new ShootResult()
            {
                IsEnd = enemy.Ships.Any(x => !x.isDestroyed) ? false : true,
                IsDestroyed = shipToHit != null ? shipToHit.isDestroyed : false,
                IsHit = isHit,
                IsHorizontal = shipToHit != null ? shipToHit.isHorizontal : false,
                PositionV = positionV,
                PositionH = positionH
            };
        }
    }
}
