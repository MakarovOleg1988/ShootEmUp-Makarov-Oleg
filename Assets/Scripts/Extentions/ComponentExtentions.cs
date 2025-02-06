using UnityEngine;

namespace ShootEmUp
{
    public static class ComponentExtentions
    {
        public static void EnableComponent(this Behaviour component) => component.enabled = true;
        public static void DisableComponent(this Behaviour component) => component.enabled = false;
    }
}