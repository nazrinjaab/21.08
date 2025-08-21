using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21._08.Models
{
    internal class CustomInit
    {
        public class CustomList<T>
        {
            private T[] array;
            private int count;

            public CustomList()
            {
                array = new T[4];
                count = 0;
            }


            public int Count => count;
            public int Capacity => array.Length;


            public T this[int index]
            {
                get
                {
                    if (index < 0 || index >= count)
                        throw new IndexOutOfRangeException("Index is not true");
                    return array[index];
                }
                set
                {
                    if (index < 0 || index >= count)
                        throw new IndexOutOfRangeException("Index is not true");
                    array[index] = value;
                }
            }


            private void EnsureCapacity(int newCount)
            {
                if (newCount > array.Length)
                {
                    int newSize = array.Length * 2;
                    if (newSize < newCount)
                        newSize = newCount;

                    T[] newArray = new T[newSize];
                    for (int i = 0; i < count; i++)
                        newArray[i] = array[i];
                    array = newArray;
                }
            }


            public void Add(T item)
            {
                EnsureCapacity(count + 1);
                array[count++] = item;
            }


            public void AddRange(params T[] items)
            {
                EnsureCapacity(count + items.Length);
                foreach (var item in items)
                    array[count++] = item;
            }


            public bool Contains(T item)
            {
                for (int i = 0; i < count; i++)
                {
                    if (Equals(array[i], item))
                        return true;
                }
                return false;
            }


            public bool Remove(T item)
            {
                for (int i = 0; i < count; i++)
                {
                    if (Equals(array[i], item))
                    {
                        for (int j = i; j < count - 1; j++)
                            array[j] = array[j + 1];
                        count--;
                        return true;
                    }
                }
                return false;
            }


            public void RemoveRange(params T[] items)
            {
                foreach (var item in items)
                {
                    while (Remove(item)) { }
                }
            }


            public override string ToString()
            {
                if (count == 0) return string.Empty;

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < count; i++)
                {
                    sb.Append(array[i]);
                    if (i < count - 1) sb.Append(", ");
                }
                return sb.ToString();
            }
        }
    }
}
