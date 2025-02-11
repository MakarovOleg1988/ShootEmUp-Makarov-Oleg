using UnityEngine;

namespace ShootEmUp
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        [SerializeField] private Transform _firePoint;

        public Vector2 Position
        {
            get { return this._firePoint.position; }
        }

        public Quaternion Rotation
        {
            get { return this._firePoint.rotation; }
        }


    }
}