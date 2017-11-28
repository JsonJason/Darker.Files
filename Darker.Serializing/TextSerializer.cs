namespace Darker.Serializing
{
    public interface TextSerializer
    {
        T Deserialize<T>(string text);
        string Serialize<T>(T item);
    }
}