using System;
namespace HW7.Contracts
{
	public interface IStack<T>
	{
		public int Count();
		public T Pop();
		public void Push();
	}
}

