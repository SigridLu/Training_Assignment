using System;
using System.Data;
using ConsoleAppDay5ApplicationCore.Contracts.Repositories;
using ConsoleAppDay5ApplicationCore.Entity;
using ConsoleAppDay5Infrastructure.Data;
using Dapper;

namespace ConsoleAppDay5Infrastructure.Repositories
{
    public class EmployeeRepository : IRepository<Employees>
    {
        private readonly DapperDbContext _dbContext;

        public EmployeeRepository()
        {
            _dbContext = new DapperDbContext();
        }

        public int Insert(Employees obj)
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Execute("Insert Into Employees Values(@FirstName, @LastName, @Salary, @DeptId)", obj);
            }
        }

        public int DeleteById(int id)
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Execute("Delete From Employees Where Id = @Id", new { Id = id });
            }
        }

        public IEnumerable<Employees> GetAll()
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Query<Employees>("Select Id, FirstName, LastName, Salary, DeptId From Employees");
            }
        }

        public Employees GetById(int id)
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.QuerySingleOrDefault<Employees>("Select Id, FirstName, LastName, Salary, DeptId From Employees Where Id = @Id", new { Id = id });
            }
        }

        public int Update(Employees obj)
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Execute("Update Employees Set FirstName = @FirstName, LastName = @LastName, Salary = @Salary, DeptId = @DeptId Where Id = @Id", obj);
            }
        }
    }
}

