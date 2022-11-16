using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serve.Domain.LogicInterfaces
{
    public interface IRepositoryManager
    {
        IAppointment Appointment { get; }
        ICustomer  Customer { get; }
        void Save();
    }
}
