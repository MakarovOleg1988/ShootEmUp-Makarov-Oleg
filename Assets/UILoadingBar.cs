using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace ShootEmUp
{
    public class UILoadingBar : MonoBehaviour, IDisposable
    {
        [SerializeField, Range(0.1f, 20.0f)] private float _delayTimer;
        [SerializeField] private TextMeshProUGUI countText;
        public bool IsLoading { get; private set; }

        public Action OnLaunchCountdown;

        private void Awake()
        {
            OnLaunchCountdown += LaunchCountdown;
        }

        private void LaunchCountdown()
        {
            StartCoroutine(CountdownCoroutine());
        }

        private IEnumerator CountdownCoroutine()
        {
            while (_delayTimer >= 0)
            {
                countText.text = Mathf.Round(_delayTimer).ToString();
                yield return new WaitForSeconds(_delayTimer);
            }

            IsLoading = false;
        }

        public void Dispose()
        {
            OnLaunchCountdown -= LaunchCountdown;
        }
    }
}


