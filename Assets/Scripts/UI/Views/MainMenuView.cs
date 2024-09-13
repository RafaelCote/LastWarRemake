using UnityEngine;
using UnityEngine.UI;
using GameFlow;

namespace UI.Views
{
    public class MainMenuView : View
    {
        [SerializeField] private Button _startButton = null;

        public override void Show()
        {
            base.Show();

            _startButton.onClick.AddListener(OnStartButtonClicked);
        }

        public override void Hide()
        {
            _startButton.onClick.RemoveListener(OnStartButtonClicked);
            
            base.Hide();
        }

        private void OnStartButtonClicked()
        {
            GameManager.Instance.ChangeState(new Gameplay(GameManager.Instance)); //TODO: Envoyer l'instance de cette façon me donne la chaire de poule. Essayer de trouver une meilleure façon de gérer tout ça.
            UIManager.Instance.HideAllViews();
        }
    }
}
