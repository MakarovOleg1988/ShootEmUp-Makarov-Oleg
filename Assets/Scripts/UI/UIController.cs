using System;
using UnityEngine;

namespace ShootEmUp
{
    public class UIController : MonoBehaviour
    {
        private void Start()
        {
            ServiceLocator.GetService<InputManager>().onPause += SwitchPauseMenu;
        }

        private void SwitchPauseMenu(bool IsPause)
        {
            if (IsPause) ServiceLocator.GetService<GameStateController>().PauseMenu();
            if (!IsPause) ServiceLocator.GetService<GameStateController>().ResumeGame();
        }

        private void OnDestroy()
        {
            ServiceLocator.GetService<InputManager>().onPause -= SwitchPauseMenu;
        }
    }
}