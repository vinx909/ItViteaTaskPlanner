using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItViteaTaskPlanner.Data.Services.Infrastructure.Sql
{
    public class SqlCategoryData : ICategoryData
    {
        private readonly TaskPlannerDbContext dbContext;

        public SqlCategoryData(TaskPlannerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Category category)
        {
            var entry = dbContext.Entry(category);
            dbContext.Categories.Add(category);
            entry.State = System.Data.Entity.EntityState.Added;
            dbContext.SaveChanges();
        }

        public void Delete(int categoryId)
        {
            Category toDelete = Get(categoryId);
            var entry = dbContext.Entry(toDelete);
            dbContext.Categories.Remove(toDelete);
            entry.State = System.Data.Entity.EntityState.Deleted;
            dbContext.SaveChanges();
        }

        public void Edit(Category category)
        {
            var entry = dbContext.Entry(category);
            entry.State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
        }

        public Category Get(int id)
        {
            return dbContext.Categories.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return dbContext.Categories;
        }
    }
}
