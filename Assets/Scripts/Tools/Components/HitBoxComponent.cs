using System;
using UnityEngine;

namespace MrHatProduction.Tools.Components
{
    [RequireComponent(typeof(Collider))]
    public class HitBoxComponent : MonoBehaviour
    {
        public event Action<GameObject> OnObjectHit;
        
        private void OnTriggerEnter(Collider other)
        {
            OnObjectHit?.Invoke(other.gameObject);
        }
    }
}