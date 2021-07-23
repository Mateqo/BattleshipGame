namespace BattleshipGame.Models
{
    public class ShootResult
    {
        public bool IsHit { get; set; }
        public bool IsDestroyed { get; set; }
        public bool IsHorizontal { get; set; }
        public bool IsEnd { get; set; }
        public int PositionV { get; set; }
        public int PositionH { get; set; }
    }
}
