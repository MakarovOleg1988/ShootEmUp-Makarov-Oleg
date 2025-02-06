using System;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public sealed class UIMainMenu : MonoBehaviour, IStartGameListener, IDisposable
    {
        [SerializeField] private SceneSwitcher _sceneSwitcher;
        [SerializeField] private Button _startGameButton, _quitGameButton;

        private void Awake()
        {
            _startGameButton.onClick.AddListener(StartGame);
            _quitGameButton.onClick.AddListener(Quit);
        }

        public void StartGame()
        {
            _sceneSwitcher.LoadNextScene();

        }

        public void Quit()
        {
            _sceneSwitcher.QuitApplication();
        }

        public void Dispose()
        {
            _startGameButton.onClick.RemoveListener(StartGame);
            _quitGameButton.onClick.RemoveListener(Quit);
        }
    }
}