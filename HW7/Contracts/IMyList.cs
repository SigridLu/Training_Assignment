using System;
namespace HW7.Contracts
{
	public interface IMyList<T>
	{
		public void Add(T element);
		public T Remove(int index);
		public bool Contains(T element);
		public void Clear();
		public void InsertAt(T element, int index);
		public void DeleteAt(int index);
		public T Find(int index);
	}
}