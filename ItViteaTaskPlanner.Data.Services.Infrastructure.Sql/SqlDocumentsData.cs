using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItViteaTaskPlanner.Data.Services.Infrastructure.Sql
{
    public class SqlDocumentsData : IDocumentsData
    {
        private readonly TaskPlannerDbContext dbContext;

        public SqlDocumentsData(TaskPlannerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Count()
        {
            return dbContext.Documents.Count();
        }

        public int Count(int taskId)
        {
            return GetDocumentsOfTast(taskId).Count();
        }

        public void Create(Document document)
        {
            var entry = dbContext.Entry(document);
            dbContext.Documents.Add(document);
            entry.State = System.Data.Entity.EntityState.Added;
            dbContext.SaveChanges();
        }

        public void Delete(int documentId)
        {
            Document toDelete = Get(documentId);
            var entry = dbContext.Entry(toDelete);
            dbContext.Documents.Remove(toDelete);
            entry.State = System.Data.Entity.EntityState.Deleted;
            dbContext.SaveChanges();
        }

        public void Edit(Document document)
        {
            var entry = dbContext.Entry(document);
            entry.State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
        }

        public Document Get(int id)
        {
            return dbContext.Documents.Find(id);
        }

        public IEnumerable<Document> GetDocumentsOfTast(int tastId)
        {
            return dbContext.Documents.Where(d => d.TaskId == tastId);
        }
    }
}
