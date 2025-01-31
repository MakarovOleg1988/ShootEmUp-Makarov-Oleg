using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour, IFireable
    {
        public delegate void FireHandler(GameObject enemy, Vector2 position, Vector2 direction);
        public event FireHandler OnFire;

        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private EnemyMoveAgent _moveAgent;
        [SerializeField] private float _countdown;
        private Transform _target;
        private float _currentTime;

        private void Start()
        {
            _target = FindObjectOfType<EnemyManager>().SetFireTarget();
        }

        public void Reset()
        {
            _currentTime = _countdown;
        }

        private void FixedUpdate()
        {
            if (!_moveAgent.IsReached)
            {
                return;
            }
            
            if (!_target.gameObject.GetComponent<HitPointsComponent>().IsHitPointsExists())
            {
                return;
            }

            _currentTime -= Time.fixedDeltaTime;
            if (_currentTime <= 0)
            {
                this.Fire();
                _currentTime += _countdown;
            }
        }

        public void Fire()
        {
            var startPosition = this._weaponComponent.Position;
            var vector = (Vector2)this._target.transform.position - startPosition;
            var direction = vector.normalized;
            OnFire?.Invoke(this.gameObject, startPosition, direction);
        }
    }
}