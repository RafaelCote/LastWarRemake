using System;
using UnityEngine;

namespace MrHatProduction.Tools.Components
{
    public class CollisionComponent : MonoBehaviour
    {
        public event Action<Collider> TriggerEntered;
        public event Action<Collider> TriggerExited;
        public event Action<Collider> TriggerStaying;
        public event Action<Collision> CollisionBegan;
        public event Action<Collision> CollisionEnded;
        public event Action<Collision> Colliding;
        
        private void OnTriggerEnter(Collider other)
        {
            TriggerEntered?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            TriggerExited?.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            TriggerStaying?.Invoke(other);
        }
        
        private void OnCollisionEnter(Collision other)
        {
            CollisionBegan?.Invoke(other);
        }

        private void OnCollisionExit(Collision other)
        {
            CollisionEnded?.Invoke(other);
        }

        private void OnCollisionStay(Collision other)
        {
            Colliding?.Invoke(other);
        }
    }
}