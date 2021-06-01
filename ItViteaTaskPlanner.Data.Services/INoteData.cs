using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItViteaTaskPlanner.Data.Services
{
    public interface INoteData
    {
        Note Get(int id);
        IEnumerable<Note> GetNotesOfTast(int taskId);
        int Count();
        int Count(int taskId);
        void Create(Note note);
        void Edit(Note note);
        void Delete(int noteId);
    }
}
