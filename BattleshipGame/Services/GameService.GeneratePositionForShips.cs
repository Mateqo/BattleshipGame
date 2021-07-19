using BattleshipGame.Models;
using System;

namespace BattleshipGame.Services
{
    public partial class GameService
    {
        public void GeneratePositionForShips(Player player)
        {
            Random random = new Random();
            char[] directions = { 'S', 'E', 'N', 'W' };

            for (int i = Configuration.ShipsSize.Length - 1; i >= 0; i--)
            {
                bool isPlaced = false;

                while (!isPlaced)
                {
                    int startPositionV = random.Next(Configuration.VerticalSize);
                    int startPositionH = random.Next(Configuration.HorizontalSize);
                    int directionIndex = random.Next(0, directions.Length);
                    char direction = directions[directionIndex];

                    if (player.Board[startPositionV, startPositionH] == '-' && CanSelectPosition(Configuration.ShipsSize[i], startPositionV, startPositionH, direction, player))
                    {
                        SelectPosition(Configuration.ShipsSize[i], startPositionV, startPositionH, direction, player);
                        isPlaced = true;
                    }
                }
            }
        }
    }
}
