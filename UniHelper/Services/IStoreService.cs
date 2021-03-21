namespace UniHelper.Services
{
    /// <summary>
    /// Store Service
    /// </summary>
    public interface IStoreService
    {
        /// <summary>
        /// Get value from Store
        /// </summary>
        /// <param name="key">Key word</param>
        /// <typeparam name="T">Type of value</typeparam>
        /// <returns>Store value</returns>
        T Get<T>(string key);

        /// <summary>
        /// Value is exists with the given key
        /// </summary>
        /// <param name="key">Key word</param>
        /// <returns>True if exists value with the given key</returns>
        bool IsExists(string key);

        /// <summary>
        /// Add value
        /// </summary>
        /// <param name="key">Key word</param>
        /// <param name="value">Value</param>
        /// <typeparam name="T">Type of value</typeparam>
        void Add<T>(string key, T value);

        /// <summary>
        /// Remove value
        /// </summary>
        /// <param name="key">Key word</param>
        void Remove(string key);
    }
}