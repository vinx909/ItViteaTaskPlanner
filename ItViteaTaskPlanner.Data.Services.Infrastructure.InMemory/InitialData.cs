using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItViteaTaskPlanner.Data.Services.Infrastructure.InMemory
{
    internal static class InitialData
    {
        static InitialData()
        {
            List<Category> categories = new List<Category>() {
                new Category() { Id = 1, Name = "To Do" },
                new Category() { Id = 2, Name = "Doing" },
                new Category() { Id = 3, Name = "Done" },
                new Category() { Id = 4, Name = "Backlog" }
            };

            List<Task> tasks = new List<Task>() {
                new Task() { Id = 1, CategoryId = 1, Category = categories[0], StartTime = new DateTime(2021, 5, 18), EndTime = new DateTime(2021, 5, 19), Name = "test 1" },
                new Task() { Id = 2, CategoryId = 1, Category = categories[0], StartTime = new DateTime(2021, 5, 19), EndTime = new DateTime(2021, 5, 20), Name = "test 2" },
                new Task() { Id = 3, CategoryId = 2, Category = categories[1], StartTime = new DateTime(2021, 5, 20), EndTime = new DateTime(2021, 5, 21), Name = "test 3" }
            };

            categories[0].Tasks = new List<Task>() { tasks[0], tasks[1] };
            categories[1].Tasks = new List<Task>() { tasks[2] };
            Categories = categories;

            List<Appointment> appointments = new List<Appointment>() { new Appointment() { Id = 1, TaskId = 1, Task = tasks[0] } };
            tasks[0].Appointments = new List<Appointment>() { appointments[0] };
            Appointments = appointments;

            List<Document> documents = new List<Document>() { new Document() { Id = 1, TaskId = 1, Task = tasks[0] } };
            tasks[0].Documents = new List<Document>() { documents[0] };
            Documents = documents;

            List<Note> notes = new List<Note>() { new Note() { Id = 1, TaskId = 1, Task = tasks[0], NoteText = "test text" } };
            tasks[0].Notes = new List<Note>() { notes[0] };
            Notes = notes;
        }

        internal static IEnumerable<Appointment> Appointments { get; private set; }
        internal static IEnumerable<Category> Categories { get; private set; }
        internal static IEnumerable<Document> Documents { get; private set; }
        internal static IEnumerable<Note> Notes { get; private set; }
        internal static IEnumerable<Task> Tasks { get; private set; }
    }
}
