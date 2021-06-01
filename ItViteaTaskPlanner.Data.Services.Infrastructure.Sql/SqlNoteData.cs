using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItViteaTaskPlanner.Data.Services.Infrastructure.Sql
{
    public class SqlNoteData : INoteData
    {
        private readonly TaskPlannerDbContext dbContext;

        public SqlNoteData(TaskPlannerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Count()
        {
            return dbContext.Notes.Count();
        }

        public int Count(int taskId)
        {
            return GetNotesOfTast(taskId).Count();
        }

        public void Create(Note note)
        {
            var entry = dbContext.Entry(note);
            dbContext.Notes.Add(note);
            entry.State = System.Data.Entity.EntityState.Added;
            dbContext.SaveChanges();
        }

        public void Delete(int noteId)
        {
            Note toDelete = Get(noteId);
            var entry = dbContext.Entry(toDelete);
            dbContext.Notes.Remove(toDelete);
            entry.State = System.Data.Entity.EntityState.Deleted;
            dbContext.SaveChanges();
        }

        public void Edit(Note note)
        {
            var entry = dbContext.Entry(note);
            entry.State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
        }

        public Note Get(int id)
        {
            return dbContext.Notes.Find(id);
        }

        public IEnumerable<Note> GetNotesOfTast(int tastId)
        {
            return dbContext.Notes.Where(n => n.TaskId == tastId);
        }
    }
}
