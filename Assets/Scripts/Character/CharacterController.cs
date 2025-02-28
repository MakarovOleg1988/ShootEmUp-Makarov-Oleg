using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class CharacterController : MainCharacter, IFireable, IFixedUpdateable
    {
        [Header("Objects")]
        [SerializeField] private GameObject _character;


        [Header("Config")]
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletPlayerConfig;
        [Inject] private LevelBounds _levelBounds;
        [Inject] private InputManager _input;

        private float _offsetX = 0.01f;

        private void Awake()
        {
            _moveComponent = _character.GetComponent<MoveComponent>();
            _weaponComponent = _character.GetComponent<WeaponComponent>();
            _hitPointsComponent = _character.GetComponent<HitPointsComponent>();
            _unitPos = _character.GetComponent<Transform>();
        }

        private void Start()
        {
            _input.OnMove += Motion;
        }

        private void OnEnable()
        {
            if (_hitPointsComponent != null)
            {
                _hitPointsComponent.OnIsHpEmpty += this.OnCharacterDeath;
            }
        }

        private void OnDisable()
        {
            if (_hitPointsComponent != null)
            {
                _hitPointsComponent.OnIsHpEmpty -= this.OnCharacterDeath;
            }
        }

        private void OnCharacterDeath(GameObject character)
        {
            ServiceLocator.GetService<GameStateController>().FinishViewer();
        }

        public void CustomFixedUpdate()
        {
            Fire();
        }

        private void Motion(Vector2 direction)
        {
            if (_levelBounds.InBounds(_unitPos.position))
            {

                _moveComponent.MoveByRigidbodyVelocity(direction * Time.fixedDeltaTime);
            }
            else
            {
                CheckBorders();
            }
        }

        private void CheckBorders()
        {
            Vector2 vector = _unitPos.position;

            if (vector.x > _levelBounds.LeftBorder.x) _unitPos.position = new Vector2(vector.x - _offsetX, vector.y);
            if (vector.x < _levelBounds.RightBorder.x) _unitPos.position = new Vector2(vector.x + _offsetX, vector.y);
        }

        public void Fire()
        {
            if (_input.FireRequired)
            {
                _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
                {
                    IsPlayer = true,
                    PhysicsLayer = (int)_bulletPlayerConfig.PhysicsLayer,
                    Color = _bulletPlayerConfig.Color,
                    Damage = _bulletPlayerConfig.Damage,
                    Position = _weaponComponent.Position,
                    Velocity = _weaponComponent.Rotation * Vector3.up * _bulletPlayerConfig.Speed
                });

                _input.FireRequired = false;
            }
        }

        private void OnDestroy()
        {
            _input.OnMove -= Motion;
        }
    }
}