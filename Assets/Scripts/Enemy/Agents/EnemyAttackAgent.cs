using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour, IFireable
    {
        public delegate void FireHandler(GameObject enemy, Vector2 position, Vector2 direction);
        public event FireHandler OnFire;

        [SerializeField] private EnemyMoveAgent _moveAgent;
        [SerializeField] private float _countdown;

        private Enemy _enemy => this.gameObject.GetComponent<Enemy>();
        private Transform _target;
        private float _currentTime;

        private void Start()
        {
            _target = ServiceLocator.GetService<EnemyManager>().GetFireTarget();
            _currentTime = _countdown;
        }

        private void FixedUpdate()
        {
            PrepareFire();
        }

        private void PrepareFire()
        {
            if (!_moveAgent.IsReached)
            {
                return;
            }
            

            _currentTime -= Time.fixedDeltaTime;
            
            if (_currentTime <= 0)
            {
                Fire();
                _currentTime += _countdown;
            }
        }

        public void Fire()
        {
            var startPosition = _enemy._weaponComponent.Position;
            var vector = (Vector2)_target.transform.position - startPosition;
            var direction = vector.normalized;
            OnFire?.Invoke(gameObject, startPosition, direction);
        }
    }
}