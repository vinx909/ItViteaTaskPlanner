using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItViteaTaskPlanner.Web.Models
{
    public class Document
    {
        public Document() { }
        public Document(Data.Document document)
        {
            Id = document.Id;
            TaskId = document.TaskId;
        }

        public int Id { get; set; }
        public int TaskId { get; set; }
    }
}
