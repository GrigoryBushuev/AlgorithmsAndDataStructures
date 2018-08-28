using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Linear
{
    public class List<T> : IList<T>
    {
        private T[] _items;
        private uint _capacity;
        private int _size;

        public List() : this(0) { }

        public List(int capacity)
        {
            _items = new T[capacity];
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= _size)
                throw new ArgumentOutOfRangeException(nameof(index));
        }

        public T this[int index]
        {
            get
            {
                CheckIndex(index);
                return _items[index];
            }
            set
            {
                CheckIndex(index);
                _items[index] = value;
            }
        }

        public int Count => _size;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _size++;
            EnsureCapacity((uint)_size);
            _items[_size - 1] = item;            
        }

        public void Clear()
        {
            _size = 0;
            Array.Clear(_items, 0, _items.Length);
        }

        public bool Contains(T item)
        {
            return Array.IndexOf(_items, item) >= 0;
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(_items, item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array));

            Array.Copy(_items, 0, array, arrayIndex, _size);
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > _size)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (_size == _capacity)
                EnsureCapacity(_capacity + 1);

            if (index == _size)
                _size++;

            _items[index] = item;
        }

        public bool Remove(T item)
        {
            var index = Array.IndexOf(_items, item);
            if (index < 0)
                return false;

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);
            _size--;
            Array.Copy(_items, index + 1, _items, index, _size - index);
            _items[_size] = default(T);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < _size; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void EnsureCapacity(uint expectedCapacity)
        {
            if (expectedCapacity >= _capacity)
            {
                expectedCapacity <<= 1;
                _capacity = expectedCapacity;
                Array.Resize(ref _items, (int)_capacity);
            }
        }
    }
}
