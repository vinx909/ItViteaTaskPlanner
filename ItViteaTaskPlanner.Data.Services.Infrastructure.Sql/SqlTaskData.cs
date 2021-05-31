using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItViteaTaskPlanner.Data.Services.Infrastructure.Sql
{
    public class SqlTaskData : ITaskData
    {
        private readonly TaskPlannerDbContext dbContext;

        public SqlTaskData(TaskPlannerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Task task)
        {
            var entry = dbContext.Entry(task);
            dbContext.Tasks.Add(task);
            entry.State = System.Data.Entity.EntityState.Added;
            dbContext.SaveChanges();
        }

        public void Delete(int taskId)
        {
            Task toDelete = Get(taskId);
            var entry = dbContext.Entry(toDelete);
            dbContext.Tasks.Remove(toDelete);
            entry.State = System.Data.Entity.EntityState.Deleted;
            dbContext.SaveChanges();
        }

        public void Edit(Task task)
        {
            var entry = dbContext.Entry(task);
            entry.State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
        }

        public Task Get(int id)
        {
            return dbContext.Tasks.Find(id);
        }

        public IEnumerable<Task> GetTasksOfCatagory(int catagoryId)
        {
            return dbContext.Tasks.Where(t => t.CategoryId == catagoryId);
        }
    }
}
