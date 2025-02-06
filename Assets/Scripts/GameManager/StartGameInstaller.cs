using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace ShootEmUp
{
    public class StartGameInstaller : MonoBehaviour
    {
        public IGameStateListener[] _gameStateListener;
        private int _delayTimer = 1;

        public async Task SetLink()
        {
            await Task.Delay(_delayTimer * 500);
            _gameStateListener = FindObjectsOfType<MonoBehaviour>().OfType<IGameStateListener>().ToArray();
        }
    }
}