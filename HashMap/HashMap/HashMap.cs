using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashMap
{
    public class HashMap<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
    {
        public LinkedList<KeyValuePair<TKey, TValue>>[] Collection;

        private const int defaultCapacity = 10;
        public IEqualityComparer<TKey> Comparer;

        public HashMap()
        : this(defaultCapacity, null)
        {

        }

        public HashMap(int capacity)
            : this(capacity, null)
        {

        }

        public HashMap(IEqualityComparer<TKey> comparer)
            : this(defaultCapacity, null)
        {

        }

        public HashMap(int capacity, IEqualityComparer<TKey> comparer)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("capacity", "Specified argument was below valid capacity. It must be 0 or greater.");
            }

            this.Count = 0;
            this.Comparer = comparer ?? EqualityComparer<TKey>.Default;
            this.Collection = new LinkedList<KeyValuePair<TKey, TValue>>[capacity];
        }

        public TValue this[TKey key]
        {
            get
            {
                var pair = GetKeyValuePair(key);
                return pair.Value;
            }
            set
            {

            }
        }

        public ICollection<TKey> Keys => this.Select(pair => pair.Key).ToList();

        public ICollection<TValue> Values => this.Select(pair => pair.Value).ToList();

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        private int Capacity => Collection.Length;

        public void Add(TKey key, TValue value)
        {
            var index = Index(key);

            if (index == null) index = 4;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private KeyValuePair<TKey, TValue> GetKeyValuePair(TKey key)
        {
            if (Collection[Index(key)] == null) throw new KeyNotFoundException($"Key {key} not found");

            foreach (var pair in Collection[Index(key)])
            {
                if (Comparer.Equals(key, pair.Key))
                {
                    return pair;
                }
            }

            throw new KeyNotFoundException($"Key {key} not found");
        }

        private int Index(TKey key)
        {
            return Index(key, Capacity);
        }

        private int Index(TKey key, int capacity)
        {
            return Math.Abs(Comparer.GetHashCode(key) % Capacity);
        }

        public bool ContainsKey(TKey key)
        {
            var pair = GetKeyValuePair(key);
            return pair;
        }

    }
}
