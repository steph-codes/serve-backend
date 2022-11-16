using Serve.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serve.Domain.LogicInterfaces
{
    public interface IAppointment
    {
        IEnumerable<Appointment> GetAllAppointments();
        Appointment GetAppointment(int Id ,bool trackChanges);
        void CreateAppointment(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(Appointment  appointment);
        bool CheckAppointment(int Id);

    }
}
