using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class HitPointsComponent : MonoBehaviour
    {
        public event Action<GameObject> OnIsHpEmpty;

        [SerializeField] private int _hitPoints;
        
        public bool IsHitPointsExists()
        {
            return _hitPoints > 0;
        }

        public void TakeDamage(int damage)
        {
            _hitPoints -= damage;
            
            if (_hitPoints <= 0)
            {
                OnIsHpEmpty?.Invoke(this.gameObject);
            }
        }
    }
}