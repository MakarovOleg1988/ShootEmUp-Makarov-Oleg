using UnityEngine;

namespace ShootEmUp
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] public MoveComponent _moveComponent;
        [SerializeField] public WeaponComponent _weaponComponent;
        [SerializeField] public HitPointsComponent _hitPointsComponent;
        [SerializeField] public Transform _unitPos;
    }
}
