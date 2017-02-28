using System;

namespace CollectionsTutorial.LightweightCollections.Generic.Exceptions
{
    class EmptyListException : ApplicationException
    {
        public EmptyListException() { }
        public EmptyListException(string message) : base(message) { }
        public EmptyListException(string message, Exception ex) : base(message) { }
        protected EmptyListException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext contex)
            : base(info, contex) { }
    }
}
