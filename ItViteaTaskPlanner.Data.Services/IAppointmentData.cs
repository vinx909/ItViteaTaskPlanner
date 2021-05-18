using System.Collections.Generic;

namespace ItViteaTaskPlanner.Data.Services
{
    public interface IAppointmentData
    {
        Appointment Get(int id);
        IEnumerable<Appointment> GetAppointmentsOfTast(int tastId);
        void Create(Appointment appointment);
        void Edit(Appointment appointment);
        void Delete(int appointmentId);
    }
}
