using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public sealed class UIMainMenu : MonoBehaviour, IStartGameListener, IDisposable
    {
        [SerializeField] private SceneSwitcher _sceneSwitcher;
        [SerializeField] private Canvas _startMenuCanvas;
        [SerializeField] private Canvas _loadingBarCanvas;
        [SerializeField] private TextMeshProUGUI _countText;
        [SerializeField, Header("Button")] private Button _startGameButton, _quitGameButton;

        [SerializeField, Range(0.1f, 20.0f)] private float _count;


        private void Awake()
        {
            _startGameButton.onClick.AddListener(StartGame);
            _quitGameButton.onClick.AddListener(Quit);
        }

        public void StartGame()
        {
            LaunchLoadingScreen();
        }

        private void LaunchLoadingScreen()
        {
            _startMenuCanvas.DisableComponent();
            StartCoroutine(CountdownCoroutine(_count));
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

        private IEnumerator CountdownCoroutine(float duration)
        {
            _loadingBarCanvas.EnableComponent();

            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                _countText.text = Mathf.Round(elapsedTime).ToString();
                elapsedTime += Time.deltaTime;
                yield return null; 
            }

            _sceneSwitcher.LoadNextScene();
        }
    }
}