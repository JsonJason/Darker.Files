using System;

namespace Darker.Persistance
{
    public interface Future
    {
        void OnSuccess(Action action);
        void OnError(Action<Exception> action);
    }

    public interface Future<out T>
    {
        void OnSuccess(Action<T> action);
        void OnError(Action<Exception> action);
    }
}