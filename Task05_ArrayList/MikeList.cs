using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task05_ArrayList
{
    class MikeList<T> : IList<T>
    {
        private T[] _elements;
        private int _version = 0;
        private const int DefaultSize = 1024;

        public MikeList(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentException("capacity < 1  (capacity = " + capacity + ").");
            }

            _elements = new T[capacity];
            Count = 0;
        }

        public MikeList() : this(DefaultSize) { }

        public MikeList(ICollection<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("list == null");
            }

            _elements = new T[collection.Count];

            collection.CopyTo(_elements, 0);

            Count = collection.Count;
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
                return _elements[index];
            }
            set
            {
                TestIndex(index);
                _elements[index] = value;
                _version++;
            }
        }

        public int Count
        {
            get;
            private set;
        }

        public int Capacity
        {
            get
            {
                return _elements.Length;
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

                if (_elements.Length != value)
                {
                    Array.Resize(ref _elements, value);
                }
            }
        }

        public void TrimToSize()
        {
            if (Count < _elements.Length)
            {
                if (Count > 0)
                {
                    Array.Resize(ref _elements, Count);
                }
                else
                {
                    Array.Resize(ref _elements, 1);
                }
            }

        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(T item)
        {
            if (Count >= _elements.Length - 1)
            {
                Array.Resize(ref _elements, _elements.Length * 2);
            }

            _elements[Count] = item;
            Count++;
            _version++;
        }

        public void Clear()
        {
            for (var i = 0; i < Count; ++i)
            {
                _elements[i] = default(T);
            }

            Count = 0;
            _version++;
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

            Array.Copy(_elements, 0, array, arrayIndex, Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var initVersion = _version;
            var initCount = Count;

            for (var i = 0; i < initCount; ++i)
            {
                if (initVersion != _version)
                {
                    throw new InvalidOperationException("initVersion != version  (initVersion = " + initVersion + ", version = " + _version + ").");
                }

                yield return _elements[i];
            }
        }

        public int IndexOf(T item)
        {
            for (var i = 0; i < Count; ++i)
            {
                if (object.Equals(item, _elements[i]))
                {
                    return i;
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

            if (Count >= _elements.Length - 1)
            {
                Array.Resize(ref _elements, _elements.Length * 2);
            }

            if (index < Count)
            {
                Array.Copy(_elements, index, _elements, index + 1, Count - index);
            }

            _elements[index] = item;

            Count++;
            _version++;
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);

            if (index < 0)
            {
                return false;
            }

            Array.Copy(_elements, index + 1, _elements, index, Count - 1 - index);
            Count--;
            _version++;

            return true;
        }

        public void RemoveAt(int index)
        {
            TestIndex(index);

            Array.Copy(_elements, index + 1, _elements, index, Count - 1 - index);
            Count--;
            _version++;
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
                if (_elements[i] == null)
                {
                    sb.Append("null, ");
                }
                else
                {
                    sb.Append(_elements[i].ToString());
                    sb.Append(", ");
                }
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append("]");

            return sb.ToString();
        }
    }
}
