using System;
using System.IO;
using System.Linq;
using HW7.Contracts;

namespace HW7.Repositories
{
    public class ListRepository<T> : IMyList<T>
    {
        public List<T> list = new List<T>();

        public void Add(T element)
        {
            list.Add(element);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(T element)
        {
            return list.Contains(element);
        }

        public void DeleteAt(int index)
        {
            list.RemoveAt(index);
        }

        public T Find(int index)
        {
            return list[index];
        }

        public void InsertAt(T element, int index)
        {
            list.Insert(index, element);
        }

        public T Remove(int index)
        {
            T val = list[index];
            list.RemoveAt(index);
            return val;
        }
    }
}

