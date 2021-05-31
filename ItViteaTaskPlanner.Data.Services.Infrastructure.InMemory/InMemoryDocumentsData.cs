using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItViteaTaskPlanner.Data.Services.Infrastructure.InMemory
{
    public class InMemoryDocumentsData : IDocumentsData
    {
        private readonly List<Document> documents;

        public InMemoryDocumentsData()
        {
            documents = new List<Document>(InitialData.Documents);
        }
        public int Count()
        {
            return documents.Count();
        }

        public int Count(int taskId)
        {
            return documents.Count(x => x.Id == taskId);
        }
        public void Create(Document document)
        {
            documents.Add(document);
        }
        public void Delete(int documentId)
        {
            Document toDelete = Get(documentId);
            documents.Remove(toDelete);
        }
        public void Edit(Document document)
        {
            for (int i = 0; i < documents.Count; i++)
            {
                if(documents[i].Id == document.Id)
                {
                    documents[i] = document;
                }
            }
        }
        public Document Get(int id)
        {
            return documents.FirstOrDefault(d => d.Id == id);
        }
        public IEnumerable<Document> GetDocumentsOfTast(int tastId)
        {
            foreach(Document document in documents)
            {
                if(document.TaskId == tastId)
                {
                    yield return document;
                }
            }
        }
    }
}
