using ObstaclesSystem.Data.Obstacles;
using UnityEngine;

namespace ObstaclesSystem.Data
{
    [CreateAssetMenu(fileName = "Barrier", menuName = "Barrier Template", order = 9)]
    public class Barrier : ScriptableObject
    {
        public BaseObstacle LeftObstacle = null;
        public BaseObstacle MiddleObstacle = null;
        public BaseObstacle RightObstacle = null;
    }
}