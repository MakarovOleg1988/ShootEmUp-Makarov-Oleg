using System;
using TMPro;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour, IPauseGameListener, IResumeGameListener
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;
        [NonSerialized] public bool IsPlayer;
        [NonSerialized] public int Damage;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            GameInstaller gameInstaller = ServiceLocator.GetService<GameInstaller>();
            gameInstaller.RegisterNewIGameState(this.gameObject.GetComponent<IGameStateListener>());         
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision);
        }

        public void SetVelocity(Vector2 velocity)
        {
            _rigidbody2D.velocity = velocity;
        }

        public void SetPhysicsLayer(int physicsLayer)
        {
            gameObject.layer = physicsLayer;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetColor(Color color)
        {
            _spriteRenderer.color = color;
        }

        public void PauseGame()
        {
            _rigidbody2D.simulated = false;
        }

        public void ResumeGame()
        {
            _rigidbody2D.simulated = true;
        }
    }
}