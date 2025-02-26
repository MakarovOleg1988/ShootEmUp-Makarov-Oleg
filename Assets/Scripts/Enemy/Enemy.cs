namespace ShootEmUp
{
    public class Enemy : Unit, IFixedUpdateable
    {
        protected EnemyAttackAgent _enemyAttackAgent;

       private void Start()
        {
            GameInstaller gameInstaller = ServiceLocator.GetService<GameInstaller>();
            gameInstaller.RegisterNewIFixedUpdateable(this.gameObject.GetComponent<IFixedUpdateable>());         
        }

        public virtual void CustomFixedUpdate()
        {
    
        }
    }
}