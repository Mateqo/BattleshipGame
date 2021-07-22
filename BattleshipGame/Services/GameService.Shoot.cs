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
                // Hit and destroyed
                if (!shipToHit.Positions.Any(x => x.isHit == false))
                {
                    shipToHit.isDestroyed = true;
                    playerWithTurn.LastHitNoDestroyedPositionH = null;
                    playerWithTurn.LastHitNoDestroyedPositionV = null;
                    playerWithTurn.IsSecondShoot = false;

                }
                // Only hit
                else
                {
                    // If only hit and before was hit but without destroyed 
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
                IsDestroyed = shipToHit.isDestroyed,
                IsHit = isHit,
                IsHorizontal = shipToHit.isHorizontal
            };
        }
    }
}
