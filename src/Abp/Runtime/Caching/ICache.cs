using System;
using System.Threading.Tasks;

namespace Abp.Runtime.Caching
{
    /// <summary>
    /// Defines a cache that can be store and get items by keys.
    /// </summary>
    public interface ICache : IDisposable
    {
        /// <summary>
        /// Unique name of the cache.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Default sliding expire time of cache items.
        /// </summary>
        TimeSpan DefaultSlidingExpireTime { get; set; }

        /// <summary>
        /// Gets an item from the cache.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="factory">Factory method to create cache item if not exists</param>
        /// <returns>Cached item</returns>
        object Get(string key, Func<object> factory);

        /// <summary>
        /// Gets an item from the cache.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="factory">Factory method to create cache item if not exists</param>
        /// <returns>Cached item</returns>
        Task<object> GetAsync(string key, Func<Task<object>> factory);

        /// <summary>
        /// Gets an item from the cache or null if not found.
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Cached item or null if not found</returns>
        object GetOrDefault(string key);

        /// <summary>
        /// Gets an item from the cache or null if not found.
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Cached item or null if not found</returns>
        Task<object> GetOrDefaultAsync(string key);

        /// <summary>
        /// Saves/Overrides an item in the cache by a key.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="slidingExpireTime">Sliding expire time</param>
        void Set(string key, object value, TimeSpan? slidingExpireTime = null);

        /// <summary>
        /// Saves/Overrides an item in the cache by a key.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="slidingExpireTime">Sliding expire time</param>
        Task SetAsync(string key, object value, TimeSpan? slidingExpireTime = null);

        /// <summary>
        /// Removes a cache item by it's key.
        /// </summary>
        /// <param name="key">Key</param>
        void Remove(string key);

        /// <summary>
        /// Removes a cache item by it's key.
        /// </summary>
        /// <param name="key">Key</param>
        Task RemoveAsync(string key);

        /// <summary>
        /// Clears all items in this cache.
        /// </summary>
        void Clear();

        /// <summary>
        /// Clears all items in this cache.
        /// </summary>
        Task ClearAsync();
    }
}