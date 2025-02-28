using UnityEngine;

namespace ShootEmUp
{
    public class GameManager : IStartMainMenuListener, IStartGameListener, IFinishGameListener, IPauseGameListener, IResumeGameListener
    {
        public bool CanPlay { get; private set; } = true;

        public void FinishGame()
        {
            CanPlay = false;
        }

        public void StartMainMenu()
        {
            CanPlay = true;
        }

        public void PauseGame()
        {
            CanPlay = false;
        }

        public void ResumeGame()
        {
            CanPlay = true;
        }

        public void StartGame()
        {
            CanPlay = true;
        }
    }
}