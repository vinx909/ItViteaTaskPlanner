using System.Collections.Generic;

namespace ItViteaTaskPlanner.Data.Services
{
    public interface ICategoryData
    {
        Category Get(int id);
        int Count();
        int Count(int taskId);
        void Create(Category category);
        void Edit(Category category);
        void Delete(int categoryId);
    }
}
