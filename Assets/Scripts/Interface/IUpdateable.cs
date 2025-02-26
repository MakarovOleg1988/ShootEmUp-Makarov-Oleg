namespace ShootEmUp
{
    public interface IUpdateable
    {
        void CustomUpdate();
    }

    public interface IFixedUpdateable
    {
        void CustomFixedUpdate();
    }
}