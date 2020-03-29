using CustomerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Interface
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomers(int pagenum, int customersPerPage);
        Task<bool> CreateCustomer(Customer customer);
        Task<bool> EditCustomer(string id, Customer customer);
        Task<Customer> SingleCustomer(string id);
        Task<bool> DeleteCustomer(string id);
        Task<long> GetCustCount();
        public long GetCount();
        public Customer Get(string id);
        public List<Customer> Get(int pagenum, int customersPerPage);
        public Customer Create(Customer custo);
        public void Update(string id, Customer custoIn);
        public void Remove(Customer custoIn);
        public void Remove(string id);

    }
}
