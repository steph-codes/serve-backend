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
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointment
    {
        public AppointmentRepository(ServeDbContext serveDbContext)
            : base(serveDbContext)
        {
        }

        public IEnumerable<Appointment> GetAllAppointments() =>
           GetAll().OrderBy(c => c.Id).ToList();

        public Appointment GetAppointment(int Id, bool trackChanges) =>
        FindByCondition(c => c.Id.Equals(Id), trackChanges)
        .SingleOrDefault();
        public void CreateAppointment(Appointment appointment) => Add(appointment);
        public void UpdateAppointment(Appointment appointment) => Update(appointment);
        public void DeleteAppointment(Appointment appointment) => Remove(appointment);
        public bool CheckAppointment(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
