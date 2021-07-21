using BattleshipGame.Models;
using System.Linq;

namespace BattleshipGame.Services
{
    public partial class GameService
    {
        public bool CheckField(int positionH, int positionV, Player enemy)
        {
            return enemy.Ships.Any(x => x.Positions.Any(y => y.Horizontal == positionH && y.Vertical == positionV));
        }
    }
}
