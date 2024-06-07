using Dapper;
using RapidBootcamp.WebApplication.Models;
using System.Data.SqlClient;

namespace RapidBootcamp.WebApplication.DAL
{
    public class CustomersDAL : ICustomer
    {
        private readonly IConfiguration _configuration;

        public CustomersDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnStr() {
            return _configuration.GetConnectionString("DefaultConnection");
        }

        public Customer Add(Customer entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                try
                {
                    string query = @"INSERT INTO Customers (CustomerName,Address,City,Email,PhoneNumber)
                                    VALUES (@CustomerName,@Address,@City,@Email,@PhoneNumber);select @@identity;";
                    var param = new { CustomerName = entity.CustomerName,Address = entity.Address, 
                                    City= entity.City,Email=entity.Email,PhoneNumber=entity.PhoneNumber
                    };
                    int newId = conn.ExecuteScalar<int>(query, param);
                    entity.CustomerId = newId;
                    return entity;
                }
                catch (SqlException sqlEx)
                {

                    throw new ArgumentException(sqlEx.Message);
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string query = @"delete from Customers where CustomerId = @CustomerId";
                var param = new { CustomerId = id };
                conn.Execute(query, param);
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string query = @"select * from Customers
                                 order by CustomerName asc";
                var customers = conn.Query<Customer>(query);
                return customers;
            }
        }

        public Customer GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string query = @"select * from Customers
                                 where CustomerId = @CustomerId";
                var param = new { CustomerId = id };
                var customer = conn.QuerySingleOrDefault<Customer>(query, param);
                if (customer == null)
                {
                    throw new ArgumentException("Data not found");
                }
                return customer;
            }
        }

        public Customer Update(Customer entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                try
                {
                    string query = @"update Customers set CustomerName = @CustomerName, 
                                    Address = @Address, Email=@Email,City=@City,PhoneNumber=@PhoneNumber
                                    where CustomerId = @CustomerId";
                    var param = new { CustomerName = entity.CustomerName, CustomerId = entity.CustomerId,
                        Address = entity.Address, Email = entity.Email, City= entity.City, 
                        PhoneNumber = entity.PhoneNumber
                    };
                    conn.Execute(query, param);
                    return entity;

                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException(sqlEx.Message);
                }
            }
        }

        public IEnumerable<Customer> GetCustomersByName(string customerName)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string query = @"select * from Customers
                                where CustomerName like @CustomerName
                                order by CustomerName asc";
                var param = new { CustomerName = "%" + customerName + "%" };
                var customers = conn.Query<Customer>(query, param);
                return customers;
            }
        }

        public IEnumerable<Customer> GetCustomersByCity(string city)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string query = @"select * from Customers
                                where City like @City
                                order by City asc";
                var param = new { City = "%" + city + "%" };
                var customers = conn.Query<Customer>(query, param);
                return customers;
            }
        }

        public IEnumerable<Customer> GetCustomersByNameOrCity(string customerNameOrCity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string query = @"select * from Customers
                                where City like @CustomerNameOrCity OR 
                                CustomerName like @CustomerNameOrCity
                                order by City asc";
                var param = new { CustomerNameOrCity = "%" + customerNameOrCity + "%" };
                var customers = conn.Query<Customer>(query, param);
                return customers;
            }
        }
    }
}
