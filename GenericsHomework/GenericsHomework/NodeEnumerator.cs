using System;
using System.Collections;

namespace GenericsHomework
{
    public class NodeEnumerator<T> : IEnumerator<T> where T : class
    {
        public readonly Node<T> _Collection;
        public Node<T> CurNode { get; private set; }
        public int Index { get; private set; }
        public T Current { get { return CurNode.Value; } }
        object IEnumerator.Current { get { return Current; } }

        public NodeEnumerator(Node<T> node)
        {
            _Collection = node;
            for (CurNode = node; CurNode.Next != node; CurNode = CurNode.Next) ;
            Index = 0;
        }

        /**
         * Implicitly tested in IEnumerate_Implmentation_Success
         */
        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /**
         * Implicitly tested in IEnumerate_Implmentation_Success
         */
        bool IEnumerator.MoveNext()
        {
            if (Index >= _Collection.Count)
                return false;

            CurNode = CurNode.Next;
            Index += 1;
            return true;
        }

       /**
        * Implicitly tested in IEnumerate_Implmentation_Success
        */
        void IEnumerator.Reset()
        {
            CurNode = _Collection;
            Index = 0;
        }
    }
}