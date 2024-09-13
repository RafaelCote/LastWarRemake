using Obstacles.InfiniteScroller;

namespace GameFlow
{
    public class Gameplay : GameState
    {
        public Gameplay(GameManager gameManager) : base(gameManager) { }
        
        public override void Begin()
        {
            InfiniteScrollingManager.Instance.BeginMoving();
            _gameManager.SpawnPlayer();
        }

        public override void End()
        {
            InfiniteScrollingManager.Instance.StopMoving();
        }
    }
}