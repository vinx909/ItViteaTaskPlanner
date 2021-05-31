using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItViteaTaskPlanner.Data
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public virtual int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [ForeignKey(nameof(Note.TaskId))]
        public ICollection<Note> Notes { get; set; }
        [ForeignKey(nameof(Document.TaskId))]
        public ICollection<Document> Documents { get; set; }
        [ForeignKey(nameof(Appointment.TaskId))]
        public ICollection<Appointment> Appointments { get; set; }
    }
}
