using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    [CreateAssetMenu(menuName = "Data/EnemyConfigInstaller", fileName = "EnemyConfigInstaller")]
    public class EnemyConfigInstaller : ScriptableObjectInstaller<EnemyConfigInstaller>
    {
        [SerializeField] public EnemyConfic EnemyConfic;
        public override void InstallBindings()
        {
            Container.Bind<EnemyConfic>().FromInstance(EnemyConfic).AsSingle();
        }
    }

    [Serializable]
    public class EnemyConfic
    {
        [SerializeField] public GameObject SpawnParent;
        [SerializeField] public GameObject AttackParent;
    }
}