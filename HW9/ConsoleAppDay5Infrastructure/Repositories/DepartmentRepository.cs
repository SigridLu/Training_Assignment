// Actual C# code implements the contracts/Interfaces (IRepository).
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using ConsoleAppDay5ApplicationCore.Contracts.Repositories;
using ConsoleAppDay5ApplicationCore.Entity;
using ConsoleAppDay5Infrastructure.Data;
using Dapper;

namespace ConsoleAppDay5Infrastructure.Repositories
{
    public class DepartmentRepository : IRepository<Departments>
    {
        // connection object
        private readonly DapperDbContext _dbContext;

        public DepartmentRepository()
        {
            _dbContext = new DapperDbContext();
        }

        public int Insert(Departments obj)
        {
            /* SQL injection concern
            var DeptName = "IT; Drop Database MarchDapper2023";
            IDbConnection conn = _dbContext.GetConnection();
            return conn.Execute($"Insert Into Departments Values({DeptName}, @Location)", obj);
            */

            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Execute("Insert Into Departments Values(@DeptName, @Location)", obj);
                // Execute(): dapper method, an extension of IDbConnection
            }
        }

        public int DeleteById(int id)
        {
            // 'using' will dispose the connection once it no longer being used.
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Execute("Delete From Departments Where Id = @Id", new { Id = id });
            }
        }

        public IEnumerable<Departments> GetAll()
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Query<Departments>("Select Id, DeptName, Location From Departments");
            }
        }

        public Departments GetById(int id)
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.QuerySingleOrDefault<Departments>("Select Id, DeptName, Location From Departments Where Id = @Id", new {Id = id});
            }
        }

        public int Update(Departments obj)
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Execute("Update Departments Set DeptName = @DeptName, Location = @Location Where Id = @Id", obj);
            }
        }
    }
}