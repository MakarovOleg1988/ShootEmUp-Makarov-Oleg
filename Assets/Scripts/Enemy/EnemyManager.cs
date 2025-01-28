using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private BulletConfig bulletEnemyConfig;
        [SerializeField] private BulletSystem _bulletSystem;
        private readonly HashSet<GameObject> m_activeEnemies = new();
        [SerializeField] private float delaySpawnTime = 1.0f;

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(delaySpawnTime);
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
                physicsLayer = (int)this.bulletEnemyConfig.PhysicsLayer,
                color = this.bulletEnemyConfig.Color,
                damage = this.bulletEnemyConfig.Damage,
                position = position,
                velocity = direction * 2.0f
            });
        }
    }
}