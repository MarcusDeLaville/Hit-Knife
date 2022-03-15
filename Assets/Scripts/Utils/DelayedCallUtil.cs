using System;
using System.Threading.Tasks;

namespace Utils
{
    public static class DelayedCallUtil
    {
        public static async void DelayedCall(float delay, Action action, bool ignoreTimeScale = false)
        {
            await Task.Delay(TimeSpan.FromSeconds(delay));

            action?.Invoke();
        }
    }
}