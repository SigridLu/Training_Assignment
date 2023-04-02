using System;
using static System.Reflection.Metadata.BlobBuilder;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace HW8
{
	public class CustomerRepository
	{
        public List<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer() {CustomerID = "ALFKI", ContactName = "Maria Anders", ContactTitle = "Sales Representative", City = "Berlin", Country = "Germany"},
                new Customer() {CustomerID = "ANATR", ContactName = "Ana Trujillo", ContactTitle = "Owner", City = "México D.F.", Country = "Mexico"},
                new Customer() {CustomerID = "ANTON", ContactName = "Antonio Moreno", ContactTitle = "Owner", City = "México D.F.", Country = "Mexico"},
                new Customer() {CustomerID = "AROUT", ContactName = "Thomas Hardy", ContactTitle = "Sales Representative", City = "London", Country = "UK"},
                new Customer() {CustomerID = "BERGS", ContactName = "Christina Berglund", ContactTitle = "Order Administrator", City = "Luleå", Country = "Sweden"},
                new Customer() {CustomerID = "BLAUS", ContactName = "Hanna Moos", ContactTitle = "Sales Representative", City = "Mannheim", Country = "Germany"},
                new Customer() {CustomerID = "BLONP", ContactName = "Frédérique Citeaux", ContactTitle = "Marketing Manager", City = "Strasbourg", Country = "France"},
                new Customer() {CustomerID = "BOLID", ContactName = "Martín Sommer", ContactTitle = "Owner", City = "Madrid", Country = "Spain"},
                new Customer() {CustomerID = "BONAP", ContactName = "Laurence Lebihan", ContactTitle = "Owner", City = "Marseille", Country = "France"},
                new Customer() {CustomerID = "BOTTM", ContactName = "Elizabeth Lincoln", ContactTitle = "Accounting Manager", City = "Tsawassen", Country = "Canada"},
                new Customer() {CustomerID = "BSBEV", ContactName = "Victoria Ashworth", ContactTitle = "Sales Representative", City = "London", Country = "UK"},
                new Customer() {CustomerID = "CACTU", ContactName = "Patricio Simpson", ContactTitle = "Sales Agent", City = "Buenos Aires", Country = "Argentina"},
                new Customer() {CustomerID = "CENTC", ContactName = "Francisco Chang", ContactTitle = "Marketing Manager", City = "México D.F.", Country = "Mexico"},
                new Customer() {CustomerID = "CHOPS", ContactName = "Yang Wang", ContactTitle = "Owner", City = "Bern", Country = "Switzerland"},
                new Customer() {CustomerID = "COMMI", ContactName = "Pedro Afonso", ContactTitle = "Sales Associate", City = "Sao Paulo", Country = "Brazil"}
            };
        }
    }
}

