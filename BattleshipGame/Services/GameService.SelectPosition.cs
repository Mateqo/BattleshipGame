using BattleshipGame.Models;
using System;
using System.Collections.Generic;

namespace BattleshipGame.Services
{
    public partial class GameService
    {
        public void SelectPosition(int sizeShip, int startPositionV, int startPositionH, char direction, Player player)
        {
            var positions = new List<PositionShip>();

            switch (direction)
            {
                case 'N':
                    for (int i = startPositionV; i >= startPositionV - (sizeShip - 1); i--)
                    {
                        player.Board[i, startPositionH] = '*';
                        positions.Add(new PositionShip { Vertical = i, Horizontal = startPositionH });
                    }
                    break;
                case 'E':
                    for (int i = startPositionH; i <= startPositionH + (sizeShip - 1); i++)
                    {
                        player.Board[startPositionV, i] = '*';
                        positions.Add(new PositionShip { Vertical = startPositionV, Horizontal = i });
                    }
                    break;
                case 'S':
                    for (int i = startPositionV; i <= startPositionV + (sizeShip - 1); i++)
                    {
                        player.Board[i, startPositionH] = '*';
                        positions.Add(new PositionShip { Vertical = i, Horizontal = startPositionH });
                    }
                    break;
                case 'W':
                    for (int i = startPositionH; i >= startPositionH - (sizeShip - 1); i--)
                    {
                        player.Board[startPositionV, i] = '*';
                        positions.Add(new PositionShip { Vertical = startPositionV, Horizontal = i });
                    }
                    break;
                default:
                    break;
            }

            //FOR DEBUG
            //for (int k = 0; k < 10; k++)
            //{
            //    for (int j = 0; j < 10; j++)
            //    {
            //        Console.Write(player.Board[k, j]);
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();

            // outline ship
            foreach (var position in positions)
            {
                if (position.Horizontal + 1 < Configuration.HorizontalSize)
                    player.Board[position.Vertical, position.Horizontal + 1] = '*';
                if (position.Horizontal - 1 >= 0)
                    player.Board[position.Vertical, position.Horizontal - 1] = '*';
                if (position.Vertical + 1 < Configuration.VerticalSize)
                    player.Board[position.Vertical + 1,position.Horizontal] = '*';
                if (position.Vertical - 1 >= 0)
                    player.Board[position.Vertical - 1, position.Horizontal] = '*';
            }

            //FOR DEBUG
            //for (int k = 0; k < 10; k++)
            //{
            //    for (int j = 0; j < 10; j++)
            //    {
            //        Console.Write(player.Board[k, j]);
            //    }
            //    Console.WriteLine();
            //}

            player.Ships.Add(new Ship
            {
                Size = sizeShip,
                Positions = positions,
                isHorizontal = direction == 'E' || direction == 'W' ? true : false
            }); ;
        }
    }
}
