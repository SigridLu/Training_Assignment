// Represent Application: include web pages (Javascript, CSS, etc)
using System;
using System.Linq.Expressions;
using ConsoleAppDay5ApplicationCore.Entity;
using ConsoleAppDay5Infrastructure.Services;
namespace ConsoleDay5Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List<Employees> employees = new List<Employees>();
            // EmployeeService e = new EmployeeService();

            Menu menu = new Menu();
            menu.Run();
        }
    }
}