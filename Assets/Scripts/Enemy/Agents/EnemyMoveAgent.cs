using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour, IMotionable
    {
        [SerializeField] private MoveComponent _moveComponent;
        private Vector2 _destination;
        public bool IsReached{ get; private set;}

        private void OnEnable()
        {
            var attackPosition = FindObjectOfType<EnemyPositions>().RandomAttackPosition();
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
            if (IsReached)
            {
                return;
            }

            var vector = dir - (Vector2)this.transform.position;

            if (vector.magnitude <= 0.25f)
            {
                IsReached = true;
                return;
            }

            var destination = vector.normalized * Time.fixedDeltaTime;
            _moveComponent.MoveByRigidbodyVelocity(destination);
        }

    }
}