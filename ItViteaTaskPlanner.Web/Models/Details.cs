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
        public string NoteText { get; set; }
        public IEnumerable<Data.Appointment> Appointments { get; set; }
        public IEnumerable<Data.Note> Notes { get; set; }
        public IEnumerable<Data.Document> Documents { get; set; }
    }
}