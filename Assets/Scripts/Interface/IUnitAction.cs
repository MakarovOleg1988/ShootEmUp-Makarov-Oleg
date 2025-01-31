using UnityEngine;

namespace ShootEmUp
{
    public interface IFireable
    {
        void Fire();
    }

    public interface IMotionable
    {
        void Motion(Vector2 direction);
    }
}