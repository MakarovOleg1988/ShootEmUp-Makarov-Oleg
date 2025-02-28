using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Spawn")]
        [Inject] private EnemyPositions _enemyPositions;
        [SerializeField] private Transform _ActiveEnemyContainer;
        
        [Header("Pool")]
        [SerializeField] private Transform _container;
        [SerializeField] private GameObject _prefab;

        private readonly Queue<GameObject> _enemyPool = new();
        
        private void Awake()
        {
            _enemyPositions.Initialize();
            FullEnemyPool(_enemyPositions.VolumeSpawnPosition());
        }

        private void FullEnemyPool(int value)
        {
            for (var i = 0; i < value; i++)
            {
                var enemy = Instantiate(_prefab, _container);
                _enemyPool.Enqueue(enemy);
            }
        }

        public bool TrySpawnEnemy(out GameObject spaceShip)
        {
            if (!_enemyPool.TryDequeue(out var enemy))
            {
                return spaceShip = null;
            }

            enemy.transform.SetParent(_ActiveEnemyContainer);

            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            
            return spaceShip = enemy;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(_container);
            _enemyPool.Enqueue(enemy);
        }
    }
}