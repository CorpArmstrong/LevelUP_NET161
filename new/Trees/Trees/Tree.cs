using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Trees
{
    class Tree<TKey, TValue> : IDictionary<TKey, TValue>
        where TKey : IComparable<TKey>
 //       where TValue : IComparable<TValue>
    {
        public Tree()
        {
        }

        private void AddByIteration(TKey key, TValue value)
        {
            if (_root == null)    // тривиальный случай
            {
                _root = new Node(key, value);
                return;
            }

            Node currentNode = _root;
            bool isNodeAdded = false;

            while (!isNodeAdded)
            {
                if (key.CompareTo(currentNode.Key) < 0)
                {
                    if (currentNode._left == null)
                    {
                        currentNode._left = new Node(key, value);
                        isNodeAdded = true;
                    }
                    else
                    {
                        currentNode = currentNode._left;
                    }
                }
                else
                {
                    if (currentNode._right == null)
                    {
                        currentNode._right = new Node(key, value);
                        isNodeAdded = true;
                    }
                    else
                    {
                        currentNode = currentNode._right;
                    }
                }
            }
        }

        private static void Add(ref Node root, TKey key, TValue value)
        {
            if (root == null)    // тривиальный случай
            {
                root = new Node(key, value);
                return;
            }

            if (key.CompareTo(root.Key) < 0)
            {
                Add(ref root._left, key, value);
            }
            else
            {
                Add(ref root._right, key, value);
            }
        }

        public void Add(TKey key, TValue value)
        {
            //Add(ref _root, key, value);
            AddByIteration(key, value);
        }

        private TValue GetValue(ref Node root, TKey key)
        {
            Node n = GetNode(root, key);

            if (n == null)
            {
                //throw new Exception();    // TreeException <- KeyNotFoundTreeException
            }

            return n.Value;

            //if (key.CompareTo(root.Key) == 0)
            //{
            //    Console.WriteLine("Obtained value: {0}, key: {1}", root.Value, root.Key);
            //    return root.Value;
            //}

            //if (key.CompareTo(root.Key) < 0)
            //{
            //    return GetValue(ref root._left, key);
            //}
            //else
            //{
            //    return GetValue(ref root._right, key);
            //}
        }

        private Node GetNode(Node root, TKey key)
        {
            if (root == null)
            {
                return null;
               // return new Node(key, default(TValue));
            }

            if (key.CompareTo(root.Key) == 0)
            {
                return root;
            }

            if (key.CompareTo(root.Key) < 0)
            {
                return GetNode(root._left, key);
            }
            else
            {
                return GetNode(root._right, key);
            }
        }

        private static void IncrementItem(Node root, ref int counter)
        {
            if (root == null)     // тривиальный случай
            {
                return;
            }

            IncrementItem(root._left, ref counter);
            counter++;
            IncrementItem(root._right, ref counter);
        }

        private int GetNodesCount()
        {
            int counter = 0;
            IncrementItem(_root, ref counter);
            return counter;
        }

        private static void Remove(ref Node root, TKey key)
        {
            if (key.CompareTo(root.Key) == 0)
            {
                root.Deleted = true;
                Console.WriteLine("Deleted key: {0}, value was: {1}", root.Key, root.Value);
                return;
            }

            if (key.CompareTo(root.Key) < 0)
            {
                Remove(ref root._left, key);
            }
            else
            {
                Remove(ref root._right, key);
            }
        }

        public void RemoveKey(TKey key)
        {
            if (_root == null)
            {
                // !!! TODO: sfdgvndrjlfvn
                throw new ApplicationException("Can't remove item from an empty tree!");
            }

            Remove(ref _root, key);
        }

        public TValue GetAt(TKey key)
        {
            if (_root == null)
            {
                throw new ApplicationException("Can't get value from an empty tree!");
            }

            return GetValue(ref _root, key);
        }

        private static void PrintToConsole(Node root, string offset = "")
        {
            if (root == null)    // тривиальный случай
            {
                return;
            }

            PrintToConsole(root._left, offset + "\t");
            Console.WriteLine("{0}[{1}] = {2}", offset, root.Key, root.Value);
            PrintToConsole(root._right, offset + "\t");
        }

        public void PrintToConsole()
        {
            PrintToConsole(_root);
        }

        private static void TreeAsString(Node root, ref StringBuilder builder, string offset = "")
        {
            if (root == null)     // тривиальный случай
            {
                return;
            }

            TreeAsString(root._left, ref builder, offset + "\t");
            builder.AppendLine(string.Format("{0}[{1}] = {2}, deleted? = {3}", offset, root.Key, root.Value, root.Deleted));
            TreeAsString(root._right, ref builder, offset + "\t");
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Binary Tree:");
            TreeAsString(_root, ref builder);
            return builder.ToString();
        }

        #region IDictionary

        public bool ContainsKey(TKey key)
        {
            return GetNode(_root, key) != null;
        }

        public bool Remove(TKey key)
        {
            RemoveKey(key);
            return true;
        }

        // Needs to rewrite!
        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);

            Node n = GetNode(_root, key);

            if (n != null)
            {
                value = n.Value;
            }

            //value = GetValue(ref _root, key);
            //bool isNodePresent = (value.CompareTo(default(TValue)) != 0);

            return n != null;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            _root = null;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ContainsKey(item.Key);

            //bool contains = false;
            //Node nodeToFind = GetNode(_root, item.Key);

            //if (nodeToFind != null)
            //{
            //    if (nodeToFind.Value.CompareTo(item.Value) == 0)
            //    {
            //        contains = true;
            //    }
            //}

            //return contains;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            foreach (KeyValuePair<TKey, TValue> item in this)
            {
                array[arrayIndex++] = item;
            }

          //  throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            RemoveKey(item.Key);
            return true;
        }

        private static IEnumerable<KeyValuePair<TKey, TValue>> ToKeysEnumerator(Node root)
        {
            if (root == null)     // тривиальный случай
            {
                yield break;
            }

            foreach (KeyValuePair<TKey, TValue> item in ToKeysEnumerator(root._left))
            {
                yield return item;
            }
            
            yield return new KeyValuePair<TKey,TValue>(root.Key, root.Value);
            
            foreach (KeyValuePair<TKey, TValue> item in ToKeysEnumerator(root._right))
            {
                yield return item;
            }
        }

        private static void GetKeys(Node root, ICollection<TKey> keys)
        {
            if (root == null)     // тривиальный случай
            {
                return;
            }

            GetKeys(root._left, keys);
            keys.Add(root.Key);
            GetKeys(root._right, keys);
        }
        
        private static void GetValues(Node root, ICollection<TValue> values)
        {
            if (root == null)     // тривиальный случай
            {
                return;
            }

            GetValues(root._left, values);
            values.Add(root.Value);
            GetValues(root._right, values);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return ToKeysEnumerator(_root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public ICollection<TKey> Keys
        {
            get
            {
                List<TKey> keys = new List<TKey>();
                GetKeys(_root, keys);
                return keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                List<TValue> values = new List<TValue>();
                GetValues(_root, values);
                return values;
            }
        }

        public int Count
        {
            get
            {
                return GetNodesCount();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                return GetAt(key);
            }
            set
            {
                GetNode(_root, key).Value = value;
            }
        }

        #endregion

        Node _root = null;    // ссылка на корневой узел дерева

        protected class Node
        {
            public Node(TKey key, TValue value)
            {
                Key = key;
                Value = value;
                _left = null;
                _right = null;

                Deleted = false;
            }

            public TKey Key { get; set; }
            public TValue Value { get; set; }

            public bool Deleted { get; set; }

            //public Node Left { get; set; }
            public Node _left;
            public Node _right;
        }
    }
}
