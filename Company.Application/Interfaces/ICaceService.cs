using System;
namespace Company.Application.Interfaces
{
    public interface ICacheService
    {
        T? Get<T>(string key);
        void Add(string key, object data, int durationInMinutes);
        bool IsAdd(string key);
        void Remove(string key);
    }
}

