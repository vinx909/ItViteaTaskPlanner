using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItViteaTaskPlanner.Web.Models
{
    public class Appointment
    {
        public Appointment() { }
        public Appointment(Data.Appointment appointment)
        {
            Id = appointment.Id;
            TaskId = appointment.TaskId;
        }

        public int Id { get; set; }
        public int TaskId { get; set; }
    }
}
