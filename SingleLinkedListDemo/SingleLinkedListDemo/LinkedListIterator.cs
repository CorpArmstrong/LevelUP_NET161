using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedListDemo
{
    public class LinkedListIterator : IEnumerator
    {
        public LinkedListIterator(SingleLinkedList list)
        {
            _myList = list;
        }

        public object Current
        {
            get
            {
                //return _myList.GetElementByPosition(_position);
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
        SingleLinkedList _myList = null;
    }
}
