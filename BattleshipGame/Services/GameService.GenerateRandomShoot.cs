using BattleshipGame.Models;
using System;
using System.Linq;

namespace BattleshipGame.Services
{
    public partial class GameService
    {
        public Position GenerateRandomShoot(Player player)
        {
            Random random = new Random();
            bool isNewRandom = false;
            int positionH = 0;
            int positionV = 0;

            //Third Shoot (repeated), 2 possible direction 
            if (player.IsSecondShoot)
            {
                while (!isNewRandom)
                {

                    var direction = random.Next(1, 3);

                    if (player.IsHorizontalInThirdShoot)
                    {
                        // direction S
                        if (direction == 1)
                        {
                            positionH = (int)player.LastHitNoDestroyedPositionH;
                            positionV = (int)player.LastHitNoDestroyedPositionV - 1;
                        }
                        // direction N
                        else
                        {
                            positionH = (int)player.LastHitNoDestroyedPositionH;
                            positionV = (int)player.LastHitNoDestroyedPositionV + 1;
                        }
                    }
                    else
                    {
                        // direction E
                        if (direction == 1)
                        {
                            positionH = (int)player.LastHitNoDestroyedPositionH + 1;
                            positionV = (int)player.LastHitNoDestroyedPositionV;
                        }
                        // direction W
                        else
                        {
                            positionH = (int)player.LastHitNoDestroyedPositionH - 1;
                            positionV = (int)player.LastHitNoDestroyedPositionV;
                        }
                    }

                    isNewRandom = player.Shoots.Any(x => x.Horizontal == positionH && x.Vertical == positionV) ? false : true;
                }
            }
            //Second Shoot (repeated), 4 possible direction 
            else if (player.LastHitNoDestroyedPositionH != null && player.LastHitNoDestroyedPositionV != null)
            {
                while (!isNewRandom)
                {
                    char[] directions = { 'S', 'E', 'N', 'W' };
                    int directionIndex = random.Next(0, directions.Length);
                    char direction = directions[directionIndex];

                    switch (direction)
                    {
                        case 'S':
                            positionH = (int)player.LastHitNoDestroyedPositionH;
                            positionV = (int)player.LastHitNoDestroyedPositionV - 1;
                            break;
                        case 'E':
                            positionH = (int)player.LastHitNoDestroyedPositionH + 1;
                            positionV = (int)player.LastHitNoDestroyedPositionV;
                            break;
                        case 'N':
                            positionH = (int)player.LastHitNoDestroyedPositionH;
                            positionV = (int)player.LastHitNoDestroyedPositionV + 1;
                            break;
                        case 'W':
                            positionH = (int)player.LastHitNoDestroyedPositionH - 1;
                            positionV = (int)player.LastHitNoDestroyedPositionV;
                            break;
                        default:
                            break;
                    }

                    isNewRandom = player.Shoots.Any(x => x.Horizontal == positionH && x.Vertical == positionV) ? false : true;
                }
            }
            // First Shoot
            else
            {
                while (!isNewRandom)
                {
                    positionH = random.Next(0, Configuration.HorizontalSize);
                    positionV = random.Next(0, Configuration.VerticalSize);

                    isNewRandom = player.Shoots.Any(x => x.Horizontal == positionH && x.Vertical == positionV) ? false : true;
                }
            }

            player.Shoots.Add(new Position() { Horizontal = positionH, Vertical = positionV });

            return new Position
            {
                Horizontal = positionH,
                Vertical = positionV,
            };
        }
    }
}
