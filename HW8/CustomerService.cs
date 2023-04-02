using System;
namespace HW8
{
	public class CustomerService
	{
		private readonly CustomerRepository cr;
		public CustomerService()
		{
			// Default constructor initiates Customer data
			cr = new CustomerRepository();
		}

		public List<Customer> Pagination(int PageNumber, int RecordsPerPage)
		{
			var customers = cr.GetCustomers().Skip((PageNumber - 1) * RecordsPerPage).Take(RecordsPerPage).ToList();
			return customers;
		}
	}
}

