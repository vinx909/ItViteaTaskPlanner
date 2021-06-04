using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItViteaTaskPlanner.Web.Models
{
    public class Overview
    {
        public Overview() { }
        public Overview(Data.Task task)
        {
            TaskId = task.Id;
            TaskName = task.Name;
            TaskStartTime = task.StartTime;
            TaskEndTime = task.EndTime;
            CategoryName = task.Category.Name;
            if(task.Appointments != null)
            {
                AppointmentsCount = task.Appointments.Count();
            }
            else
            {
                AppointmentsCount = 0;
            }
            if (task.Notes != null)
            {
                NotesCount = task.Notes.Count();
            }
            else
            {
                NotesCount = 0;
            }
            if (task.Documents != null)
            {
                DocumentsCount = task.Documents.Count();
            }
            else
            {
                DocumentsCount = 0;
            }
        }

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