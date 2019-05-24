using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task05_ArrayList
{
    class MikeList<T> : IList<T>
    {
        private T[] elements;
        private int count;
        private int version = 0;
        private const int defaultSize = 1024;

        public MikeList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("capacity < 0  (capacity = " + capacity + ").");
            }
            if (capacity > MaxCapacity)
            {
                throw new ArgumentException("capacity > MaxCapacity  (capacity = " + capacity + ", MaxCapacity = " + MaxCapacity + ").");
            }

            elements = new T[capacity];
            count = 0;
        }

        public MikeList() : this(defaultSize) { }

        public MikeList(IList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list == null");
            }

            elements = new T[list.Count];

            list.CopyTo(elements, 0);

            count = list.Count;
        }

        public MikeList(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array == null");
            }

            elements = new T[array.Length];

            Array.Copy(array, elements, elements.Length);

            count = elements.Length;
        }

        public int MaxCapacity
        {
            get { return int.MaxValue; }
        }

        private void TestIndex(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("index < 0  (index = " + index + ").");
            }
            if (index >= count)
            {
                throw new IndexOutOfRangeException("index >= count  (index = " + index + ", count = " + count + ").");
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
            get { return count; }
        }

        public int Capacity
        {
            get { return elements.Length; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item == null");
            }

            if (count >= elements.Length - 1)
            {
                Array.Resize(ref elements, elements.Length * 2);
            }

            elements[count] = item;
            count++;
            version++;
        }

        public void Clear()
        {
            for (var i = 0; i < count; ++i)
            {
                elements[i] = default(T);
            }

            count = 0;
            version++;
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item == null");
            }

            for (var i = 0; i < count; ++i)
            {
                if (item.Equals(elements[i]))
                {
                    return true;
                }
            }

            return false;
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

            int length = Math.Min(count, array.Length - arrayIndex);

            Array.Copy(elements, 0, array, arrayIndex, length);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var initVersion = version;
            var initCount = count;
            var i = -1;

            while (i < initCount)
            {
                if (initVersion != version)
                {
                    throw new InvalidOperationException("initVersion != version  (initVersion = " + initVersion + ", version = " + version + ").");
                }

                ++i;
                yield return elements[i];
            }
        }

        public int IndexOf(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item == null");
            }

            for (var i = 0; i < count; ++i)
            {
                if (item.Equals(elements[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            TestIndex(index);

            if (item == null)
            {
                throw new ArgumentNullException("item == null");
            }

            if (count >= elements.Length - 1)
            {
                Array.Resize(ref elements, elements.Length * 2);
            }

            Array.Copy(elements, index, elements, index + 1, count - index);

            elements[index] = item;

            count++;
            version++;
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);

            if (index < 0)
            {
                return false;
            }

            Array.Copy(elements, index + 1, elements, index, count - 1 - index);
            count--;
            version++;

            return true;
        }

        public void RemoveAt(int index)
        {
            TestIndex(index);

            Array.Copy(elements, index + 1, elements, index, count - 1 - index);
            count--;
            version++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void TrimToSize()
        {
            Array.Resize(ref elements, count);
        }

        public void EnsureCapacity(int capacity)
        {
            if (capacity < count)
            {
                throw new ArgumentException("capacity < count  (capacity = " + capacity + ", count = " + count + ").");
            }
            if (capacity > MaxCapacity)
            {
                throw new ArgumentException("capacity > MaxCapacity  (capacity = " + capacity + ", MaxCapacity = " + MaxCapacity + ").");
            }

            Array.Resize(ref elements, capacity);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[");
            for (var i = 0; i < count; i++)
            {
                sb.Append(elements[i].ToString());
                sb.Append(", ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append("]");

            return sb.ToString();
        }
    }
}
