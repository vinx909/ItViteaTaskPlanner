using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItViteaTaskPlanner.Web.Models
{
    public enum TaskType
    {
        Doing = 0,
        Done = 1,
        ToDo = 2
    }

    public class TaskModel
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int[] AppointmentIds { get; set; }
        public int[] DocumentIds { get; set; }
    }
}