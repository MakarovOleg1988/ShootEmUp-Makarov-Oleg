using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        [SerializeField] private MoveComponent moveComponent;
        private Vector2 destination;
        private bool isReached;
        public bool IsReached
        {
            get { return this.isReached; }
        }

        public void SetDestination(Vector2 endPoint)
        {
            this.destination = endPoint;
            this.isReached = false;
        }

        private void FixedUpdate()
        {
            Motion();
        }

        private void Motion()
        {
            if (this.isReached)
            {
                return;
            }
            
            var vector = this.destination - (Vector2) this.transform.position;
            if (vector.magnitude <= 0.25f)
            {
                this.isReached = true;
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            this.moveComponent.MoveByRigidbodyVelocity(direction);
        }
    }
}