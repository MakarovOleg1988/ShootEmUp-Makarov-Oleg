using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour, IFireable
    {
        private InputManager _input;
        [SerializeField] private GameObject _character;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletPlayerConfig;
        public bool FireRequired{ get; set;}

        private void Awake()
        {
            _input = FindObjectOfType<InputManager>();
        }

        private void Start()
        {
            _input.OnMove += Motion;
        }

        private void OnEnable() => _character.GetComponent<HitPointsComponent>().hpEmpty += this.OnCharacterDeath;
        private void OnDisable() => _character.GetComponent<HitPointsComponent>().hpEmpty -= this.OnCharacterDeath;
        private void OnCharacterDeath(GameObject _character) => _gameManager.FinishGame();

        private void FixedUpdate()
        {
            Fire();
        }

        private void Motion(Vector2 direction)
        {
            _character.GetComponent<MoveComponent>().MoveByRigidbodyVelocity(direction * Time.fixedDeltaTime);
        }

        public void Fire()
        {
            if (FireRequired)
            {
                WeaponComponent weapon = _character.GetComponent<WeaponComponent>();
                _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
                {
                    isPlayer = true,
                    physicsLayer = (int)_bulletPlayerConfig.PhysicsLayer,
                    color = _bulletPlayerConfig.Color,
                    damage = _bulletPlayerConfig.Damage,
                    position = weapon.Position,
                    velocity = weapon.Rotation * Vector3.up * _bulletPlayerConfig.Speed
                });

                FireRequired = false;
            }
        }

        private void OnDestroy()
        {
            _input.OnMove -= Motion;
        }
    }
}