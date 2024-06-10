using RapidBootcamp.BackendAPI.Models;

namespace RapidBootcamp.WebApplication.DAL
{
    public class CustomersEF : ICustomer
    {
        private readonly AppDbContext _dbContext;

        public CustomersEF(AppDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        public Customer Add(Customer entity)
        {
            try
            {
                _dbContext.Customers.Add(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var customerDelete = GetById(id);
                if (customerDelete != null)
                {
                    _dbContext.Customers.Remove(customerDelete);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException($"Data Customer ID: {id} tidak ada");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            try
            {
                var results = _dbContext.Customers.ToList();
                if (results != null)
                {
                    return results;
                }
                else { 
                    throw new ArgumentException("Tabel Datanya Kosong");
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Customer GetById(int id)
        {
            try
            {
                var result = _dbContext.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new ArgumentException("Tabel Datanya Kosong");
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Customer> GetCustomersByCity(string city)
        {
            try
            {
                var result = _dbContext.Customers.Where(c => c.City.Contains(city));
                if(result != null)
                {
                    return result;
                }
                else
                {
                    throw new ArgumentException($"Customer yang di city {city} tidak ada");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Customer> GetCustomersByName(string customerName)
        {
            try
            {
                var result = _dbContext.Customers.Where(c => c.CustomerName.Contains(customerName));
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new ArgumentException($"Nama {customerName} tidak ada");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Customer> GetCustomersByNameOrCity(string customerNameOrCity)
        {
            try
            {
                var result = _dbContext.Customers.Where(c => c.CustomerName.Contains(customerNameOrCity) || c.City.Contains(customerNameOrCity)).ToList();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new ArgumentException($"Nama Atau City {customerNameOrCity} tidak ada");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Customer Update(Customer entity)
        {
            try
            {
                var customerUpdate = GetById(entity.CustomerId);
                if (customerUpdate != null) {

                    
                    customerUpdate.CustomerName = entity.CustomerName;
                    customerUpdate.Address = entity.Address;
                    customerUpdate.City = entity.City;
                    customerUpdate.Email = entity.Email;
                    //_dbContext.Customers.Update(customerUpdate);
                    _dbContext.SaveChanges();
                    return customerUpdate;
                }
                else
                {
                    throw new ArgumentException($"Customer Id:{entity.CustomerId} tidak ada");
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
