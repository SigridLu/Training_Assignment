using System;
namespace HW7.Contracts
{
    // CRUD (Create, Read, Update, Delete)
    // This interface contains CRUD methods
    public interface IRepository<T>
    {
        public void Add(T item);
        public void Remove(T item);
        public void Save();
        public IEnumerable<T> GetAll();
        public T GetTById(int i);
    }
}

