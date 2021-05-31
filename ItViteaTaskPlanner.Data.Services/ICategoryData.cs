using System.Collections.Generic;

namespace ItViteaTaskPlanner.Data.Services
{
    public interface ICategoryData
    {
        Category Get(int id);
        IEnumerable<Category> GetAll();
        void Create(Category category);
        void Edit(Category category);
        void Delete(int categoryId);
    }
}
