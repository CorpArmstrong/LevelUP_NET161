using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using CollectionsTutorial.LightweightCollections.Generic.Exceptions;

namespace CollectionsTutorial.LightweightCollections.Generic.LinkedList
{
    public class SingleLinkedList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        // <summary>
        /// Checks whether or not list is empty.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _first == null;
        }

        /// <summary>
        /// Simply adds new element in front of the list.
        /// </summary>
        /// <param name="d"></param>
        public void AddToBegin(T d)
        {
            Node<T> newElem = new Node<T>(d);
            newElem.Next = _first;
            _first = newElem;
        }

        /// <summary>
        /// Simply adds new element to the end of the list.
        /// </summary>
        /// <param name="d"></param>
        public void AddToEnd(T d)
        {
            Node<T> newElem = new Node<T>(d);

            if (!IsEmpty())
            {
                Node<T> currentElem = _first;
                while (currentElem.Next != null)
                {
                    currentElem = currentElem.Next;
                }

                currentElem.Next = newElem;
            }
            else
            {
                _first = newElem;
            }
        }

        /// <summary>
        /// Exctracts item value from begin.
        /// </summary>
        /// <returns></returns>
        public T ExtractFromBegin()
        {
            T retValue = default(T);

            if (IsEmpty())
            {
                throw new EmptyListException("Can't extract item from an empty list!");
            }

            retValue = _first.Data;
            _first = _first.Next;

            return retValue;
        }

        /// <summary>
        /// Extracts item value from the end.
        /// </summary>
        /// <returns></returns>
        public T ExtractFromEnd()
        {
            return ExtractByPosition(GetSize() - 1);;
        }

        public T ExtractByPosition(int position)
        {
            T retValue = default(T);
            Node<T> np = GetElementByPosition(position - 1).Next;

            if (position < GetSize() - 1)
            {
                Node<T> npNext = np.Next;
                Node<T> npNextNext = npNext.Next;

                np.Next = npNextNext;
                retValue = np.Data;
            }
            else
            {
                np = null;
            }

            return retValue;
        }

        public T ExtractElementByValue(T value)
        {
            if (IsEmpty())
            {
                throw new EmptyListException("Can't extract item from an empty list!");
            }

            Node<T> currElem = _first;
            T resultValue = default(T);

            while (currElem.Next != null && (value.CompareTo(currElem.Next.Data) != 0))
            {
                currElem = currElem.Next;
            }

            if (currElem.Next != null)
            {
                resultValue = currElem.Next.Data;
                currElem.Next = currElem.Next.Next;
            }

            return resultValue;
        }

        public bool RemoveByValue(T val)
        {
            if (IsEmpty())
            {
                throw new EmptyListException("Can't remove item from an empty list!");
            }

            if (val.CompareTo(_first.Data) == 0)
            {
                ExtractFromBegin();
                return true;
            }

            Node<T> currElem = _first;

            while (currElem.Next != null && (val.CompareTo(currElem.Next.Data) != 0))
            {
                currElem = currElem.Next;
            }

            if (currElem.Next != null)
            {
                currElem.Next = currElem.Next.Next;
            }

            return false;
        }

        public bool Contains(T value)
        {
            if (IsEmpty())
            {
                throw new EmptyListException("Can't search through an empty list!");
            }

            return Find(value) != null;
        }

        private Node<T> Find(T value)
        {
            Node<T> resultNode = null;

            if (value != null)
            {
                Node<T> currentNode = _first;

                while (currentNode.Next != null)
                {
                    if (value.CompareTo(currentNode.Data) == 0)
                    {
                        resultNode = currentNode;
                        break;
                    }

                    currentNode = currentNode.Next;
                }
            }

            return resultNode;
        }

        public T GetValueByPosition(int position)
        {
            return GetElementByPosition(position).Data;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (T item in this)
            {
                builder.Append(item.ToString() + "\t");
            }
            return builder.ToString();
        }

        public string PrintList()
        {
            Node<T> currentElem = _first;
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Begin of the list:");
            while (currentElem != null)
            {
                builder.AppendLine(currentElem.Data.ToString());
                currentElem = currentElem.Next;
            }
            builder.AppendLine("End of the list;");

            return builder.ToString();
        }

        public int GetSize()
        {
            int size = 0;

            if (!IsEmpty())
            {
                Node<T> currentElem = _first;
                size = 1;

                while (currentElem.Next != null)
                {
                    currentElem = currentElem.Next;
                    ++size;
                }
            }

            return size;
        }

        private Node<T> GetElementByPosition(int position)
        {
            Node<T> retValue = null;
            int arrSize = GetSize();

            if (IsEmpty())
            {
                throw new EmptyListException("Can't get item from an empty list!");
            }

            if (position >= 0 && position < arrSize)
            {
                Node<T> currentElem = _first;
                int pos = 0;

                if (pos == position)
                {
                    retValue = currentElem;
                }
                else
                {
                    while (currentElem.Next != null)
                    {
                        ++pos;

                        if (pos == position)
                        {
                            retValue = currentElem.Next;
                            break;
                        }

                        currentElem = currentElem.Next;
                    }
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            return retValue;
        }

        protected Node<T> _first = null;

        protected class Node<U>
        {
            public Node(U data)
            {
                _data = data;
                _next = null;
            }

            public U Data
            {
                get { return _data; }
                set { _data = value; }
            }

            public Node<U> Next
            {
                get { return _next; }
                set { _next = value; }
            }

            private U _data;
            private Node<U> _next;
        }

        protected class NodeIterator<T> : IEnumerator<T>
        {
            public NodeIterator(Node<T> first)
            {
                _first = first;
            }

            public T Current
            {
                get
                {
                    return _currentElement.Data;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return _currentElement.Data;
                }
            }

            public void Dispose() { }

            public bool MoveNext()
            {                
                if (_firsted)
                {
                    _firsted = false;
                }
                else
                {
                    _currentElement = _currentElement.Next;
                }

                return _currentElement != null;
            }

            public void Reset()
            {
                _firsted = true;
                _currentElement = _first;
            }

            bool _firsted = true;

            Node<T> _currentElement = null;
            Node<T> _first = null;
        }

        #region IEnumerator

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new NodeIterator<T>(_first);
        }

        #endregion
    }
}
