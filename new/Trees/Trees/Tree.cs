using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Trees
{
    class Tree<TKey, TValue> : IDictionary<TKey, TValue>
        where TKey : IComparable<TKey>
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
            builder.AppendLine(string.Format("{0}[{1}] = {2}", offset, root.Key, root.Value));
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
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public ICollection<TKey> Keys
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
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
