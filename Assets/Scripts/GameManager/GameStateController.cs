using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameStateController : MonoBehaviour
    {
        [SerializeField] private StartGameInstaller _startGameInstaller;
        [Space(10f)]public GameState GameState;

        private async void Start()
        {
            await _startGameInstaller.SetLink();
        }

        public void StartGame()
        {
            GameState = GameState.PLAYING;

            foreach (IGameStateListener listener in _startGameInstaller._gameStateListener)
            {
                if (listener is IStartGameListener l) 
                {
                    l.StartGame();
                } 
            }
        }

        public void MainMenu()
        {
            GameState = GameState.MAINMENU;

            foreach (IGameStateListener listener in _startGameInstaller._gameStateListener)
            {
                if (listener is IResumeGameListener l) 
                {
                    l.ResumeGame();
                } 
            }
        }

        public void PauseMenu()
        {
            GameState = GameState.PAUSED;

            foreach (IGameStateListener listener in _startGameInstaller._gameStateListener)
            {
                if (listener is IPauseGameListener l) 
                {
                    l.PauseGame();
                } 
            }
        }

        public void ResumeGame()
        {
            GameState = GameState.PLAYING;

            foreach (IGameStateListener listener in _startGameInstaller._gameStateListener)
            {
                if (listener is IResumeGameListener l) 
                {
                    l.ResumeGame();
                } 
            }
        }

        public void FinishViewer()
        {
            GameState = GameState.FINISHED;

            foreach (IGameStateListener listener in _startGameInstaller._gameStateListener)
            {
                if (listener is IFinishGameListener l) 
                {
                    l.FinishGame();
                } 
            }
        }
    }
}