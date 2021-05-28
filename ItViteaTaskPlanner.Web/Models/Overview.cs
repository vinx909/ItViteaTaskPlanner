using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItViteaTaskPlanner.Web.Models
{
    public class Overview
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime TaskStartTime { get; set; }
        public DateTime TaskEndTime { get; set; }
        public string CategoryName { get; set; }
        public int AppointmentsCount { get; set; }
        public int NotesCount { get; set; }
        public int DocumentsCount { get; set; }
    }
}