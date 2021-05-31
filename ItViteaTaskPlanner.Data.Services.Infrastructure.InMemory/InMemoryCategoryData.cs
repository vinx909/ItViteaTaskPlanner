using System;
using System.Collections.Generic;
using System.Linq;

namespace ItViteaTaskPlanner.Data.Services.Infrastructure.InMemory
{
    public class InMemoryCategoryData : ICategoryData
    {
        private readonly List<Category> categories;

        public InMemoryCategoryData()
        {
            categories = new List<Category>(InitialData.Categories);
        }

        public int Count()
        {
            return categories.Count();
        }

        public int Count(int taskId)
        {
            return categories.Count(x => x.Id == taskId);
        }

        public void Create(Category category)
        {
            categories.Add(category);
        }
        public void Delete(int categoryId)
        {
            Category category = Get(categoryId);
            categories.Remove(category);
        }
        public void Edit(Category category)
        {
            for (int i = 0; i < categories.Count; i++)
            {
                if(categories[i].Id == category.Id)
                {
                    categories[i] = category;
                    break;
                }
            }
        }
        public Category Get(int id)
        {
            return categories.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return categories;
        }
    }
}
