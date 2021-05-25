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
            categories = new List<Category>()
            {
                new Category(){ Id = 1, Name = "To Do"},
                new Category(){ Id = 2, Name = "Doing"},
                new Category(){ Id = 3, Name = "Done"},
                new Category(){ Id = 4, Name = "Backlog"}
            };
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
    }
}
