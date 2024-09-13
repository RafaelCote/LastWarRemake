using Obstacles.InfiniteScroller;

namespace GameFlow
{
    public class MainMenu : GameState
    {
        public MainMenu(GameManager gameManager) : base(gameManager) { }

        public override void Begin()
        {
            InfiniteScrollingManager.Instance.ResetTilesPositions();
        }

        public override void End() { }
    }
}