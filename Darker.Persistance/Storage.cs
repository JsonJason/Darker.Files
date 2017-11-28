namespace Darker.Persistance
{
    public interface Storage
    {
        void Save<T>(T item);

        T Load<T>();
    }
}