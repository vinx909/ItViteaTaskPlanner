using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ItViteaTaskPlanner.Data.Services.Infrastructure.Sql
{
    public class SqlAppointmentData : IAppointmentData
    {
        private readonly TaskPlannerDbContext dbContext;

        public SqlAppointmentData(TaskPlannerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Appointment appointment)
        {
            var entry = dbContext.Entry(appointment);
            dbContext.Appointments.Add(appointment);
            entry.State = System.Data.Entity.EntityState.Added;
            dbContext.SaveChanges();
        }

        public void Delete(int appointmentId)
        {
            Appointment toDelete = Get(appointmentId);
            var entry = dbContext.Entry(toDelete);
            dbContext.Appointments.Remove(toDelete);
            entry.State = System.Data.Entity.EntityState.Deleted;
            dbContext.SaveChanges();
        }

        public void Edit(Appointment appointment)
        {
            var entry = dbContext.Entry(appointment);
            entry.State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
        }

        public Appointment Get(int id)
        {
            return dbContext.Appointments.Find(id);
        }

        public IEnumerable<Appointment> GetAppointmentsOfTask(int tastId)
        {
            return dbContext.Appointments.Where(a => a.TaskId == tastId);
        }
    }
}
