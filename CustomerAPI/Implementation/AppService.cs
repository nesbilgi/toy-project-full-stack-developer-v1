using System.Collections.Generic;
using CustomerAPI.DataContext;
using Data.Contracts;
using Data.Filter;
using Data.Models;

namespace Data.Implementation
{
    public class AppService : IAppService
    {
        private JsonParse _json;
        public AppService(JsonParse json)
        {
            _json = json;
        }
        public void Add(Customer customer)
        {
            _json.Customers.Add(customer);
        }

        public int Count()
        {
            return _json.Customers.Count;
        }

        public int CountSearchedCustomers(string name)
        {
            return _json.Customers.FindAll(customer => 
                customer.First_Name.ToLower().Contains(name.ToLower()) 
                || customer.Last_Name.ToLower().Contains(name.ToLower())).Count;
        }

        public Customer FindById(int id)
        {
            return _json.Customers.Find(customer => customer.Id == id);
        }

        public IEnumerable<Customer> FindByName(string name)
        {
            return _json.Customers.FindAll(customer => 
                customer.First_Name.ToLower().Contains(name.ToLower()) 
                || customer.Last_Name.ToLower().Contains(name.ToLower()));
        }

        public IEnumerable<Customer> GetAll(PaginationFilter filter, int totalRecords)
        {
            int pageSize = filter.PageSize;
            int index = (filter.PageNumber - 1) * pageSize;
            
            if (index + pageSize > totalRecords + pageSize)
            {
                return null;
            }
            if (index + pageSize >= totalRecords)
            {
                pageSize = (totalRecords % pageSize) == 0 ? pageSize : (totalRecords % pageSize) ;
                index = totalRecords - pageSize;
            }

            return _json.Customers.GetRange(index, pageSize);
        }

        public void Update(Customer customer)
        {
            bool isExist = _json.Customers.Exists(cstmr => cstmr.Id == customer.Id);
            if (!isExist)
            {
                return;
            }
            Customer c = _json.Customers.Find(cstmr => cstmr.Id == customer.Id);
            _json.Customers.Remove(c);
            _json.Customers.Insert(customer.Id - 1, customer);
        }
    }
}