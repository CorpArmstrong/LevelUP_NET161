using System.Collections;
using System.Text;

namespace CollectionsTutorial.LightweightCollections.Generic.LinkedList
{
    public class SingleLinkedList<T> : IEnumerable, IEnumerator
    {
        public bool IsEmpty()
        {
            return _first == null;
        }

        public void AddToBegin(T d)
        {
            Node<T> newElem = new Node<T>(d);
            newElem.Next = _first;
            _first = newElem;
        }

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

        public T ExtractFromBegin()
        {
            T retValue = default(T);

            if (IsEmpty())
            {
                // Обработка нештатной ситуации (throw Exception())
            }
            else
            {
                retValue = _first.Data;
                _first = _first.Next;
            }

            return retValue;
        }

        public bool RemoveByValue(T val)
        {
            if (IsEmpty())
            {
                // Обработка нештатной ситуации (throw Exception())
            }

            if (IsEqual(_first.Data, val))
            {
                ExtractFromBegin();
                return true;
            }

            Node<T> currElem = _first;

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

        public T ExtractByPosition(int position)
        {
            T retValue = default(T);
            Node<T> np = GetElementByPosition(position - 1).Next;

            if (position < Count() - 1)
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

        public T ExtractFromEnd()
        {
            T retValue = ExtractByPosition(Count() - 1);
            return retValue;
        }

        private bool IsEqual<V>(V x, V y)
        {
            return x.Equals(y);
        }

        private Node<T> GetElementByPosition(int position)
        {
            Node<T> retValue = null;
            int arrSize = Count();

            if (IsEmpty())
            {
                // throw exception EmptyContainer
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
                // throw exception OutOfBounds?
            }

            return retValue;
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
            builder.AppendLine("End of list;");

            return builder.ToString();
        }

        public int Count()
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

        private Node<T> _first = null;    // ссылка на 1-й элемент в списке
        private Node<T> _current = null;
        private bool _isFirst = true;

        // Элемент списка
        private class Node<U>
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
    }
}
