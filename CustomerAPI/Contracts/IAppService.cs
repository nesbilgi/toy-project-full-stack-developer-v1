using System.Collections.Generic;
using Data.Filter;
using Data.Models;

namespace Data.Contracts
{
    public interface IAppService
    {
        Customer FindById(int id);
        IEnumerable<Customer> GetAll(PaginationFilter filter, int totalRecords);
        void Add(Customer customer);
        void Update(Customer customer);

        IEnumerable<Customer> FindByName(string name);

        int Count();

        int CountSearchedCustomers(string name);
    }
}