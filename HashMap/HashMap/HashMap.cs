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
                var pair = GetKeyValuePair(key);
                Collection[Index(key)].Remove(pair);
                Add(key, value);
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

            if (Collection[index] == null)
            {
                Collection[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }

            Collection[index].AddLast(new KeyValuePair<TKey, TValue>(key, value));

            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            if (Count > 0)
            {
                Array.Clear(Collection, 0, Count);
                Count = 0;
            }
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            var pair = GetKeyValuePair(item.Key);
            if (pair.Value.Equals(item.Value))
            {
                return true;
            }
            return false;
        }

        public bool ContainsKey(TKey key)
        {
            var pair = GetKeyValuePair(key);
            return true;
        }


        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var list in Collection)
            {
                if (list == null) continue;
                foreach (var pair in list)
                {
                    yield return pair;
                }
            }
        }

        public bool Remove(TKey key)
        {
            return Remove(GetKeyValuePair(key));
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            var index = Index(item.Key);
            foreach (var temp in Collection[index])
            {
                if (temp.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var pair = GetKeyValuePair(key);
            value = pair.Value;
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            Collection.CopyTo(array, arrayIndex);
        }

        private void ReHash(int capacity)
        {
            var temp = new LinkedList<KeyValuePair<TKey, TValue>>[capacity];
            foreach (var list in Collection)
            {
                if (list == null) continue;

                foreach (var pair in list)
                {
                    var index = Index(pair.Key, capacity);
                    if (temp[index] == null)
                    {
                        temp[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
                    }
                    temp[index].AddLast(pair);
                }
            }
        }
    }
}
