using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockeyWC.Models
{
    interface IAppointmentRepository
    {
        IQueryable<Appointment> Appointments { get; }
        void SaveOrder(Appointment appointment);
    }
}
