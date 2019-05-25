using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task05_ArrayList
{
    class MikeList<T> : IList<T>
    {
        private T[] elements;
        private int version = 0;
        private const int defaultSize = 1024;

        public MikeList(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentException("capacity < 1  (capacity = " + capacity + ").");
            }

            elements = new T[capacity];
            Count = 0;
        }

        public MikeList() : this(defaultSize) { }

        public MikeList(IList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list == null");
            }
            if (list.Count < 1)
            {
                throw new ArgumentException("list.Count < 1  (list.Count = " + list.Count + ").");
            }

            elements = new T[list.Count];

            list.CopyTo(elements, 0);

            Count = list.Count;
        }

        public MikeList(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array == null");
            }
            if (array.Length < 1)
            {
                throw new ArgumentException("array.Length < 1  (array.Length = " + array.Length + ").");
            }

            elements = new T[array.Length];

            Array.Copy(array, elements, elements.Length);

            Count = elements.Length;
        }

        private void TestIndex(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("index < 0  (index = " + index + ").");
            }
            if (index >= Count)
            {
                throw new IndexOutOfRangeException("index >= count  (index = " + index + ", count = " + Count + ").");
            }
        }

        public T this[int index]
        {
            get
            {
                TestIndex(index);
                return elements[index];
            }
            set
            {
                TestIndex(index);
                elements[index] = value;
                version++;
            }
        }

        public int Count
        {
            get;
            protected set;
        }

        public int Capacity
        {
            get
            {
                return elements.Length;
            }
            set
            {
                if (value < Count)
                {
                    throw new ArgumentException("value < Count  (value = " + value + ", Count = " + Count + ").");
                }
                if (value < 1)
                {
                    throw new ArgumentException("value < 1  (value = " + value + ").");
                }

                Array.Resize(ref elements, value);
            }
        }

        public void TrimToSize()
        {
            if (Count < elements.Length)
            {
                if (Count > 0)
                {
                    Array.Resize(ref elements, Count);
                }
                else
                {
                    Array.Resize(ref elements, 1);
                }
            }

        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(T item)
        {
            if (Count >= elements.Length - 1)
            {
                Array.Resize(ref elements, elements.Length * 2);
            }

            elements[Count] = item;
            Count++;
            version++;
        }

        public void Clear()
        {
            for (var i = 0; i < Count; ++i)
            {
                elements[i] = default(T);
            }

            Count = 0;
            version++;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array == null");
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("arrayIndex < 0");
            }
            if (arrayIndex >= array.Length)
            {
                throw new IndexOutOfRangeException("arrayIndex >= array.Length  (arrayIndex = " + arrayIndex + ", array.Length = " + array.Length + ").");
            }
            if (Count > array.Length - arrayIndex)
            {
                throw new IndexOutOfRangeException("Count > (array.Length - arrayIndex)  (Count = " + Count + ", array.Length = " + array.Length + ", arrayIndex = " + arrayIndex + ").");
            }

            Array.Copy(elements, 0, array, arrayIndex, Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var initVersion = version;
            var initCount = Count;

            for (var i = 0; i < initCount; ++i)
            {
                if (initVersion != version)
                {
                    throw new InvalidOperationException("initVersion != version  (initVersion = " + initVersion + ", version = " + version + ").");
                }

                yield return elements[i];
            }
        }

        public int IndexOf(T item)
        {
            if (item == null)
            {
                for (var i = 0; i < Count; ++i)
                {
                    if (elements[i] == null)
                    {
                        return i;
                    }
                }
            }
            else
            {
                for (var i = 0; i < Count; ++i)
                {
                    if (item.Equals(elements[i]))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("index < 0  (index = " + index + ").");
            }
            if (index > Count)
            {
                throw new IndexOutOfRangeException("index > count  (index = " + index + ", count = " + Count + ").");
            }

            if (Count >= elements.Length - 1)
            {
                Array.Resize(ref elements, elements.Length * 2);
            }

            if (index < Count)
            {
                Array.Copy(elements, index, elements, index + 1, Count - index);
            }

            elements[index] = item;

            Count++;
            version++;
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);

            if (index < 0)
            {
                return false;
            }

            Array.Copy(elements, index + 1, elements, index, Count - 1 - index);
            Count--;
            version++;

            return true;
        }

        public void RemoveAt(int index)
        {
            TestIndex(index);

            Array.Copy(elements, index + 1, elements, index, Count - 1 - index);
            Count--;
            version++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[");
            for (var i = 0; i < Count; i++)
            {
                if (elements[i] == null)
                {
                    sb.Append("null, ");
                }
                else
                {
                    sb.Append(elements[i].ToString());
                    sb.Append(", ");
                }
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append("]");

            return sb.ToString();
        }
    }
}
