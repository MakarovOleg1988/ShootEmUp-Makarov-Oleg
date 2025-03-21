using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public sealed class UIPauseMenu : MonoBehaviour, IPauseGameListener, IResumeGameListener
    {

        [SerializeField] private Canvas _canvas;
        [SerializeField] private SceneSwitcher _sceneSwitcher;
        [SerializeField] private Button _returnToMainMenuButton, _resumeButton;

        private void Awake()
        {
            _returnToMainMenuButton.onClick.AddListener(StartMainMenu);
            _resumeButton.onClick.AddListener(Resume);
        }

        private void Start()
        {
            ServiceLocator.GetService<InputManager>().onPause += Pause;
        }

        private void Pause()
        {
            ServiceLocator.GetService<GameStateController>().PauseMenu();
        }

        private void Resume()
        {
            ServiceLocator.GetService<GameStateController>().ResumeGame();
        }

        public void PauseGame()
        {
            _canvas.EnableComponent();
        }
        public void ResumeGame()
        {
            _canvas.DisableComponent();
        }

        public void StartMainMenu()
        {
            _sceneSwitcher.LoadMainMenuScene();
        }

        public void OnDestroy()
        {
            _returnToMainMenuButton.onClick.RemoveListener(StartMainMenu);
            _resumeButton.onClick.RemoveListener(Resume);

            ServiceLocator.GetService<InputManager>().onPause -= Pause;
        }


    }
}