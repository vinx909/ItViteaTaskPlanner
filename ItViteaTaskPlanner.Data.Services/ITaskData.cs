using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItViteaTaskPlanner.Data.Services
{
    public interface ITaskData
    {
        Task Get(int id);
        IEnumerable<Task> GetTasksOfCatagory(int catagoryId);
        void Create(Task task);
        void Edit(Task task);
        void Delete(int taskId);
    }
}
