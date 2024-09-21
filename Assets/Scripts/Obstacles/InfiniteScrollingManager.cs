using System.Collections.Generic;
using UnityEngine;

namespace ObstaclesSystem
{
    public class InfiniteScrollingManager : MonoBehaviour
    {
        //TODO: Repenser si utiliser un singleton ici est la meilleure solution.
        public static InfiniteScrollingManager Instance = null;
        
        [SerializeField] private List<MovingTile> _movingTiles = null;
        [SerializeField] private Transform _limitPoint = null;
        [SerializeField] private float _speed = 3.0f;

        private void Awake()
        {
            //TODO: Move the singleton code to a dedicated class.
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            short index = 0;
            foreach (var tile in _movingTiles)
            {
                tile.Init(Mathf.Abs(_limitPoint.position.z), _speed, index);
                tile.MovementLimitReached += Tile_MovementLimitReached;
                index++;
            }
        }

        private void OnDestroy()
        {
            foreach (var tile in _movingTiles)
            {
                tile.MovementLimitReached -= Tile_MovementLimitReached;
            }
        }

        public void BeginMoving()
        {
            foreach (var tile in _movingTiles)
                tile.BeginMoving();
        }

        public void StopMoving()
        {
            foreach (var tile in _movingTiles) 
                tile.StopMoving();
        }

        [ContextMenu("Reset Tiles Positions")]
        public void ResetTilesPositions()
        {
            foreach (var tile in _movingTiles)
            {
                tile.ResetPosition();
            }
        }

        private void Tile_MovementLimitReached(MovingTile tile)
        {
            var lastTile = GetLastTile(tile.Index);
            tile.transform.position = lastTile.transform.position + Vector3.forward * tile.transform.localScale.z;
        }

        private MovingTile GetLastTile(short tileIndex)
        {
            return (tileIndex - 1 < 0)
                ? _movingTiles[_movingTiles.Count - 1]
                : _movingTiles[tileIndex - 1];
        }
    }
}
