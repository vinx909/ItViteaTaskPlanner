using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItViteaTaskPlanner.Data.Services
{
    public interface IDocumentsData
    {
        Document Get(int id);
        IEnumerable<Document> GetDocumentsOfTast(int taskId);
        int Count();
        int Count(int taskId);
        void Create(Document document);
        void Edit(Document document);
        void Delete(int documentId);
    }
}
