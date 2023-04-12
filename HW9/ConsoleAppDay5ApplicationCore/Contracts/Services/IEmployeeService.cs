using ConsoleAppDay5ApplicationCore.Entity;

namespace ConsoleAppDay5Infrastructure.Services
{
    public interface IEmployeeService
    {
        void AddEmployee();
        void DeleteEmployee();
        void GetAllEmployees();
        Employees GetEmployeeById();
        void UpdateEmployee();
    }
}