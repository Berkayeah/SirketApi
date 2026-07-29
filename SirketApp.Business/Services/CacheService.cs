using System;
using Microsoft.Extensions.Caching.Memory;
using SirketApp.Business.Interfaces;

namespace SirketApp.Business.Services
{
	public class CacheService : ICacheService
	{
		private readonly IMemoryCache _memoryCache;

		public CacheService(IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
		}

		public T? Get<T>(string key)
		{
			return _memoryCache.TryGetValue(key, out T? value) ? value: default;
		}

		public void Add(string key, object data, int durationInMinutes)
		{
			var options = new MemoryCacheEntryOptions
			{
				AbsoluteExpiration = DateTime.Now.AddMinutes(durationInMinutes)
			};

            _memoryCache.Set(key, data, options);

        }

        public bool IsAdd(string key)
		{
			return _memoryCache.TryGetValue(key, out _);
		}

		public void Remove(string key)
		{
			_memoryCache.Remove(key);
		}
	}
}

