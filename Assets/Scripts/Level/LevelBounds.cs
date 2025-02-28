using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class LevelBounds
    {
        [Inject] private LevelBoundsConfic _levelBoundsConfic;

        public Vector3 LeftBorder
        {
            get { return _levelBoundsConfic.LeftBorder; }
        }

        public Vector3 RightBorder 
        {
            get { return _levelBoundsConfic.RightBorder; }
        }

        public Vector3 TopBorder         
        {
            get { return _levelBoundsConfic.TopBorder; }
        }
        public Vector3 DownBorder         
        {
            get { return _levelBoundsConfic.DownBorder; }
        }

        public bool InBounds(Vector3 position)
        {
            var positionX = position.x;
            var positionY = position.y;

            return positionX > _levelBoundsConfic.LeftBorder.x
                   && positionX < _levelBoundsConfic.RightBorder.x
                   && positionY > _levelBoundsConfic.DownBorder.y
                   && positionY < _levelBoundsConfic.TopBorder.y;
        }
    }
}