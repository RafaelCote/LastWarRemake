namespace GameFlow
{
    public abstract class GameState
    {
        protected GameManager _gameManager = null;

        public GameState(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        
        public abstract void Begin();
        public abstract void End();
    }
}