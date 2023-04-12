// represent DB
using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleAppDay5Infrastructure.Data
{
	public class DapperDbContext
	{
		// connection object to link C# code to SQL db
		IDbConnection dbConnection;
		public DapperDbContext()
		{
            /* connection string inside SqlConnection(): helps define which database we're looking for.
				Problem: connection string is not managed, it needs to be disposal onces no longer needed.
				use 'using' to wrap around the connection in methods(ie. methods in DepartmentService), it disposes the connection once it no longer being used.
				And if the connection string is established in this constructor, once a method disposed the connection, another method can longer access the db again.
				Solution: Move the connection string to GetConnection() methods below.
			*/
            //dbConnection = new SqlConnection("Server=localhost; Database=MarchDapper2023; User Id=sa; Password=PA_Clemson$$2020; trustServerCertificate=true");
		}
 
		public IDbConnection GetConnection()
		{
            // Solution:
            dbConnection = new SqlConnection("Server=localhost; Database=MarchDapper2023; User Id=sa; Password=PA_Clemson$$2020; trustServerCertificate=true");
            return dbConnection;
		}
	}
}

