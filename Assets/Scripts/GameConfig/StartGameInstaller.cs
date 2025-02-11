using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace ShootEmUp
{
    public class StartGameInstaller : MonoBehaviour
    {
        public IGameStateListener[] GameStateListener;
        [SerializeField] private GameStateController _gameStateController;
        [SerializeField] private EnemyPositions _EnemyPositions;
        [SerializeField] private EnemyManager _enemyManager;

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
            GameStateListener = FindObjectsOfType<MonoBehaviour>().OfType<IGameStateListener>().ToArray();
        }

        public void FillServiceLocator()
        {
            ServiceLocator.AddServices(typeof(GameStateController), _gameStateController);     
            ServiceLocator.AddServices(typeof(EnemyPositions), _EnemyPositions);           
            ServiceLocator.AddServices(typeof(EnemyManager), _enemyManager);
        }
        
    }
}