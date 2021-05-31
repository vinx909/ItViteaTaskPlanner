using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItViteaTaskPlanner.Data
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public virtual int TaskId { get; set; }
        [ForeignKey(nameof(TaskId))]
        public virtual Task Task { get; set; }
        public string NoteText { get; set; }
    }
}
