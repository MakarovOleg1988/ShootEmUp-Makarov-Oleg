using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : Enemy
    {
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private BulletConfig _bulletEnemyConfig;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private GameObject _character;
        [SerializeField, Range(1.0f, 10.0f)] private float _delaySpawnTime = 1.0f;
        [SerializeField, Range(1.0f, 10.0f)] private float _offset = 2.0f;

        private readonly HashSet<GameObject> _activeEnemies = new();

        private void Start()
        {
            StartCoroutine(PrepareEnemyPool());
        }

        private IEnumerator PrepareEnemyPool()
        {
            while (true)
            {
                yield return new WaitForSeconds(_delaySpawnTime);

                GameObject enemyShip;
                _enemyPool.TrySpawnEnemy(out enemyShip);
                
                if (enemyShip != null)
                {
                    if (this._activeEnemies.Add(enemyShip))
                    {
                        enemyShip.GetComponent<HitPointsComponent>().OnIsHpEmpty += this.OnDestroyed;
                        enemyShip.GetComponent<EnemyAttackAgent>().OnFire += this.OnFire;
                    }
                }
            }
        }

        public Transform GetFireTarget()
        {
            Transform target = _character.transform;
            return target;
        }

        private void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                IsPlayer = false,
                PhysicsLayer = (int)this._bulletEnemyConfig.PhysicsLayer,
                Color = this._bulletEnemyConfig.Color,
                Damage = this._bulletEnemyConfig.Damage,
                Position = position,
                Velocity = direction * _offset
            });
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (_activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().OnIsHpEmpty -= this.OnDestroyed;
                enemy.GetComponent<EnemyAttackAgent>().OnFire -= this.OnFire;

                _enemyPool.UnspawnEnemy(enemy);
            }
        }
    }
}