using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItViteaTaskPlanner.Data
{
    public class Task
    {
        [FieldName("Id")]
        public int Id { get; set; }
        [FieldName("CategoryId")]
        public int CategoryId { get; set; }
        [FieldName("Name")]
        public string Name { get; set; }
        [FieldName("StartTime")]
        public DateTime StartTime { get; set; }
        [FieldName("EndTime")]
        public DateTime EndTime { get; set; }
    }
}
