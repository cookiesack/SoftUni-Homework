using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_02___Implement_BiDictionary
{
    class BiDictionary<K1, K2, T>
    {
        private Dictionary<K1, List<T>> valuesByFirstKey;
        private Dictionary<K2, List<T>> valuesBySecondKey;
        private Dictionary<Tuple<K1, K2>, List<T>> valuesByBothKeys;

        public BiDictionary()
        {
            valuesByFirstKey = new Dictionary<K1, List<T>>();
            valuesBySecondKey = new Dictionary<K2, List<T>>();
            valuesByBothKeys = new Dictionary<Tuple<K1, K2>, List<T>>();
        }

        public void Add(K1 key1, K2 key2, T value)
        {
            if (!valuesByFirstKey.ContainsKey(key1))
            {
                valuesByFirstKey.Add(key1, new List<T>());
            }

            valuesByFirstKey[key1].Add(value);

            if (!valuesBySecondKey.ContainsKey(key2))
            {
                valuesBySecondKey.Add(key2, new List<T>());
            }

            valuesBySecondKey[key2].Add(value);

            if (!valuesByBothKeys.ContainsKey(new Tuple<K1, K2>(key1, key2)))
            {
                valuesByBothKeys.Add(new Tuple<K1, K2>(key1, key2), new List<T>());
            }

            valuesByBothKeys[new Tuple<K1, K2>(key1, key2)].Add(value);
        }

        public IEnumerable<T> Find(K1 key1, K2 key2)
        {
            if (!valuesByBothKeys.ContainsKey(new Tuple<K1, K2>(key1, key2))) return new T[0];
            return valuesByBothKeys[new Tuple<K1, K2>(key1, key2)];
        }

        public IEnumerable<T> FindByKey1(K1 key1)
        {
            if (!valuesByFirstKey.ContainsKey(key1)) return new T[0];
            return valuesByFirstKey[key1];
        }

        public IEnumerable<T> FindByKey2(K2 key2)
        {
            if (!valuesBySecondKey.ContainsKey(key2)) return new T[0];
            return valuesBySecondKey[key2];

        }

        public bool Remove(K1 key1, K2 key2)
        {
            if (!valuesByBothKeys.ContainsKey(new Tuple<K1, K2>(key1, key2)))
                return false;

            var values = valuesByBothKeys[new Tuple<K1, K2>(key1, key2)];
            foreach (var value in values)
            {
                valuesByFirstKey[key1].Remove(value);
                valuesBySecondKey[key2].Remove(value);
            }

            valuesByBothKeys.Remove(new Tuple<K1, K2>(key1, key2));

            return true;
        }
    }
}
