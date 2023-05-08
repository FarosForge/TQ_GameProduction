using Save;
using UnityEngine.SceneManagement;
using Zenject;

namespace UI
{
    public class GameOverWindow : UIWindow
    {
        private SaveSystem saveSystem;

        [Inject]
        public void Construct(SaveSystem saveSystem)
        {
            this.saveSystem = saveSystem;
        }

        public void CompleteGame()
        {
            saveSystem.ClearSave();
            Deactivate();
            SceneManager.LoadScene(0);
        }
    }
}