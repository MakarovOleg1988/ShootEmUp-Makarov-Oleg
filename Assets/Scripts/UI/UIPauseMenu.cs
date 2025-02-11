using System;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public sealed class UIPauseMenu : MonoBehaviour, IPauseGameListener, IResumeGameListener, IDisposable
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private SceneSwitcher _sceneSwitcher;
        [SerializeField] private Button _returnToMainMenuButton;

        private void Awake()
        {
            _returnToMainMenuButton.onClick.AddListener(StartMainMenu);
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
            ServiceLocator.GetService<GameStateController>().ResumeGame();
            _sceneSwitcher.LoadMainMenuScene();
        }

        public void Dispose()
        {
            _returnToMainMenuButton.onClick.RemoveListener(StartMainMenu);
        }


    }
}