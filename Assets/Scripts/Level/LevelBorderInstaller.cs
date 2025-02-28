using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    [CreateAssetMenu(menuName = "Data/LevelBorderInstaller", fileName = "LevelBorderInstaller")]
    public class LevelBorderInstaller : ScriptableObjectInstaller<LevelBorderInstaller>
    {
        [SerializeField] public LevelBoundsConfic LevelBoundsConfic;
        
        public override void InstallBindings()
        {
            Container.Bind<ILevelBounds>().To<LevelBoundsConfic>().FromInstance(LevelBoundsConfic).AsSingle();
        }
    }

    [Serializable]
    public class LevelBoundsConfic: ILevelBounds
    {
        [SerializeField] private Vector3 _downBorder;
        [SerializeField] private Vector3 _topBorder;
        [SerializeField] private Vector3 _leftBorder;
        [SerializeField] private Vector3 _rightBorder;

        public Vector3 LeftBorder => _leftBorder;
        public Vector3 RightBorder => _rightBorder;
        public Vector3 TopBorder => _topBorder;
        public Vector3 DownBorder => _downBorder;
    }
}