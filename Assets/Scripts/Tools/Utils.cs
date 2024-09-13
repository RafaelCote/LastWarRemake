using UnityEngine;

namespace MrHatProduction.Tools
{
    public static class Utils
    {
        private static Camera _camera;

        public static Camera Camera
        {
            get
            {
                if (_camera == null)
                    _camera = Camera.main;

                return _camera;
            }
        }
    }
}
