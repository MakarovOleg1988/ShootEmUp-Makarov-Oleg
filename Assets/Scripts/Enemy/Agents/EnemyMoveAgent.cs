using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : Enemy, IMotionable
    {
        private Vector2 _destination;

        private float _valueMagnitude = 0.25f;
        public bool IsReached{ get; private set;}

        private void Awake()
        {
            _moveComponent = this.gameObject.GetComponent<MoveComponent>();        
        }

        private void OnEnable()
        {
            var attackPosition = ServiceLocator.GetService<EnemyPositions>().RandomAttackPosition();
            SetDestination(attackPosition);
        }

        public void SetDestination(Transform endPoint)
        {
            _destination = endPoint.position;
            IsReached = false;
        }

        private void FixedUpdate()
        {
            Motion(_destination);
        }

        public void Motion(Vector2 dir)
        {
            if (IsReached) return;

            var vector = dir - (Vector2)this.transform.position;

            if (vector.magnitude <= _valueMagnitude)
            {
                IsReached = true;
                return;
            }

            var destination = vector.normalized * Time.fixedDeltaTime;
            _moveComponent.MoveByRigidbodyVelocity(destination);
        }

    }
}