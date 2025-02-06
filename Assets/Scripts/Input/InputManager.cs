using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        public Action<Vector2> OnMove;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private GameStateController _gameStateController;
        public float HorizontalDirection { get; private set; }
        public bool IsPaused { get; private set; }

        private void Update()
        {
            HandlerKeyboard();
        }

        private void HandlerKeyboard()
        {
            FireHandler();
            MoveHandler();
            UIHandler();
        }

        private void FireHandler()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _characterController.FireRequired = true;
            }
        }

        private void MoveHandler()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Move(Vector2.left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                Move(Vector2.right);
            }
            else
            {
                Move(Vector2.zero);
            }
        }

        private void UIHandler()
        {
            if (Input.GetKeyDown(KeyCode.P) && IsPaused == false)
            {
                _gameStateController.PauseMenu();
                IsPaused = true;  
            } 
            else if (Input.GetKeyDown(KeyCode.P) && IsPaused == true) 
            {
                _gameStateController.ResumeGame();
                IsPaused = false;   
            }
        }

        private void Move(Vector2 direction)
        {
            OnMove.Invoke(direction);
        }
    }
}