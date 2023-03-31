using System;
using System.Security.Principal;
using HW7.Contracts;

namespace HW7.Repositories
{
    public class GenericRepository<T> where T : Entity, IRepository<T>
    {
        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetTById(int i)
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}

