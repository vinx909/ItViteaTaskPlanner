using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItViteaTaskPlanner.Data.Services.Infrastructure.InMemory
{
    public class InMemoryTaskData : ITaskData
    {
        private readonly List<Task> tasks;

        public InMemoryTaskData()
        {
            tasks = new List<Task>(InitialData.Tasks);
        }

        public void Create(Task task)
        {
            tasks.Add(task);
        }
        public void Delete(int taskId)
        {
            Task toDelete = Get(taskId);
            tasks.Remove(toDelete);
        }
        public void Edit(Task task)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if(tasks[i].Id == task.Id)
                {
                    tasks[i] = task;
                }
            }
        }
        public Task Get(int id)
        {
            return tasks.FirstOrDefault(t => t.Id == id);
        }
        public IEnumerable<Task> GetTasksOfCatagory(int catagoryId)
        {
            foreach (Task task in tasks)
            {
                if(task.CategoryId == catagoryId)
                {
                    yield return task;
                }
            }
        }
    }
}
