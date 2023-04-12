// Dependency Injection

using System;
using ConsoleAppDay5ApplicationCore.Entity;

namespace ConsoleAppDay5ApplicationCore.Contracts.Services
{
	public interface IDepartmentService
	{
        void AddDepartment();
        void DeleteDepartment();
        void GetAllDepartments();
        Departments GetDepartmentById();
        void UpdateDepartment();
    }
}

