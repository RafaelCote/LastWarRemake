using GameCore;
using GameFlow;
using MrHatProduction.Tools;
using UI.Data;
using UI.Views;
using UnityEngine;

namespace UI
{
    public class UIManager : Manager
    {
        public static UIManager Instance = null;
        
        //TODO: Improve Data structure to store views 
        [SerializeField] private SerializedDictionary<ECanvasLevel, Canvas> _canvasLevels = null;
        [SerializeField] private ViewsDatabase _viewsDatabase = null;

        private void Awake()
        {
            //TODO: Move the singleton code to a dedicated class.
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }
        
        public override void Init()
        {
            _canvasLevels.Init();
            GameManager.Instance.StateChanged += GameManager_OnStateChanged;
        }

        public override void Startup() { }

        public override void Dispose()
        {
            GameManager.Instance.StateChanged -= GameManager_OnStateChanged;
        }

        public void ShowView(EView viewID)
        {
            //Hide already present view.
            var viewCanvasLevel = _canvasLevels[ECanvasLevel.View];
            foreach (Transform child in viewCanvasLevel.transform)
            {
                if (child.TryGetComponent<View>(out var viewToHide))
                    HideView(viewToHide);
                else
                    Debug.LogError("There's an object that is not a view in the view Canvas.");
            }

            if (_viewsDatabase.TryGet(viewID, out var viewToShow))
            {
                var viewInstance = Instantiate(viewToShow, viewCanvasLevel.transform);
                viewInstance.Show();
            }
        }

        public void HideAllViews()
        {
            foreach (Transform child in _canvasLevels[ECanvasLevel.View].transform)
            {
                HideView(child.GetComponent<View>());
            }
        }

        private void HideView(View view)
        {
            view.Hide();
            Destroy(view.gameObject);
        }

        //TODO: Regarder pourquoi le main menu ne s'affiche pas lorsque les scène UI et Gameplay sont chargés.
        private void GameManager_OnStateChanged(GameState state)
        {
            switch (state)
            {
                case MainMenu _:
                    ShowView(EView.MainMenu);
                    break;
                
                case GameOver _:
                    ShowView(EView.GameOver);
                    break;
            }
        }
    }
}