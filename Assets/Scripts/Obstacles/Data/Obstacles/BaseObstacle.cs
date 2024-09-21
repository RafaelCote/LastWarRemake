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
        public int StartingHealth;
        public ObstacleMode Mode;
    }
}