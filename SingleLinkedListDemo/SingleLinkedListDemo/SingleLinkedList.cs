using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedListDemo
{
    public class SingleLinkedList<T> : IEnumerable, IEnumerator
    {
        public bool IsEmpty()
        {
            return _first == null;
        }

        public void AddToBegin(int d)
        {
            Node newElem = new Node(d);

            newElem.Next = _first;
            _first = newElem;
        }
        public void AddToEnd(int d)
        {
            Node newElem = new Node(d);

            if (_first != null)
            {
                Node currentElem = _first;
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

        public int GetFromBegin()
        {
            int retValue = 0;

            if (_first == null)
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

        public bool RemoveByValue(int val)
        {
            if (_first == null)
            {
                // Обработка нештатной ситуации (throw Exception())
            }

            if (_first.Data == val)
            {
                GetFromBegin();
                return true;
            }

            Node currElem = _first;
            while (currElem.Next != null && currElem.Next.Data != val)
            {
                currElem = currElem.Next;
            }
            if (currElem.Next != null)
            {
                currElem.Next = currElem.Next.Next;
            }

            return false;
        }

        public int? ExtractByPosition(int position)
        //public int ExtractByPosition(int position)
        {
            int? retValue = null;
            //int retValue = 0;
            Node np = GetElementByPosition(position - 1).Next;

            if (position < GetSize()-1)
            {
                
                Node npNext = np.Next;
                Node npNextNext = npNext.Next;

                np.Next = npNextNext;
                //Node npNext = GetElementByPosition(position).Next;
                retValue = np.Data;
                //GetElementByPosition(position - 1).Next = GetElementByPosition(position).Next;
            }
            else
            {
                np = null;
            }
            

            return retValue;
        }

        public int? ExtractFromEnd()
        {
            int? retValue = ExtractByPosition(GetSize()-1);

            //if (IsEmpty())
            //{
            //    return -1;
            //    // throw
            //}

            //if (_first.Next != null)
            //{
            //    Node currentElem = _first;
            //    while (currentElem.Next.Next != null)
            //    {
            //        currentElem = currentElem.Next;
            //    }

            //    retValue = currentElem.Next.Data;
            //    currentElem.Next = null;
            //}
            //else
            //{
            //    retValue = _first.Data;
            //    _first = null;
            //}


            return retValue;
        }

        private Node GetElementByPosition(int position)
        {
            Node retValue = null;

            if (position >= 0 && position < GetSize())
            {
                if (!IsEmpty())
                {
                    Node currentElem = _first;
                    int pos = 0;

                    if (pos == position)
                    {
                        retValue = currentElem;
                    }
                    else
                    {
                        while (currentElem.Next != null)
                        {
                            if (pos == position)
                            {
                                retValue = currentElem.Next;
                            }
                            ++pos;
                        }
                    }
                }
            }

            return retValue;
        }

        public int GetValueByPosition(int position)
        {
            return GetElementByPosition(position).Data;
        }

        public IEnumerator GetEnumerator()
        {
            ((IEnumerator)this).Reset();
            return this;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            //for (int i = 0; i < GetSize(); i++ )
            //{
            //    builder.Append(GetValueByPosition(i).ToString() + "\t");
            //}

            foreach (int item in this)
            {
                builder.Append(item.ToString() + "\t");
            }
            return builder.ToString();
        }

        public void PrintToConsole()
        {
            Node currentElem = _first;   //  !!! _first нельзя изменять

            while (currentElem != null)
            {
                Console.Write(currentElem.Data + "\t");
                currentElem = currentElem.Next;
            }
        }

        public int GetSize()
        {
            int size = 0;

            if (!IsEmpty())
            {
                Node currentElem = _first;
                size = 1;

                while (currentElem.Next != null)
                {
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



        private Node _first = null;    // ссылка на 1-й элемент в списке
        private Node _current = null;
        private bool _isFirst = true;

        // Элемент списка
        private class Node
        {
            public Node(int data)
            {
                _data = data;
                _next = null;
            }

            public int Data
            {
                get
                {
                    return _data;
                }
                set
                {
                    _data = value;
                }
            }

            public Node Next
            {
                get
                {
                    return _next;
                }
                set
                {
                    _next = value;
                }
            }

            private int _data;
            private Node _next;
        }

        
    }
}
