using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItViteaTaskPlanner.Data.Services.Infrastructure.InMemory
{
    class InMemoryNoteData : INoteData
    {
        private readonly List<Note> notes;

        public InMemoryNoteData()
        {
            notes = new List<Note>()
            {
                new Note(){ Id = 1, TaskId = 1, NoteText = "test text"}
            };
        }
        public void Create(Note note)
        {
            notes.Add(note);
        }
        public void Delete(int noteId)
        {
            Note toDelete = Get(noteId);
            notes.Remove(toDelete);
        }
        public void Edit(Note note)
        {
            for (int i = 0; i < notes.Count; i++)
            {
                if(notes[i].Id == note.Id)
                {
                    notes[i] = note;
                }
            }
        }
        public Note Get(int id)
        {
            return notes.FirstOrDefault(n => n.Id == id);
        }
        public IEnumerable<Note> GetNotesOfTast(int tastId)
        {
            foreach (Note note in notes)
            {
                if(note.TaskId == tastId)
                {
                    yield return note;
                }
            }
        }
    }
}
