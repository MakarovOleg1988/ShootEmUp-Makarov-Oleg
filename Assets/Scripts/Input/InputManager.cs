using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour, IUpdateable
    {
        public event Action<Vector2> OnMove;
        public event Action onPause;
        public float HorizontalDirection { get; private set; }
        public bool FireRequired{ get; set;}

        public void CustomUpdate()
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
            if (Input.GetKey(KeyCode.P))
            {  
                onPause?.Invoke();
            } 
        }
    }
}