using System;

namespace JigFlow.Data
{
    public static class DataChangeNotifier
    {
        public static event Action<string> Changed;

        public static void Notify(string ENTITY)
        {
            Changed?.Invoke(ENTITY ?? string.Empty);
        }
    }
}
