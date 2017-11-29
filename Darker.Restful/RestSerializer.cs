namespace Darker.Restful
{
    public interface RestSerializer
    {
        dynamic DeSerialize(Response resp);
        string Serialize(object o);
    }
}