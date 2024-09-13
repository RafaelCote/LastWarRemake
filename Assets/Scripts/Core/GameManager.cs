using System;
using GameCore;
using Player;
using UnityEngine;

namespace GameFlow
{
    public class GameManager : Manager
    {
        public static GameManager Instance = null;
        public event Action<GameState> StateChanged;

        [SerializeField] private PlayerController _playerPrefab = null;
        [SerializeField] private Transform _playerSpawnPoint = null;

        private PlayerController _playerController = null;
        private GameState _currentState = null;
        
        private void Awake()
        {
            //TODO: Move the singleton code to a dedicated class.
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public override void Init() { }

        public override void Startup()
        {
            ChangeState(new MainMenu(Instance));
        }

        public override void Dispose() { }

        public void SpawnPlayer()
        {
            _playerController = Instantiate(_playerPrefab, _playerSpawnPoint);
            _playerController.PlayerDied += PlayerController_OnPlayerDied;
        }

        //TODO: Refactor with generic state machine.
        public void ChangeState(GameState newState)
        {
            if (_currentState != null)
                _currentState.End();
            
            _currentState = newState;
            _currentState.Begin();
            
            StateChanged?.Invoke(_currentState);
        }

        private void PlayerController_OnPlayerDied()
        {
            _playerController.PlayerDied -= PlayerController_OnPlayerDied;
            Destroy(_playerController.gameObject);
            //TODO: Reset obstacle panels
            
            ChangeState(new GameOver(Instance));
        }
    }
}