using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace ShootEmUp
{
    public class GameInstaller : MonoBehaviour
    {
        public List<IGameStateListener> GameStateListener;
        public List<IUpdateable> IUpdateables = new List<IUpdateable>();
        public List<IFixedUpdateable> IFixedUpdateables = new List<IFixedUpdateable>();
        private GameInstaller _gameInstaller;
        [Space(15f), SerializeField] private GameStateController _gameStateController;
        [Space(15f), SerializeField] private EnemyPositions _EnemyPositions;
        [Space(15f), SerializeField] private EnemyManager _enemyManager;
        [Space(15f), SerializeField] private InputManager _inputManager;

        private int _delayTimer = 200;

        private void Awake()
        {
            FillServiceLocator();
        }

        private async void Start()
        {
            await GetLinkGameState();
        }

        public async Task GetLinkGameState()
        {
            await Task.Delay(_delayTimer);
            GameStateListener = FindObjectsOfType<MonoBehaviour>().OfType<IGameStateListener>().ToList();
            IUpdateables = FindObjectsOfType<MonoBehaviour>().OfType<IUpdateable>().ToList();
            IFixedUpdateables = FindObjectsOfType<MonoBehaviour>().OfType<IFixedUpdateable>().ToList();
        }

        public void FillServiceLocator()
        {
            ServiceLocator.AddServices(typeof(GameInstaller), this);
            ServiceLocator.AddServices(typeof(GameStateController), _gameStateController);
            ServiceLocator.AddServices(typeof(EnemyPositions), _EnemyPositions);
            ServiceLocator.AddServices(typeof(EnemyManager), _enemyManager);
            ServiceLocator.AddServices(typeof(InputManager), _inputManager);
        }

        public void RegisterNewIUpdateable(IUpdateable IUpdateable)
        {
            if (!IUpdateables.Contains(IUpdateable))
            {
                IUpdateables.Add(IUpdateable);
            }
        }

        public void RegisterNewIFixedUpdateable(IFixedUpdateable IFixedUpdateable)
        {
            if (!IFixedUpdateables.Contains(IFixedUpdateable))
            {
            IFixedUpdateables.Add(IFixedUpdateable);
            }
        }

        public void RegisterNewIGameState(IGameStateListener iGameState)
        {
            if (!GameStateListener.Contains(iGameState))
            {
                GameStateListener.Add(iGameState);
            }
        }
    }
}