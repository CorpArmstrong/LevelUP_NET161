using System.Collections;

namespace SingleLinkedListDemo
{
    public class LinkedListIterator<T> : IEnumerator
    {
        public LinkedListIterator(SingleLinkedList<T> list)
        {
            _myList = list;
        }

        public object Current
        {
            get
            {
                return null;
            }
        }

        public bool MoveNext()
        {
            bool isNext = false;

            if (_position < _myList.GetSize())
            {
                ++_position;
                isNext = true;
            } 

            return isNext;
        }

        public void Reset()
        {
            _position = 0;
        }

        int _position = 0;
        SingleLinkedList<T> _myList = null;
    }
}
