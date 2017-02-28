using System;
using System.Text;
using System.Collections;
using CollectionsTutorial.LightweightCollections.Generic.Exceptions;

namespace CollectionsTutorial.LightweightCollections.Generic.LinkedList
{
    public class DoublyLinkedList<T> : IEnumerable, IEnumerator
    {
        /// <summary>
        /// Simply adds item after given position in list
        /// </summary>
        /// <param name="position">Integer param</param>
        /// <param name="item">Generic param</param>
        /// <returns>True, if operation is successfull, otherwise return False.</returns>
        public bool AddAfter(int position, T item)
        {
            bool result = false;
            DoubleNode<T> queryNode = GetElementByPosition(position);

            if (queryNode != null)
            {
                // If it's not the last element in list
                if (queryNode.Next != null)
                {
                    DoubleNode<T> newNode = new DoubleNode<T>(item);
                    DoubleNode<T> queryNodeNext = queryNode.Next;

                    queryNode.Next = newNode;
                    newNode.Previous = queryNode;
                    newNode.Next = queryNodeNext;
                    queryNodeNext.Previous = newNode;

                    result = true;
                }
                else
                {
                    AddToEnd(item);
                }
            }

            return result;
        }

        /// <summary>
        /// Simply adds item before given position in list
        /// </summary>
        /// <param name="position">Integer param</param>
        /// <param name="item">Generic param</param>
        /// <returns>True, if operation is successfull, otherwise return False.</returns>
        public bool AddBefore(int position, T item)
        {
            bool result = false;
            DoubleNode<T> queryNode = GetElementByPosition(position);

            if (queryNode != null)
            {
                // If it's not the first element in list
                if (queryNode.Previous != null)
                {
                    DoubleNode<T> newNode = new DoubleNode<T>(item);
                    DoubleNode<T> queryNodePrevious = queryNode.Previous;

                    queryNodePrevious.Next = newNode;
                    newNode.Previous = queryNodePrevious;
                    newNode.Next = queryNode;
                    queryNode.Previous = newNode;

                    result = true;
                }
                else
                {
                    AddToBegin(item);
                }
            }

            return result;
        }

        /// <summary>
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
        /// <param name="d">Generic param</param>
        public void AddToBegin(T d)
        {
            DoubleNode<T> newElem = new DoubleNode<T>(d);

            newElem.Next = _first;

            if (_first != null)
            {
                _first.Previous = newElem;
            }

            _first = newElem;
        }

        /// <summary>
        /// Simply adds new element to the end of the list.
        /// </summary>
        /// <param name="d">Generic param</param>
        public void AddToEnd(T d)
        {
            DoubleNode<T> newElem = new DoubleNode<T>(d);

            if (!IsEmpty())
            {
                DoubleNode<T> currentElem = _first;
                while (currentElem.Next != null)
                {
                    currentElem = currentElem.Next;
                }

                currentElem.Next = newElem;
                newElem.Previous = currentElem;
            }
            else
            {
                _first = newElem;
            }
        }

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

        public T ExtractFromEnd()
        {
            T retValue = ExtractByPosition(GetSize() - 1);
            return retValue;
        }

        public T ExtractByPosition(int position)
        {
            T retValue = default(T);
            DoubleNode<T> queryElement = GetElementByPosition(position - 1).Next;

            if (position < GetSize() - 1)
            {
                DoubleNode<T> queryElementNext = queryElement.Next;
                DoubleNode<T> queryElementNextNext = queryElementNext.Next;

                queryElement.Next = queryElementNextNext;
                retValue = queryElement.Data;
            }
            else
            {
                queryElement = null;
            }

            return retValue;
        }

        public bool RemoveByValue(T val)
        {
            if (IsEmpty())
            {
                throw new EmptyListException("Can't remove item from an empty list!");
            }

            if (IsEqual(_first.Data, val))
            {
                ExtractFromBegin();
                return true;
            }

            DoubleNode<T> currElem = _first;

            while (currElem.Next != null && !IsEqual(currElem.Next.Data, val))
            {
                currElem = currElem.Next;
            }

            if (currElem.Next != null)
            {
                currElem.Next = currElem.Next.Next;
            }

            return false;
        }

        public T GetValueByPosition(int position)
        {
            return GetElementByPosition(position).Data;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (int item in this)
            {
                builder.Append(item.ToString() + "\t");
            }
            return builder.ToString();
        }

        /// <summary>
        /// Print the entire list.
        /// </summary>
        /// <returns></returns>
        public string PrintList()
        {
            DoubleNode<T> currentElem = _first;
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

        /// <summary>
        /// Gets list size.
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            int size = 0;

            if (!IsEmpty())
            {
                DoubleNode<T> currentElem = _first;
                size = 1;

                while (currentElem.Next != null)
                {
                    currentElem = currentElem.Next;
                    ++size;
                }
            }

            return size;
        }

        #region Реализация явная интерфейса итератора для односвязного списка

        object IEnumerator.Current
        {
            get
            {
                return _current.Data;
            }
        }

        bool IEnumerator.MoveNext()
        {
            if (_isFirst)
            {
                _isFirst = false;
            }
            else
            {
                _current = _current.Next;
            }

            return (_current != null);
        }

        void IEnumerator.Reset()
        {
            _current = _first;
            _isFirst = true;
        }

        #endregion

        public IEnumerator GetEnumerator()
        {
            ((IEnumerator)this).Reset();
            return this;
        }

        private bool IsEqual<V>(V x, V y)
        {
            return x.Equals(y);
        }

        private DoubleNode<T> GetElementByPosition(int position)
        {
            DoubleNode<T> retValue = null;
            int arrSize = GetSize();

            if (IsEmpty())
            {
                throw new EmptyListException("Can't get item from an empty list!");
            }

            if (position >= 0 && position < arrSize)
            {
                DoubleNode<T> currentElem = _first;
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

        protected DoubleNode<T> _first = null;    // ссылка на 1-й элемент в списке
        protected DoubleNode<T> _current = null;
        protected bool _isFirst = true;

        // Элемент списка
        protected class DoubleNode<U>
        {
            public DoubleNode(U data)
            {
                _data = data;
                _next = null;
            }

            public U Data
            {
                get { return _data; }
                set { _data = value; }
            }

            public DoubleNode<U> Previous
            {
                get { return _previous; }
                set { _previous = value; }
            }

            public DoubleNode<U> Next
            {
                get { return _next; }
                set { _next = value; }
            }

            private U _data;
            private DoubleNode<U> _previous;
            private DoubleNode<U> _next;
        }
    }
}
