using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class Tree<TKey, TValue> //: IDictionary<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        public Tree()
        {

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
            Add(ref _root, key, value);
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
