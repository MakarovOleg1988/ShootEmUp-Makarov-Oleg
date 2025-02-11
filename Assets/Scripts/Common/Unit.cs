using UnityEngine;

namespace ShootEmUp
{
    public abstract class Unit : MonoBehaviour
    {
        protected MoveComponent _moveComponent;
        protected WeaponComponent _weaponComponent;
        protected HitPointsComponent _hitPointsComponent;
        protected Transform _unitPos;
    }
}
