namespace Darker.UI
{
    public interface App
    {
        void Start();
    }

    public interface AppFactory
    {
        App Create();
    }

}