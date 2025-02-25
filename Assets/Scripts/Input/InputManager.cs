using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        public event Action<Vector2> OnMove;
        public event Action<bool> onPause;
        public float HorizontalDirection { get; private set; }
        public bool IsPaused { get; private set; }
        public bool FireRequired{ get; set;}

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
                FireRequired = true;
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

        private void Move(Vector2 direction)
        {
            OnMove?.Invoke(direction);
        }

        private void UIHandler()
        {
            if (Input.GetKeyDown(KeyCode.P) && IsPaused == false)
            {
                IsPaused = true;  
                onPause?.Invoke(IsPaused);
            } 
            else if (Input.GetKeyDown(KeyCode.P) && IsPaused == true) 
            {
                IsPaused = false;  
                onPause?.Invoke(IsPaused);   
            }
        }
    }
}