using System;
using System.Collections;

namespace GenericsHomework
{
    public class Node<T> : ICollection<T>, IEnumerable<T> where T : class
    {
        public T Value { get; set; }
        public Node<T> Next { get; private set; }

        public int Count { get; private set; }

        public bool IsReadOnly { get; }

        public Node(T value)
        {
            Value = value;
            Next = this;
            Count = 1;
            IsReadOnly = false;
        }

        public override string ToString()
        {
            if (Value == null)
                return string.Empty;

            return Value.ToString()!;
        }

        /**
         * Append is now private as implementing ICollection requires Add (which contains the same behavior as Append). This will clean up external use of the library.
         * Append will also now be implicitly tested when testing Add.
         */
        private void Append(T value)
        {
            if (Exists(value))
                throw new ArgumentException("Value exists in list");

            Node<T> original = this;
            Node<T> cursor = this;

            while (cursor.Next != original)
                cursor = cursor.Next;

            Node<T> node = new(value);
            node.Next = cursor.Next;
            cursor.Next = node;
            Count += 1;
        }

        /**
         * Setting the next reference to the node itself is enough to clear the list. This is because the other nodes in the list are no longer referenced by anything
         * currently in the code, and thus cannot be accessed by anyone writing outside (or inside for that matter) the library. The only place for these inaccessable nodes
         * (or references to the nodes) lies with the garbage collector. Thus, assuming the garbage collector does it's job, this is very much sufficient.
         * 
         * I've also taken the time to take snapshots of memory usage in Visual Studio before and after calling Clear, and you can clearly see the extra nodes beyond the calling node
         * are infact picked up by the garbage collector in the latter snapshot.
         * 
         * The list itself will not fall to garbage collection because every node is avaliable via reference (or via chain of references) to the programmer, and thus will
         * not fall to garbage collection, UNLESS we were to lose ALL references to any nodes in the list.
         */
        public void Clear()
        {
            Next = this;
        }

        /**
         * Exists is now private as implementing ICollection requires Contains (which contains the same behavior as Exists). This will clean up external use of the library.
         * Exists will also now be implicitly tested when testing Contains.
         */
        private bool Exists(T value)
        {
            return FindIndex(value) != -1;
        }

        /**
         * FindIndex is implicitly tested by Exists and Remove.
         */
        private int FindIndex(T value)
        {
            Node<T> original = this;
            if (original.Value == value)
                return 0;

            Node<T> cursor = this.Next;
            int i = 1;

            while (cursor != original)
            {
                if (cursor.Value == value)
                {
                    return i;
                }

                cursor = cursor.Next;
                i += 1;
            }

            return -1;
        }

        public void Add(T value)
        {
            Append(value);
        }

        public bool Contains(T value)
        {
            return Exists(value);
        }

        public void CopyTo(T[] arr, int index)
        {
            if (arr == null)
                throw new ArgumentNullException($"{arr} array cannot be null");
            if (index < 0)
                throw new ArgumentOutOfRangeException($"Index cannot be negative, but {index} is negative.");
            if (arr.Length - index < Count)
                throw new ArgumentException($"{arr} array cannot be smaller than {typeof(Node<T>)} collection.");

            Node<T> cursor = this;
            for (int i = 0; i < Count; i++, cursor = cursor.Next)
                arr[index + i] = cursor.Value;
        }

        public bool Remove(T value)
        {
            int index = FindIndex(value);

            switch(index)
            {
                case -1:
                    return false;

                case 0:
                    if(Next == this)
                        throw new InvalidOperationException("Cannot remove the root node.");
                    return false;

                default:
                    Node<T> cursor, prev;
                    int i = 0;
                    for (prev = this; prev.Next != this; prev = prev.Next) ;
                    for (cursor = prev.Next; i < index; prev = cursor, cursor = cursor.Next, i++) ;
                    prev.Next = cursor.Next;
                    Count -= 1;
                    return true;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new NodeEnumerator<T>(this);
        }

        /**
         * Not sure how to test since the visibility of this method is internal.
         * However, it's only use is to call a method that is tested and passing.
         */
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}