using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour, IUnitAction
    {
        private InputManager _input;
        [SerializeField] private GameObject _character;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletPlayerConfig;

        public bool _fireRequired;

        private void Awake()
        {
            _input = FindObjectOfType<InputManager>();
        }

        private void Start()
        {
            _input.OnMove += Motion;
        }

        private void OnEnable() => this._character.GetComponent<HitPointsComponent>().hpEmpty += this.OnCharacterDeath;
        private void OnDisable() => this._character.GetComponent<HitPointsComponent>().hpEmpty -= this.OnCharacterDeath;
        private void OnCharacterDeath(GameObject _) => this._gameManager.FinishGame();

        private void FixedUpdate()
        {
            this.Fire();
        }

        private void Motion(Vector2 direction)
        {
            this._character.GetComponent<MoveComponent>().MoveByRigidbodyVelocity(direction * Time.fixedDeltaTime);
        }

        public void Fire()
        {
            if (this._fireRequired)
            {

                WeaponComponent weapon = this._character.GetComponent<WeaponComponent>();
                _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
                {
                    isPlayer = true,
                    physicsLayer = (int)this._bulletPlayerConfig.PhysicsLayer,
                    color = this._bulletPlayerConfig.Color,
                    damage = this._bulletPlayerConfig.Damage,
                    position = weapon.Position,
                    velocity = weapon.Rotation * Vector3.up * this._bulletPlayerConfig.Speed
                });

                this._fireRequired = false;
            }
        }

        private void OnDestroy()
        {
            _input.OnMove -= Motion;
        }
    }
}