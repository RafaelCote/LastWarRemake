using UnityEngine;

namespace MrHatProduction.Tools
{
    public class FaceCamera : MonoBehaviour
    {
        void Update()
        {
            transform.LookAt(Utils.Camera.transform);
        }
    }
}
