using System;
using ConsoleAppDay5ApplicationCore.Contracts.Services;
using ConsoleAppDay5ApplicationCore.Entity;
using ConsoleAppDay5Infrastructure.Repositories;

namespace ConsoleAppDay5Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        EmployeeRepository employeeRepository;

        public EmployeeService()
        {
            employeeRepository = new EmployeeRepository();
        }

        public void AddEmployee()
        {
            Employees e = new Employees();
            Console.WriteLine("Enter first name of Employee: ");
            e.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name of Employee: ");
            e.LastName = Console.ReadLine();
            Console.WriteLine("Enter salary: ");
            e.Salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter department id: ");
            e.DeptId = Convert.ToInt32(Console.ReadLine());

            if (employeeRepository.Insert(e) > 0)
                Console.WriteLine("Successfully Inserted");
            else
                Console.WriteLine("Error!");
        }

        public void DeleteEmployee()
        {
            Console.WriteLine("Enter Id number to Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            employeeRepository.DeleteById(id);
        }

        public void GetAllEmployees()
        {
            IEnumerable<Employees> employees = employeeRepository.GetAll();
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.Id} \t {emp.FirstName} \t {emp.LastName} \t {emp.Salary} \t {emp.DeptId}");
            }
        }

        public Employees GetEmployeeById()
        {
            Console.Write("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Employees emp = employeeRepository.GetById(id);
            Console.WriteLine($"{emp.Id} \t {emp.FirstName} \t {emp.LastName} \t {emp.Salary} \t {emp.DeptId}");
            return emp;
        }

        public void UpdateEmployee()
        {
            var empChange = GetEmployeeById();
            Console.WriteLine("Please enter new employee first name: ");
            empChange.FirstName = Console.ReadLine();
            Console.WriteLine("Please enter new employee last name: ");
            empChange.LastName = Console.ReadLine();
            Console.WriteLine("Please enter new salary: ");
            empChange.Salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter new department id: ");
            empChange.DeptId = Convert.ToInt32(Console.ReadLine());
            employeeRepository.Update(empChange);
        }
    }
}

