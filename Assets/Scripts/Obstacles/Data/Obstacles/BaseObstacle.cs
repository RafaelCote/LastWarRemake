using UnityEngine;

namespace ObstaclesSystem.Data.Obstacles
{
    public enum ObstacleMode
    {
        Increasing,
        Decreasing
    }
    
    [CreateAssetMenu(fileName = "Obstacle", menuName = "Obstacle/Base", order = 0)]
    public class BaseObstacle : ScriptableObject
    {
        public Vector2Int StartingHealthRange;
        public ObstacleMode Mode;

        private void OnValidate()
        {
            if (StartingHealthRange.x > StartingHealthRange.y)
                Debug.LogError("StartingHealthRange's x value should be lower of the y value.");
        }
    }
}