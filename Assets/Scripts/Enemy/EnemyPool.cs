using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Spawn")]
        [SerializeField] private EnemyPositions _enemyPositions;
        [SerializeField] private Transform _ActiveEnemyContainer;
        
        [Header("Pool")]
        [SerializeField] private Transform _container;
        [SerializeField] private GameObject _prefab;

        private readonly Queue<GameObject> enemyPool = new();
        
        private void Awake()
        {
            FullEnemyPool(_enemyPositions.VolumeSpawnPosition());
        }

        private void FullEnemyPool(int value)
        {
            for (var i = 0; i < value; i++)
            {
                var enemy = Instantiate(_prefab, _container);
                enemyPool.Enqueue(enemy);
            }
        }

        public GameObject SpawnEnemy()
        {
            if (!enemyPool.TryDequeue(out var enemy))
            {
                return null;
            }

            enemy.transform.SetParent(_ActiveEnemyContainer);

            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            
            return enemy;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(_container);
            enemyPool.Enqueue(enemy);
        }
    }
}