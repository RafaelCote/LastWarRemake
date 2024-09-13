using System;
using UnityEngine;

namespace MrHatProduction.Tools.Components
{
    public class CollisionComponent : MonoBehaviour
    {
        public event Action<Collider> OnTriggerEntered;
        public event Action<Collider> OnTriggerExited;
        public event Action<Collider> OnTriggerStaying;
        public event Action<Collision> OnCollisionBegan;
        public event Action<Collision> OnCollisionEnded;
        public event Action<Collision> OnColliding;
        
        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEntered?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnTriggerExited?.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            OnTriggerStaying?.Invoke(other);
        }
        
        private void OnCollisionEnter(Collision other)
        {
            OnCollisionBegan?.Invoke(other);
        }

        private void OnCollisionExit(Collision other)
        {
            OnCollisionEnded?.Invoke(other);
        }

        private void OnCollisionStay(Collision other)
        {
            OnColliding?.Invoke(other);
        }
    }
}