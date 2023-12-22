using System;
using System.Collections.Generic;

namespace Laverna_Test_1
{
    class MyCache<TKey, TValue> // Кэш, для того чтобы хранить ранее полученные запросы 
        where TKey : class
        where TValue : class
    {
        class Entry
        {
            public TValue Value { get; set; }
            public DateTime CreationTime { get; set; }
        }

        private Dictionary<TKey, Entry> _cacheDictionary; // Словарь для хранения кэша
        private TimeSpan _lifeTime; // Время жизни записи в словаре
        public MyCache(TimeSpan lifeTime)
        {
            _cacheDictionary = new Dictionary<TKey, Entry>();
            _lifeTime = lifeTime;
        }

        public bool TryGetValue(TKey key, out TValue value) // Метод проверки наличия записи в кэше
        {
            if (!_cacheDictionary.TryGetValue(key, out var entry))
            {
                value = null;
                return false;
            }
            var currentTime = DateTime.UtcNow;
            var passedTime = entry.CreationTime - currentTime;

            if (passedTime > _lifeTime)
            {
                _cacheDictionary.Remove(key);
                value = null;

                return false;
            }

            value = entry.Value;
            return true;
        }
        public void AddValue(TKey key, TValue value) // Метод добавления записи в кэш
        {
            if (_cacheDictionary.ContainsKey(key))
            {
                _cacheDictionary.Remove(key);

                var newEntry = new Entry { Value = value, CreationTime = DateTime.UtcNow };
                _cacheDictionary.Add(key, newEntry);
            }
        }
    }
}
