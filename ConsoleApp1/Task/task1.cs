using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp.Task
{
    public class MyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private List<TKey> keys = new List<TKey>();
        private List<TValue> values = new List<TValue>();

        public void Add(TKey key, TValue value)
        {
            if (keys.Contains(key))
                throw new ArgumentException("Ключ уже існує.");
            keys.Add(key);
            values.Add(value);
        }

        public bool ContainsKey(TKey key)
        {
            return keys.Contains(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int index = keys.IndexOf(key);
            if (index != -1)
            {
                value = values[index];
                return true;
            }

            value = default;
            return false;
        }

        public ICollection<TKey> Keys => keys.AsReadOnly();
        public ICollection<TValue> Values => values.AsReadOnly();

        public TValue this[TKey key]
        {
            get
            {
                int index = keys.IndexOf(key);
                if (index == -1)
                    throw new KeyNotFoundException("Ключ не знайдено.");
                return values[index];
            }
            set
            {
                int index = keys.IndexOf(key);
                if (index != -1)
                    values[index] = value;
                else
                    Add(key, value);
            }
        }

        public int Count => keys.Count;

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < keys.Count; i++)
            {
                yield return new KeyValuePair<TKey, TValue>(keys[i], values[i]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class task1
    {
        public void Run()
        {
            var myDict = new MyDictionary<int, string>();
            myDict.Add(1, "Один");
            myDict.Add(2, "Два");
            myDict.Add(3, "Три");

            Console.WriteLine("Перебір через foreach:");
            foreach (var pair in myDict)
            {
                Console.WriteLine($"Ключ: {pair.Key}, Значення: {pair.Value}");
            }

            Console.WriteLine($"\nЗначення за ключем 2: {myDict[2]}");

            if (myDict.TryGetValue(3, out var val))
            {
                Console.WriteLine($"TryGetValue успішно: {val}");
            }

            Console.WriteLine($"Кількість елементів: {myDict.Count}");
            Console.WriteLine("Ключі: " + string.Join(", ", myDict.Keys));
            Console.WriteLine("Значення: " + string.Join(", ", myDict.Values));
        }
    }
}
