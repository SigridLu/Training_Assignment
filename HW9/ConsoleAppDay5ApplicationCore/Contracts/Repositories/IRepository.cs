// CRUD Methods
using System;
namespace ConsoleAppDay5ApplicationCore.Contracts.Repositories
{
	public interface IRepository<T> where T : class
	{
		int Insert(T obj);
        int DeleteById(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Update(T obj);
	}
}

