using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPositions : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPositions;
        [SerializeField] private Transform[] _attackPositions;

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