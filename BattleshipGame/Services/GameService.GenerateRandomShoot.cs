using BattleshipGame.Models;
using System;
using System.Linq;

namespace BattleshipGame.Services
{
    public partial class GameService
    {
        public Position GenerateRandomShoot(Player player, Player enemy)
        {
            Random random = new Random();
            bool isNewRandom = false;
            int positionH = 0;
            int positionV = 0;

            //Trzeci strzał lub więcej (2 możłiwe kierunnki)
            if (player.IsSecondShoot)
            {
                while (!isNewRandom)
                {

                    var direction = random.Next(1, 3);

                    if (!player.IsHorizontalInThirdShoot)
                    {
                        // Jeżeli drugi strzał celny ale trzeci już pudło, pomóż znowu naprowadzić na poprawny strzał (pewność gdzie jest)
                        var isFirstOptionDisabled = player.Shoots
                            .Any(x => (x.Horizontal == (int)player.LastHitNoDestroyedPositionH && x.Vertical == (int)player.LastHitNoDestroyedPositionV - 1));
                        var isSecondOptionDisabled = player.Shoots
                            .Any(x => (x.Horizontal == (int)player.LastHitNoDestroyedPositionH && x.Vertical == (int)player.LastHitNoDestroyedPositionV + 1));

                        if (isFirstOptionDisabled && isSecondOptionDisabled)
                        {
                            var shipToHit = enemy.Ships
                            .FirstOrDefault(x => x.Positions
                                .Any(y => (y.Horizontal == (int)player.LastHitNoDestroyedPositionH && y.Vertical == (int)player.LastHitNoDestroyedPositionV)));

                            var generatePosition = shipToHit.Positions.FirstOrDefault(x => !x.isHit);
                            positionH = generatePosition.Horizontal;
                            positionV = generatePosition.Vertical;
                        }
                        else
                        {
                            // direction S (północ)
                            if (direction == 1)
                            {
                                positionH = (int)player.LastHitNoDestroyedPositionH;
                                positionV = (int)player.LastHitNoDestroyedPositionV - 1;
                            }
                            // direction N (południe)
                            else
                            {
                                positionH = (int)player.LastHitNoDestroyedPositionH;
                                positionV = (int)player.LastHitNoDestroyedPositionV + 1;
                            }
                        }
                    }
                    else
                    {
                        // Jeżeli drugi strzał celny ale trzeci już pudło, pomóż znowu naprowadzić na poprawny strzał (pewność gdzie jest)
                        var isFirstOptionDisabled = player.Shoots
                            .Any(x => (x.Horizontal == (int)player.LastHitNoDestroyedPositionH + 1 && x.Vertical == (int)player.LastHitNoDestroyedPositionV));
                        var isSecondOptionDisabled = player.Shoots
                            .Any(x => (x.Horizontal == (int)player.LastHitNoDestroyedPositionH - 1 && x.Vertical == (int)player.LastHitNoDestroyedPositionV));

                        if (isFirstOptionDisabled && isSecondOptionDisabled)
                        {
                            var shipToHit = enemy.Ships
                            .FirstOrDefault(x => x.Positions
                                .Any(y => (y.Horizontal == (int)player.LastHitNoDestroyedPositionH && y.Vertical == (int)player.LastHitNoDestroyedPositionV)));

                            var generatePosition = shipToHit.Positions.FirstOrDefault(x => !x.isHit);
                            positionH = generatePosition.Horizontal;
                            positionV = generatePosition.Vertical;
                        }
                        else
                        {
                            // direction E (Wschód)
                            if (direction == 1)
                            {
                                positionH = (int)player.LastHitNoDestroyedPositionH + 1;
                                positionV = (int)player.LastHitNoDestroyedPositionV;
                            }
                            // direction W (Zachód)
                            else
                            {
                                positionH = (int)player.LastHitNoDestroyedPositionH - 1;
                                positionV = (int)player.LastHitNoDestroyedPositionV;
                            }
                        }
                    }

                    isNewRandom = player.Shoots.Any(x => x.Horizontal == positionH && x.Vertical == positionV) ? false : true;
                }
            }
            // Drugi strzał (4 możliwe kierunki) 
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
            // Pierwszy strzał
            else
            {
                while (!isNewRandom)
                {
                    positionH = random.Next(0, Configuration.HorizontalSize);
                    positionV = random.Next(0, Configuration.VerticalSize);

                    isNewRandom = player.Shoots != null && player.Shoots
                        .Any(x => x.Horizontal == positionH && x.Vertical == positionV) ? false : true;
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
