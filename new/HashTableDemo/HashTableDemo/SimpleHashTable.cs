using System;
using System.Collections.Generic;
using System.Collections;

namespace HashTableDemo
{
    class SimpleHashTable//<TKey, TValue>: IDictionary<TKey, TValue>
    {
        private int _hashSize;
        private string[] _hashWords;

        IEqualityComparer<string> _comparer = null;

        object o;


        public SimpleHashTable()
        {

        }


        public SimpleHashTable(IEqualityComparer<string> comparer)
        {
            _comparer = comparer;
        }

        public SimpleHashTable()
        {
            _hashSize = char.MaxValue;
            _hashWords = new string[_hashSize];
        }

        public void AddWordsToHashTable(string str)
        {
            string[] words = str.Split(' ', ',');

            foreach (string w in words)
            {
                if (w != "")
                {
                    _hashWords[HashFunc(w)] = w;   /// Add
                }
            }
        }

        public bool IsWordExistsInHashTable(string key)
        {
            return (_hashWords[HashFunc(key)] != null);
        }

        private int HashFunc(string s)
        {
            if (_comparer != null)
            {
                return _comparer.GetHashCode(s);
            }

            return (s[0] + s[1]) % _hashSize;
        }
    }
}
