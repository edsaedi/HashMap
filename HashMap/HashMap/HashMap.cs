using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashMap
{
    public class HashMap<T, U> : IDictionary<T, U>, ICollection<KeyValuePair<T, U>>, IEnumerable<KeyValuePair<T, U>>, IEnumerable
    {
        public LinkedList<KeyValuePair<T, U>>[] collection;

        public U this[T key]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public ICollection<T> Keys => this.Select(pair => pair.Key).ToList();

        public ICollection<U> Values => this.Select(pair => pair.Value).ToList();

        public int Count => collection.Length;

        public bool IsReadOnly => false;

        public void Add(T key, U value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<T, U> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<T, U> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(T key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<T, U>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<T, U>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<T, U> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(T key, out U value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
