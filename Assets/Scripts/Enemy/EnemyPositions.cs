using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyPositions: IInitializable
    {        
        [Inject] private EnemyConfic _enemyConfic;
        private Transform[] _spawnPositions;
        private Transform[] _attackPositions;

        public void Initialize()
        {
            GameObject enemyPos = new GameObject("[ENEMY_POSITIONS]");

            GameObject spawn = _enemyConfic.SpawnParent;
            spawn.transform.parent = enemyPos.transform.parent; 
            
            GameObject attack = _enemyConfic.AttackParent;
            attack.transform.parent = enemyPos.transform.parent; 
        }

        public Transform RandomSpawnPosition()
        {
            return this.RandomTransform(this._spawnPositions);
        }

        public Transform RandomAttackPosition()
        {
            return this.RandomTransform(this._attackPositions);
        }

        private Transform RandomTransform(Transform[] transforms)
        {
            var index = Random.Range(0, transforms.Length);
            return transforms[index];
        }

        public int VolumeSpawnPosition()
        {
            var value = _spawnPositions.Length;
            return value;
        }
    }
}