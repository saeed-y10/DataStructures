using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DataStructures
{
    public class clsDynamicArray<T>
    {
        private long _Size;
        private long _Capacity;
        private T[] _Array;

        public clsDynamicArray()
        {
            _Size = 0;
            _Capacity = 1;
            _Array = new T[_Capacity];
        }

        public clsDynamicArray(long Capacity)
        {
            _Size = 0;
            this.Capacity = Capacity;
            _Array = new T[_Capacity];
        }

        public long Capacity
        {
            set 
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("value");

                _Capacity = value; 
            }

            get 
            {
                return _Capacity; 
            }
        }

        public long Size 
        { 
            get
            { 
                return _Size;
            }
        }

        public bool Empty()
        {
            return _Size == 0;
        }

        private long _GetNewCapacity()
        {
            if (_Capacity == 0)
                return 1;

            return (long)(_Capacity + _Capacity / 2 + 1);
        }

        public bool Clear()
        {
            if (_Size == 0)
                return false;

            _Capacity = 1;
            _Size = 0;
            _Array = new T[_Capacity];

            return true;
        }

        private bool _NeedToResize()
        {
            return (_Capacity <= (_Size + 1));
        }

        public bool Resize(long NewCapacity)
        {
            if (NewCapacity <= 0)
                return false;

            if (NewCapacity <= _Size)
                _Size = NewCapacity++;

            T[] NewArray = new T[NewCapacity];

            System.Array.Copy(_Array, 0, NewArray, 0, _Size);
            
            _Array = NewArray;
            _Capacity = NewCapacity;

            return true;
        }

        public bool Add(T Element)
        {
            _Array[_Size++] = Element;
            
            if (_NeedToResize())
                Resize(_GetNewCapacity());

            return true;
        }

        public bool Pop()
        {
            if (_Size == 0)
                return false;

            Remove(_Size - 1);

            return true;
        }

        public long Find(T Element)
        {
            for (long i = 0; i < _Size; i++)
            {
                if (_Array[i].Equals(Element))
                    return i;
            }
                
            return -1;
        }

        public long LastIndexOf(T Element)
        {
            for (long i = _Size - 1; i >= 0; i--)
            {
                if (_Array[i].Equals(Element))
                    return i;
            }

            return -1;
        }

        public T First()
        {
            return (_Size == 0) ? default(T) : _Array[0];
        }

        public T Last()
        {
            return (_Size == 0) ? default(T) : _Array[_Size - 1];
        }

        public T Get(long Index)
        {
            if (_Size == 0)
                return default(T);

            if (Index < 0 || Index >= _Size)
                return default(T);

            return _Array[Index];
        }

        public bool Set(T Element, long Index)
        {
            if (_Size == 0)
                return false;

            if (Index < 0 || Index >= _Size)
                return false;

            _Array[Index] = Element;

            return true;
        }

        public bool Add(T Element, long Index)
        {
            if (Index < 0 || Index >= _Size)
                return false;

            if (_NeedToResize())
                Resize(_GetNewCapacity());

            System.Array.Copy(_Array, Index, _Array, Index + 1, _Size - Index);

            _Array[Index] = Element;
            _Size++;

            return true;
        }

        public bool Remove(long Index)
        {
            if (_Size == 0)
                return false;

            if (Index < 0 || Index >= _Size)
                return false;

            System.Array.Copy(_Array, Index + 1, _Array, Index, _Size - Index - 1);
            _Size--;

            return true;
        }

    }
}
