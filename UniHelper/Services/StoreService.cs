using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    /// <summary>
    /// Store Service
    /// </summary>
    public class StoreService : IStoreService
    {
        private readonly ILocalStorageService _localStorageService;
        private Dictionary<string, object> Store { get; set; }

        /// <summary>
        /// Store data has been changed
        /// </summary>
        public event EventHandler Changed;

        /// <summary>
        /// 
        /// </summary>
        public StoreService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
            Store = new Dictionary<string, object>();
        }

        /// <summary>
        /// Init Store Service
        /// </summary>
        /// <returns>Task</returns>
        public async Task Init()
        {
            var user = await _localStorageService.GetItemAsync<StorageUser>("user");

            if (user != null)
            {
                Add("user", user);
            }
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
            OnChanged();
        }

        /// <inheritdoc />
        public void Remove(string key)
        {
            Store.Remove(key);
            OnChanged();
        }

        /// <summary>
        /// On Change event
        /// </summary>
        protected virtual void OnChanged()
        {
            Changed?.Invoke(this, EventArgs.Empty);
        }
    }
}