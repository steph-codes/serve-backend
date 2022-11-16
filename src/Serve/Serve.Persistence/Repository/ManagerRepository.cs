using Serve.Core.Models;
using Serve.Domain.LogicInterfaces;
using Serve.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serve.Persistence.Repository
{
    public class ManagerRepository : IRepositoryManager
    {

        private ServeDbContext _ServeDbContext;
        private IAppointment _appointment;
        private ICustomer _customer;

        public ManagerRepository(ServeDbContext servedbcontext)
        {
            _ServeDbContext = servedbcontext;
        }

        public IAppointment Appointment
        {
            get
            {
                if (_appointment == null)
                    _appointment = new AppointmentRepository(_ServeDbContext);
                return _appointment;
            }
        }

        //public ICustomer customer => throw new notimplementedexception();
        public ICustomer Customer
        {
            get
            {
                if (_customer == null)
                    _customer = new CustomerRepository(_ServeDbContext);
                return _customer;
            }
        }

        public void Save() => _ServeDbContext.SaveChanges();
    }
}
