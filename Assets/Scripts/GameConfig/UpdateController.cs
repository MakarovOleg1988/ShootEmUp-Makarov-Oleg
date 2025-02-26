using UnityEngine;

namespace ShootEmUp
{
    public class UpdateController : MonoBehaviour
    {
        private GameInstaller _gameInstaller;
        [SerializeField] private GameManager _gameManager;

        private void Start()
        {
            _gameInstaller = ServiceLocator.GetService<GameInstaller>();
        }

        public void Update()
        {
            if (_gameManager.CanPlay)
            {
                foreach (var updateable in _gameInstaller.IUpdateables)
                {
                    updateable.CustomUpdate();
                }
            }
        }

        public void FixedUpdate()
        {
            if (_gameManager.CanPlay)
            {
                foreach (var fixedUpdateable in _gameInstaller.IFixedUpdateables)
                {
                    fixedUpdateable.CustomFixedUpdate();
                }
            }
        }
    }
}
