using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour, IStartGameListener, IResumeGameListener, IFinishGameListener, IPauseGameListener
    {
        [SerializeField] private UIFinishViewer _uIFinishViewer;

        public void FinishGame()
        {
            _uIFinishViewer.onShowFinishCanvas.Invoke();
            Time.timeScale = 0;
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