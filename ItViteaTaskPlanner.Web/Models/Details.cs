using ItViteaTaskPlanner.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItViteaTaskPlanner.Web.Models
{
    public class Details
    {
        public int TaskId { get; set; }
        public int TaskCategoryId { get; set; }
        public string TaskName { get; set; }
        public DateTime TaskStartTime { get; set; }
        public DateTime TaskEndTime { get; set; }
        public string CategoryName { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<Note> Notes { get; set; }
        public List<Document> Documents { get; set; }

        public Details()
        {
            Appointments = new List<Appointment>();
            Notes = new List<Note>();
            Documents = new List<Document>();
        }

        public Details(ITaskData taskData, int taskId) : this()
        {
            Data.Task task = taskData.Get(taskId);

            TaskId = taskId;
            TaskCategoryId = task.CategoryId;
            TaskName = task.Name;
            TaskStartTime = task.StartTime;
            TaskEndTime = task.EndTime;
            CategoryName = task.Category.Name;

            if (task.Appointments != null)
            {
                foreach (Data.Appointment appointment in task.Appointments)
                {
                    Appointments.Add(new Appointment(appointment));
                } 
            }

            if (task.Notes != null)
            {
                foreach (Data.Note note in task.Notes)
                {
                    Notes.Add(new Note(note));
                } 
            }

            if (task.Documents != null)
            {
                foreach (Data.Document document in task.Documents)
                {
                    Documents.Add(new Document(document));
                } 
            }
        }
    }
}