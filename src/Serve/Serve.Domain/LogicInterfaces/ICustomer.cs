using Serve.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serve.Domain.LogicInterfaces
{
    public  interface ICustomer
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(int Id, bool trackChanges);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        //Customer DeleteCustomer(int Id);
        bool CheckCustomer(int Id);
    }
}
