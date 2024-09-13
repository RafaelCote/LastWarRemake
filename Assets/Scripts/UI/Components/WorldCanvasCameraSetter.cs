using UnityEngine;
using MrHatProduction.Tools;

namespace UI.Components
{
    [RequireComponent(typeof(Canvas))]
    public class WorldCanvasCameraSetter : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas = null;

        private void OnValidate()
        {
            _canvas = GetComponent<Canvas>();
            _canvas.renderMode = RenderMode.WorldSpace;
        }

        void Start()
        {
            _canvas.worldCamera = Utils.Camera;
        }
    }
}
