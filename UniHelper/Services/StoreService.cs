using System.Collections.Generic;

namespace UniHelper.Services
{
    /// <summary>
    /// Store Service
    /// </summary>
    public class StoreService : IStoreService
    {
        private Dictionary<string, object> Store { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public StoreService()
        {
            Store = new Dictionary<string, object>();
        }

        /// <inheritdoc />
        public T Get<T>(string key)
        {
            return (T) Store.GetValueOrDefault(key);
        }

        /// <inheritdoc />
        public bool IsExists(string key)
        {
            return Store.ContainsKey(key);
        }

        /// <inheritdoc />
        public void Add<T>(string key, T value)
        {
            if (Store.ContainsKey(key))
            {
                Remove(key);
            }
            Store.Add(key, value);
        }

        /// <inheritdoc />
        public void Remove(string key)
        {
            Store.Remove(key);
        }
    }
}