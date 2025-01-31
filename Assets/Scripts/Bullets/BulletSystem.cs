using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField] private int _initialCount = 50;
        [SerializeField] private Transform _container;
        [SerializeField] private Bullet _prefab;
        [SerializeField] private Transform _activeBulletContainer;
        [SerializeField] private LevelBounds _levelBounds;
        
        private readonly Queue<Bullet> m_bulletPool = new();
        private readonly HashSet<Bullet> m_activeBullets = new();
        private readonly List<Bullet> m_cache = new();
        
        private void Awake()
        {
            FullBulletPool(_initialCount);
        }

        private void FullBulletPool(int value)
        {
            for (var i = 0; i < value; i++)
            {
                var bullet = Instantiate(_prefab, _container);
                m_bulletPool.Enqueue(bullet);
            }
        }
        
        private void FixedUpdate()
        {
            CheckBulletPool();
        }

        private void CheckBulletPool()
        {
            m_cache.Clear();
            m_cache.AddRange(m_activeBullets);

            for (int i = 0, count = m_cache.Count; i < count; i++)
            {
                var bullet = m_cache[i];
                if (!_levelBounds.InBounds(bullet.transform.position))
                {
                    RemoveBullet(bullet);
                }
            }
        }

        public void FlyBulletByArgs(Args args)
        {
            if (m_bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(_activeBulletContainer);
            }
            else
            {
                bullet = Instantiate(_prefab, _activeBulletContainer);
            }

            bullet.SetPosition(args.position);
            bullet.SetColor(args.color);
            bullet.SetPhysicsLayer(args.physicsLayer);
            bullet.Damage = args.damage;
            bullet.IsPlayer = args.isPlayer;
            bullet.SetVelocity(args.velocity);
            
            if (m_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (m_activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= OnBulletCollision;
                bullet.transform.SetParent(_container);
                m_bulletPool.Enqueue(bullet);
            }
        }
        
        public struct Args
        {
            public Vector2 position;
            public Vector2 velocity;
            public Color color;
            public int physicsLayer;
            public int damage;
            public bool isPlayer;
        }
    }
}