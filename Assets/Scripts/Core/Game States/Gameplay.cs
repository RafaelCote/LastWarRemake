using ObstaclesSystem;

namespace GameFlow
{
    public class Gameplay : GameState
    {
        public Gameplay(GameManager gameManager) : base(gameManager) { }
        
        public override void Begin()
        {
            _gameManager.SpawnPlayer();
        }

        public override void End() { }
    }
}