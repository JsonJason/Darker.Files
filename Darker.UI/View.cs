using System;

namespace Darker.UI
{
    public interface View
    {
        void Error(Exception ex);
        void StatusUpdate(string status);

        void LoadingStart();
        void LoadingEnd();
    }
}