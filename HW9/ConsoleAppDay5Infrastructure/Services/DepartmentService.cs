// Inherit from contract, use all implementations(class, methods) from repository.
// to get data and prepare data to be saved to the DB, calling more methods from the repository.
// Different from repositorys where use CRUD to directly interact with db,
// services use CRUD to use methods definded in repository, which is more higher level than repository.
using System;
using ConsoleAppDay5ApplicationCore.Contracts.Services;
using ConsoleAppDay5ApplicationCore.Entity;
using ConsoleAppDay5Infrastructure.Repositories;

namespace ConsoleAppDay5Infrastructure.Services
{

    public class DepartmentService : IDepartmentService
    {
        DepartmentRepository departmentRepository;

        public DepartmentService()
        {
            departmentRepository = new DepartmentRepository();
        }

        public void AddDepartment()
        {
            Departments d = new Departments();
            Console.WriteLine("Enter name of Department: ");
            d.DeptName = Console.ReadLine();
            Console.WriteLine("Enter Location: ");
            d.Location = Console.ReadLine();

            // Because Execute() used in Insert function returns the number of refernece impacted.
            if (departmentRepository.Insert(d) > 0)
                Console.WriteLine("Successfully Inserted");
            else
                Console.WriteLine("Error!");
        }

        public void DeleteDepartment()
        {
            Console.WriteLine("Enter Id number to Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            departmentRepository.DeleteById(id);
        }

        public void GetAllDepartments()
        {
            IEnumerable<Departments> departments = departmentRepository.GetAll();
            foreach (var dept in departments)
            {
                Console.WriteLine($"{dept.Id} \t {dept.DeptName} \t {dept.Location}");
            }
        }

        public Departments GetDepartmentById()
        {
            Console.Write("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Departments department = departmentRepository.GetById(id);
            Console.WriteLine($"{department.Id} \t {department.DeptName} \t {department.Location}");
            return department;
        }

        public void UpdateDepartment()
        {
            var deptChange = GetDepartmentById();
            Console.WriteLine("Please enter new Dept name: ");
            deptChange.DeptName = Console.ReadLine();
            Console.WriteLine("Enter new location: ");
            deptChange.Location = Console.ReadLine();
            departmentRepository.Update(deptChange);
        }
    }
}

