using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        public Action<Vector2> OnMove;
        public float HorizontalDirection { get; private set; }
        [SerializeField] private CharacterController characterController;

        private void Update()
        {
            HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                characterController._fireRequired = true;
            }

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
            OnMove.Invoke(direction);
        }
    }
}