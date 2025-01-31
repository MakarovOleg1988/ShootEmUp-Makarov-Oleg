using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class UIFinishViewer : MonoBehaviour, IDisposable
    {
        public Action onShowFinishCanvas;

        private void Start()
        {
            onShowFinishCanvas += ShowFinishCanvas;
        }

        private void ShowFinishCanvas()
        {
            Debug.Log("Game over!");
        }

        public void Dispose()
        {
            onShowFinishCanvas -= ShowFinishCanvas;
        }
    }
}