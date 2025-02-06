using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootEmUp
{
    public class SceneSwitcher : MonoBehaviour
    {
        public void LoadSelectedScene(int indexScene) => SceneManager.LoadScene(indexScene);
        public void LoadMainMenuScene() => SceneManager.LoadScene(0);
        public void ReloadScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        public void LoadNextScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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