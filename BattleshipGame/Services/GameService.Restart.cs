using BattleshipGame.Models;

namespace BattleshipGame.Services
{
    public partial class GameService
    {
        public void Restart(Player player1, Player player2)
        {
            player1 = new Player() { };
        }
    }
}
