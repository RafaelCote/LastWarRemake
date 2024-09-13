using GameFlow;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class GameOverView : View
    {
        [SerializeField] private Button _backToMainMenuButton = null;
        
        public override void Show()
        {
            base.Show();

            _backToMainMenuButton.onClick.AddListener(OnStartButtonClicked);
        }

        public override void Hide()
        {
            _backToMainMenuButton.onClick.RemoveListener(OnStartButtonClicked);
            
            base.Hide();
        }

        private void OnStartButtonClicked()
        {
            GameManager.Instance.ChangeState(new MainMenu(GameManager.Instance)); //TODO: Envoyer l'instance de cette façon me donne la chaire de poule. Essayer de trouver une meilleure façon de gérer tout ça.
        }
    }
}
