using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour, IStartGameListener, IResumeGameListener, IFinishGameListener, IPauseGameListener, IStartMainMenuListener
    {
        [SerializeField] private InputManager _input;

        public void FinishGame()
        {
            Time.timeScale = 0;
        }

        public void StartMainMenu()
        {
            Time.timeScale = 1;
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
        }

        public void StartGame()
        {
            Time.timeScale = 1;
        }
    }
}