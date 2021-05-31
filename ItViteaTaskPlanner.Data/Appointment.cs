using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItViteaTaskPlanner.Data
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public virtual int TaskId { get; set; }
        [ForeignKey(nameof(TaskId))]
        public virtual Task Task { get; set; }
    }
}
