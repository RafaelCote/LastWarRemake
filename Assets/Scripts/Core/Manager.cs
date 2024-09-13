using UnityEngine;

namespace GameCore
{
    public abstract class Manager : MonoBehaviour
    {
        public abstract void Init();
        public abstract void Startup();
        public abstract void Dispose();
    }
}