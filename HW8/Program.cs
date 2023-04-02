/* The program divides the total 15 records in customer list into 3 pages.
 * User is expected to input any page number from 1 to 3 
 * and get the corresponding page's result set.
 */
using System;
namespace HW8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 5 results per page can be displayed at a time.
            int RecordsPerPage = 5, PageNumber = 0;
            CustomerService cs = new CustomerService();
            List<Customer> result = new List<Customer>();

            do
            {
                Console.WriteLine("\n Enter Page Number Between 1 and 3");
                if (int.TryParse(Console.ReadLine(), out PageNumber))
                {
                    // check if page number is valid
                    if (PageNumber > 0 && PageNumber < 4)
                    {
                        result = cs.Pagination(PageNumber, RecordsPerPage);
                        foreach (var res in result)
                            Console.WriteLine($"ID: {res.CustomerID}, Name: {res.ContactName}, City: {res.City}");
                    }
                    else
                    {
                        Console.WriteLine("\nPlease Enter a Valid Page Number.");
                    }
                }
                else
                    Console.WriteLine("\nPlease Enter a Valid Page Number between 1 and 3");
            } while (true);
        }
    }
}