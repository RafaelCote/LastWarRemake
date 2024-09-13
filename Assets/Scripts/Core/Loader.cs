using GameCore;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFlow
{
    public class Loader : MonoBehaviour
    {
        [SerializeField] private string _gameplaySceneName;
        [SerializeField] private string _uiSceneName;
        [SerializeField] private string _loadSceneName;

        private int _sceneLoadedCpt = 0;

        private const int NB_SCENES_TO_LOAD = 2;
        
        private void Start()
        {
            var loadGameplaySceneOp = SceneManager.LoadSceneAsync(_gameplaySceneName, LoadSceneMode.Additive);
            var loadUISceneOp = SceneManager.LoadSceneAsync(_uiSceneName, LoadSceneMode.Additive);

            loadGameplaySceneOp.completed += OnScenedLoaded;
            loadUISceneOp.completed += OnScenedLoaded;
        }

        private void OnScenedLoaded(AsyncOperation operation)
        {
            if (!operation.isDone)
            {
                Debug.LogError("Load scene operation not completed. Should not be here.");
                return;
            }

            operation.completed -= OnScenedLoaded;
            _sceneLoadedCpt++;
            
            if (_sceneLoadedCpt >= NB_SCENES_TO_LOAD)
            {
                //TODO: Improve Managers life cycle handling.
                var managers = FindObjectsOfType<Manager>();

                foreach (var manager in managers)
                {
                    manager.Init();
                }

                foreach (var manager in managers)
                {
                    manager.Startup();
                }
                
                SceneManager.UnloadSceneAsync(_loadSceneName, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
            }
        }
    }
}
