using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class UIFinishViewer : MonoBehaviour, IDisposable
    {
        private Canvas canvas;
        public Action onShowFinishCanvas;

        private void Start()
        {
            canvas = this.gameObject.GetComponent<Canvas>();

            onShowFinishCanvas += ShowFinishCanvas;
        }

        private void ShowFinishCanvas()
        {
            canvas.EnableComponent();
            Debug.Log("Game over!");
        }

        public void Dispose()
        {
            onShowFinishCanvas -= ShowFinishCanvas;
        }
    }
}