using UnityEngine.SceneManagement;

namespace ShootEmUp
{
    public class SceneSwitcher
    {
        private int _defaultScene = 0;

        public void LoadSelectedScene(int indexScene)
        {
            SceneManager.LoadScene(indexScene);
        }

        public void LoadMainMenuScene()
        {
            SceneManager.LoadScene(_defaultScene);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void QuitApplication()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE_WIN && !UNITY_EDITOR
            Application.Quit();
#endif
        }
    }
}