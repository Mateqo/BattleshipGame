using BattleshipGame.Models;
using System.Collections.Generic;

namespace BattleshipGame.Services
{
    public partial class GameService
    {
        public void SelectPosition(int sizeShip, int startPositionV, int startPositionH, char direction, Player player)
        {
            var positions = new List<Position>();

            switch (direction)
            {
                case 'N':
                    for (int i = startPositionV; i >= startPositionV - (sizeShip - 1); i--)
                    {
                        player.Board[i, startPositionH] = '*';
                        positions.Add(new Position { Vertical = i, Horizontal = startPositionH });
                    }
                    break;
                case 'E':
                    for (int i = startPositionH; i <= startPositionH + (sizeShip - 1); i++)
                    {
                        player.Board[startPositionV, i] = '*';
                        positions.Add(new Position { Vertical = startPositionV, Horizontal = i });
                    }
                    break;
                case 'S':
                    for (int i = startPositionV; i <= startPositionV + (sizeShip - 1); i++)
                    {
                        player.Board[i, startPositionH] = '*';
                        positions.Add(new Position { Vertical = i, Horizontal = startPositionH });
                    }
                    break;
                case 'W':
                    for (int i = startPositionH; i >= startPositionH - (sizeShip - 1); i--)
                    {
                        player.Board[startPositionV, i] = '*';
                        positions.Add(new Position { Vertical = startPositionV, Horizontal = i });
                    }
                    break;
                default:
                    break;
            }

            player.Ships.Add(new Ship { Size = sizeShip, Positions = positions });
        }
    }
}
