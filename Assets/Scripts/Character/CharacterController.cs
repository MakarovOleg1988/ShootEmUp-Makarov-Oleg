using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour, IFireable
    {
        [Header("Objects")]
        [SerializeField] private GameObject _character;
        [SerializeField] private LevelBounds _levelBounds;

        [Header("Config")]
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletPlayerConfig;
        [SerializeField] private InputManager _input;

        private MainCharacter _mainCharacter => _character.GetComponent<MainCharacter>();
        private float _offsetX = 0.01f;

        private void Start()
        {
            _input.OnMove += Motion;
        }

        private void OnEnable()
        {
            if (_mainCharacter._hitPointsComponent.TryGetComponent(out HitPointsComponent _hitPointsComponent))
            {
                _hitPointsComponent.OnIsHpEmpty += this.OnCharacterDeath;
            }
        }

        private void OnDisable()
        {
            if (_mainCharacter._hitPointsComponent.TryGetComponent(out HitPointsComponent hitPointsComponent))
            {
                hitPointsComponent.OnIsHpEmpty -= this.OnCharacterDeath;
            }
        }

        private void OnCharacterDeath(GameObject character)
        {
            ServiceLocator.GetService<GameStateController>().FinishViewer();
        }

        private void FixedUpdate()
        {
            Fire();
        }

        private void Motion(Vector2 direction)
        {
            if (_levelBounds.InBounds(_mainCharacter._unitPos.position))
            {
                
                _mainCharacter._moveComponent.MoveByRigidbodyVelocity(direction * Time.fixedDeltaTime);
            }
            else
            {
                CheckBorders();
            }
        }

        private void CheckBorders()
        {
            Vector2 vector = _mainCharacter._unitPos.position;

            if (vector.x > _levelBounds.LeftBorder.position.x) _mainCharacter._unitPos.position = new Vector2(vector.x - _offsetX, vector.y);
            if (vector.x < _levelBounds.RightBorder.position.x) _mainCharacter._unitPos.position = new Vector2(vector.x + _offsetX, vector.y);
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
                    Position = _mainCharacter._weaponComponent.Position,
                    Velocity = _mainCharacter._weaponComponent.Rotation * Vector3.up * _bulletPlayerConfig.Speed
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