using UnityEngine;

namespace ShootEmUp
{
    public interface ILevelBounds
    {
        public Vector3 LeftBorder { get; }
        public Vector3 RightBorder { get; }
        public Vector3 TopBorder { get; }
        public Vector3 DownBorder { get; }
    }
}