using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItViteaTaskPlanner.Data.Services.Infrastructure.InMemory
{
    public class InMemoryAppointmentData : IAppointmentData
    {
        private readonly List<Appointment> appointments;

        public InMemoryAppointmentData()
        {
            appointments = new List<Appointment>()
            {
                new Appointment(){ Id = 1, TaskId = 1 }
            };
        }

        public void Create(Appointment appointment)
        {
            appointments.Add(appointment);
        }
        public void Delete(int appointmentId)
        {
            Appointment toDelete = Get(appointmentId);
            appointments.Remove(toDelete);
        }
        public void Edit(Appointment appointment)
        {
            for (int i = 0; i < appointments.Count; i++)
            {
                if(appointments[i].Id == appointment.Id)
                {
                    appointments[i] = appointment;
                    break;
                }
            }
        }
        public Appointment Get(int id)
        {
            return appointments.FirstOrDefault(a => a.Id == id);
        }
        public IEnumerable<Appointment> GetAppointmentsOfTask(int tastId)
        {
            foreach (Appointment appointment in appointments)
            {
                if(appointment.TaskId == tastId)
                {
                    yield return appointment;
                }
            }
        }
    }
}
