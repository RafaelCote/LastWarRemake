using UnityEngine;

namespace MrHatProduction.Tools.Components
{
    public class MovementComponent : MonoBehaviour
    {
        public void Move(Vector3 velocity, float speed)
        {
            transform.position += velocity.normalized * speed * Time.deltaTime;
        }
    }
}
