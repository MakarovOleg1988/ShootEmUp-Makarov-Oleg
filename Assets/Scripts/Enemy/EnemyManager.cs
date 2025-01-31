using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private BulletConfig _bulletEnemyConfig;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private GameObject _character;
        private readonly HashSet<GameObject> m_activeEnemies = new();
        [SerializeField] private float _delaySpawnTime = 1.0f;

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(_delaySpawnTime);
                var enemy = this._enemyPool.SpawnEnemy();
                if (enemy != null)
                {
                    if (this.m_activeEnemies.Add(enemy))
                    {
                        enemy.GetComponent<HitPointsComponent>().hpEmpty += this.OnDestroyed;
                        enemy.GetComponent<EnemyAttackAgent>().OnFire += this.OnFire;
                    }    
                }
            }
        }

        public Transform SetFireTarget()
        {
            Transform target = _character.transform;
            return target;
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (m_activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().hpEmpty -= this.OnDestroyed;
                enemy.GetComponent<EnemyAttackAgent>().OnFire -= this.OnFire;

                _enemyPool.UnspawnEnemy(enemy);
            }
        }

        private void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = false,
                physicsLayer = (int)this._bulletEnemyConfig.PhysicsLayer,
                color = this._bulletEnemyConfig.Color,
                damage = this._bulletEnemyConfig.Damage,
                position = position,
                velocity = direction * 2.0f
            });
        }
    }
}