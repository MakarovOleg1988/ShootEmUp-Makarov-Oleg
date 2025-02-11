using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameStateController : MonoBehaviour
    {
        [SerializeField] private StartGameInstaller _startGameInstaller;
        [Space(10f)] private GameState _gameState;

        public void StartGame()
        {
            _gameState = GameState.PLAYING;
            Debug.Log(_gameState);

            foreach (IGameStateListener listener in _startGameInstaller.GameStateListener)
            {
                if (listener is IStartGameListener l) 
                {
                    l.StartGame();
                } 
            }
        }

        public void MainMenu()
        {
            _gameState = GameState.MAINMENU;
            Debug.Log(_gameState);

            foreach (IGameStateListener listener in _startGameInstaller.GameStateListener)
            {
                if (listener is IResumeGameListener l) 
                {
                    l.ResumeGame();
                } 
            }
        }

        public void PauseMenu()
        {
            _gameState = GameState.PAUSED;
            Debug.Log(_gameState);

            foreach (IGameStateListener listener in _startGameInstaller.GameStateListener)
            {
                if (listener is IPauseGameListener l) 
                {
                    l.PauseGame();
                } 
            }
        }

        public void ResumeGame()
        {
            _gameState = GameState.PLAYING;
            Debug.Log(_gameState);

            foreach (IGameStateListener listener in _startGameInstaller.GameStateListener)
            {
                if (listener is IResumeGameListener l) 
                {
                    l.ResumeGame();
                } 
            }
        }

        public void FinishViewer()
        {
            _gameState = GameState.FINISHED;

            foreach (IGameStateListener listener in _startGameInstaller.GameStateListener)
            {
                if (listener is IFinishGameListener l) 
                {
                    l.FinishGame();
                } 
            }
        }
    }
}