using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class UIFinishViewer : MonoBehaviour, IFinishGameListener
    {
        private Canvas _canvas;

        private void Start()
        {
            _canvas = gameObject.GetComponent<Canvas>();
        }

        public void FinishGame()
        {
            _canvas.EnableComponent();
            Debug.Log("Game over!");
        }
    }
}