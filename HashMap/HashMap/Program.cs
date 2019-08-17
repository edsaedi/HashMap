using System;
using System.Collections.Generic;

namespace HashMap
{
    public struct MyStruct
    {
        public string Name { get; set; }
        public string ID { get; set; }

        public string FavoriteFood { get; set; }
    }

    public class MyStructComparator : IEqualityComparer<MyStruct>
    {
        public bool Equals(MyStruct x, MyStruct y)
        {
            return x.Name == y.Name && x.ID == y.ID;
        }

        public int GetHashCode(MyStruct obj)
        {
            unchecked
            {
                int hash = 13;
                hash = (hash * 7) + obj.Name.GetHashCode();
                hash = (hash * 7) + obj.ID.GetHashCode();
                return hash;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Dictionary<MyStruct, int> dict = new Dictionary<MyStruct, int>();

            dict.Add(new MyStruct()
            {
                Name = "Thad",
                ID = "42",
                FavoriteFood = "Pizza"
            }, 1);

            int x = dict[new MyStruct()
            {
                Name = "Thad",
                ID = "42",
                FavoriteFood = "Ice Cream"
            }];

            Console.WriteLine(x);

        }
    }
}
