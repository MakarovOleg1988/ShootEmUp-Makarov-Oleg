using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPositions : MonoBehaviour
    {
        [SerializeField] public Transform[] SpawnPositions;
        [SerializeField] private Transform[] _attackPositions;

        public Transform RandomSpawnPosition()
        {
            return this.RandomTransform(this.SpawnPositions);
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
            var value = SpawnPositions.Length;
            return value;
        }
    }
}