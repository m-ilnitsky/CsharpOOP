using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task06_HashTable
{
    class MikeHashTable<T> : ICollection<T>
    {
        private LinkedList<T>[] _hashArray;
        private const int MinHashArraySize = 8;
        private const int DefaultHashArraySize = 1024;
        private int _version;

        public MikeHashTable(int hashArraySize)
        {
            if (hashArraySize >= MinHashArraySize)
            {
                _hashArray = new LinkedList<T>[hashArraySize];
            }
            else
            {
                _hashArray = new LinkedList<T>[MinHashArraySize];
            }

            _version = 0;
            Count = 0;
        }

        public MikeHashTable() : this(DefaultHashArraySize) { }

        public MikeHashTable(ICollection<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection == null");
            }

            if (collection.Count > DefaultHashArraySize)
            {
                _hashArray = new LinkedList<T>[collection.Count];
            }
            else
            {
                _hashArray = new LinkedList<T>[DefaultHashArraySize];
            }

            foreach (var element in collection)
            {
                Add(element);
            }
        }

        public int Count
        {
            get;
            private set;
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        private int getIndex(T item)
        {
            if (item == null)
            {
                return 0;
            }
            else
            {
                return Math.Abs(item.GetHashCode()) % _hashArray.Length;
            }
        }

        public void Add(T item)
        {
            var index = getIndex(item);

            if (_hashArray[index] == null)
            {
                _hashArray[index] = new LinkedList<T>();
            }

            _hashArray[index].AddLast(item);

            Count++;
            _version++;
        }

        public void Clear()
        {
            for (var i = 0; i < _hashArray.Length; ++i)
            {
                if (_hashArray[i] != null)
                {
                    _hashArray[i].Clear();
                    _hashArray[i] = null;
                }
            }

            Count = 0;
            _version++;
        }

        public bool Contains(T item)
        {
            var index = getIndex(item);

            if (_hashArray[index] != null && _hashArray[index].Count > 0)
            {
                return _hashArray[index].Contains(item);
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
            if (Count > array.Length - arrayIndex)
            {
                throw new IndexOutOfRangeException("Count > (array.Length - arrayIndex)  (Count = " + Count + ", array.Length = " + array.Length + ", arrayIndex = " + arrayIndex + ").");
            }

            int index = arrayIndex;
            foreach (var list in _hashArray)
            {
                if (list != null && list.Count > 0)
                {
                    list.CopyTo(array, index);
                    index += list.Count;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var initVersion = _version;
            var initCount = Count;

            foreach (var list in _hashArray)
            {
                if (list != null && list.Count > 0)
                {
                    foreach (var element in list)
                    {
                        if (initVersion != _version)
                        {
                            throw new InvalidOperationException("initVersion != version  (initVersion = " + initVersion + ", version = " + _version + ").");
                        }

                        yield return element;
                    }
                }
            }
        }

        public bool Remove(T item)
        {
            var index = getIndex(item);

            if (_hashArray[index] != null && _hashArray[index].Count > 0)
            {
                if (_hashArray[index].Remove(item))
                {
                    Count--;
                    _version++;
                    return true;
                }
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[");

            foreach (var list in _hashArray)
            {
                if (list != null && list.Count > 0)
                {
                    foreach (var element in list)
                    {
                        if (element == null)
                        {
                            sb.Append("null, ");
                        }
                        else
                        {
                            sb.Append(element.ToString());
                            sb.Append(", ");
                        }
                    }
                }
            }

            if (sb.Length > 2)
            {
                sb.Remove(sb.Length - 2, 2);
            }

            sb.Append("]");

            return sb.ToString();
        }
    }
}
