using System;
using UnityEngine;

namespace MrHatProduction.Tools.Components
{
    public class DamageableComponent : MonoBehaviour
    {
        public event Action<int> DamageReceived;

        public void Hit(int damageReceived)
        {
            DamageReceived?.Invoke(damageReceived);
        }
    }
}