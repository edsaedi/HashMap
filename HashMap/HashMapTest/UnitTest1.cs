using System;
using Xunit;
using HashMap;

namespace HashMapTest
{
    public class UnitTest1<TKey, TValue>
    {
        Random rand = new Random(26);
        [Fact]
        public void Add()
        {

        }

        public void CreateHashMap(int capacity)
        {
            HashMap<TKey, TValue> hashMap = new HashMap<TKey, TValue>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                hashMap.Add(array[i]);
            }
        }
    }
}
