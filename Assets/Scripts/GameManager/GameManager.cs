using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private UIFinishViewer _uIFinishViewer;

        public void FinishGame()
        {
            _uIFinishViewer.onShowFinishCanvas.Invoke();
            Pause();
        }

        private void Pause()
        {
            Time.timeScale = 0;
        }
    }
}