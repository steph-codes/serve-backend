using Serve.Core.Generic;
using Serve.Core.Models;
using Serve.Domain.LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serve.Persistence.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomer
    {
        public CustomerRepository(ServeDbContext serveDbContext)
            : base(serveDbContext)
        {
        }

        public void CreateCustomer(Customer customer) => Add(customer);


        public bool CheckCustomer(int Id)
        {
            throw new NotImplementedException();
        }

        //public void DeleteCustomer(Customer Customer)
        //{
        //    Remove(Customer);
        //}

        public IEnumerable<Customer> GetAllCustomers() =>
            GetAll().OrderBy(c => c.Id).ToList();

        public Customer GetCustomer(int Id, bool trackChanges) =>
        FindByCondition(c => c.Id.Equals(Id), trackChanges)
        .SingleOrDefault();


        public void UpdateCustomer(Customer customer)
        {
            Update(customer);
        }
    }
}
