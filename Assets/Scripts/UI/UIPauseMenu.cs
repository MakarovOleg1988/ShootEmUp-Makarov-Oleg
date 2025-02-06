using System;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public sealed class UIPauseMenu : MonoBehaviour, IResumeGameListener, IStartMainMenuListener, IPauseGameListener, IDisposable
    {
        [SerializeField] private SceneSwitcher _sceneSwitcher;
        [SerializeField] private Button _resumeGameButton, _returnToMainMenuButton;

        private void Awake()
        {
            _resumeGameButton.onClick.AddListener(ResumeGame);
            _returnToMainMenuButton.onClick.AddListener(StartMainMenu);
        }

        public void PauseGame()
        {
            this.gameObject.GetComponent<Canvas>().EnableComponent();
        }

        public void ResumeGame()
        {
            this.gameObject.GetComponent<Canvas>().DisableComponent();
        }

        public void StartMainMenu()
        {
            _sceneSwitcher.LoadMainMenuScene();
        }

        public void Dispose()
        {
            _resumeGameButton.onClick.RemoveListener(ResumeGame);
            _returnToMainMenuButton.onClick.RemoveListener(StartMainMenu);
        }


    }
}