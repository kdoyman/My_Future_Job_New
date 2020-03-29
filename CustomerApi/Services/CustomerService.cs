using CustomerApi.Interface;
using CustomerLibrary;
using MongoDB.Driver;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<Customer> _customers;
        
        public CustomerService(ICustomerDbSettings settings)
        {            
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _customers = database.GetCollection<Customer>(settings.CollectionName);
        }
        public async Task<bool> CreateCustomer(Customer customer)
        {
            try
            {
                await _customers.InsertOneAsync(customer);
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Failed to create customer {CustomerName}", customer.ContactName);
                return false;
            }
        }

        public async Task<bool> DeleteCustomer(string id)
        {
            try
            {
                await _customers.DeleteOneAsync(customer => customer.Id == id);
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Failed to delete  customer {CustomerId}", id);
                return false;
            }
        }

        public async Task<bool> EditCustomer(string id, Customer customer)
        {
            try
            {
                await _customers.ReplaceOneAsync(custo => custo.Id == id, customer);
                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Failed to edit  customer {CustomerName}", customer.ContactName);
                return false;
            }
        }

        public async Task<long> GetCustCount() { return await _customers.Find(custo => true).CountDocumentsAsync(); }

        public async Task<List<Customer>> GetCustomers(int pagenum, int customersPerPage)
        {
            try
            {               
                return await _customers.Find(custo => true).Limit(customersPerPage).Skip((pagenum - 1) * customersPerPage).ToListAsync();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Failed to get customers ");
                return null;
            }
        }


        public async Task<Customer> SingleCustomer(string id)
        {
            try
            {
                return await _customers.Find<Customer>(custo => custo.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Failed to find customer {CustomerId}", id);
                return null;
            }
        }

        public long GetCount() { return  _customers.Find(custo => true).CountDocuments(); }
        public List<Customer> Get(int pagenum, int customersPerPage)
        {
            return _customers.Find(custo => true).Limit(customersPerPage).Skip((pagenum - 1) * customersPerPage).ToList();
        }
        public Customer Get(string id) =>
          _customers.Find<Customer>(custo => custo.Id == id).FirstOrDefault();

        public Customer Create(Customer custo)
        {
            _customers.InsertOne(custo);
            return custo;
        }

        public void Update(string id, Customer custoIn) =>
            _customers.ReplaceOne(custo => custo.Id == id, custoIn);

        public void Remove(Customer custoIn) =>
            _customers.DeleteOne(custo => custo.Id == custoIn.Id);

        public void Remove(string id) =>
            _customers.DeleteOne(custo => custo.Id == id);

    }
}
