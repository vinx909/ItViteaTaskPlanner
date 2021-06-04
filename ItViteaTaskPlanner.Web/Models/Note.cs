using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItViteaTaskPlanner.Web.Models
{
    public class Note
    {
        public Note() { }
        public Note(Data.Note note)
        {
            Id = note.Id;
            TaskId = note.TaskId;
            NoteText = note.NoteText;
        }

        public int Id { get; set; }
        public int TaskId { get; set; }
        public string NoteText { get; set; }
    }
}
