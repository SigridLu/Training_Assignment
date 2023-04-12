// Represent tables in db: (i.e Departments table in MarchDapper2023 db)
using System;
namespace ConsoleAppDay5ApplicationCore.Entity
{
	public class Employees
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public int DeptId { get; set; }

        // Navigation Property: use to help reference values from related table.
        // We then are able to access that table(Departments, in our case) here.
        // If records in Employees table have one to many relationship with Departments table,
        // we can use List<Departments> instead.
        public Departments departments { get; set; }
    }
}

