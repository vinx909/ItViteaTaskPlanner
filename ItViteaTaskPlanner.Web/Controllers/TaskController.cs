using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ItViteaTaskPlanner.Data.Services.Infrastructure.InMemory;
using ItViteaTaskPlanner.Web.Statics;
using ItViteaTaskPlanner.Web.Models;
using ItViteaTaskPlanner.Data.Services;

namespace ItViteaTaskPlanner.Web.Controllers
{
    public class TaskController : Controller
    {
        Data.Services.ITaskData taskDatabase;
        Data.Services.IAppointmentData appointmentDatabase;
        Data.Services.ICategoryData categoryDatabase;
        Data.Services.INoteData noteDatabase;
        Data.Services.IDocumentsData documentsDatabase;

        //Zo ergens in de starup file moeten zitten, wat ik niet heb,
        //in een service die ik niet heb,
        //Dat je dan instellen, dat c# niet begrijpt,.
        //Nu zit het hier
        public TaskController(ITaskData taskData, IAppointmentData appointmentData, ICategoryData categoryData, INoteData noteData, IDocumentsData documentsData)
        {
            this.taskDatabase = taskData;
            this.appointmentDatabase = appointmentData;
            this.categoryDatabase = categoryData;
            this.noteDatabase = noteData;
            this.documentsDatabase = documentsData;
        }

        /*
        private void GetDatabases()
        {
            if (false) //tempoarily disabled
            {
                taskDatabase = new InMemoryTaskData();
                appointmentDatabase = new InMemoryAppointmentData();
                categoryDatabase = new InMemoryCategoryData();
                noteDatabase = new InMemoryNoteData();
                documentsDatabase = new InMemoryDocumentsData();
            }
        }
        //*/

        // GET: Task
        public ActionResult Index()
        {
            //GetDatabases();
            List<Overview> OverviewList = new List<Overview>();

            /*Perry's method*/
            /*
            for (int categoryID = 0; categoryID < categoryDatabase.GetAll().ToList().Count(); categoryID++) //Theres no list we can pull from /r: for each loop would acomplish the same
            {
                foreach (var task in taskDatabase.GetTasksOfCatagory(categoryID))
                {
                    OverviewList.Add(new Overview()
                    {
                        TaskId = task.Id,
                        TaskName = task.Name,
                        CategoryName = categoryDatabase.Get(categoryID).Name,
                        TaskStartTime = task.StartTime,
                        TaskEndTime = task.EndTime,
                        DocumentsCount = documentsDatabase.Count(task.Id),
                        AppointmentsCount = appointmentDatabase.GetAppointmentsOfTask(task.Id).Count(),
                        NotesCount = noteDatabase.Count(task.Id)
                    });
                }
            }
            //*/
            /*vincents method*/
            foreach (Data.Category category in categoryDatabase.GetAll())
            {
                if (category.Tasks != null)
                {
                    foreach (Data.Task task in category.Tasks)
                    {
                        OverviewList.Add(new Overview(task));
                    } 
                }
            }

            return View(OverviewList);
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            //GetDatabases();

            /*Perry's method*/
            /*
            var BackendTask = taskDatabase.Get(id);
            var category = categoryDatabase.Get(id);
            //-------------------------------------------------------------------------- Lang level easy to use converters :D
            Details details = ModelConverter.Convert(BackendTask, new Details());
            details = ModelConverter.Convert(category, details);
            //-------------------------------------------------------------------------- kan geen list converten :(
            List<Data.Appointment> listAppointments = appointmentDatabase.GetAppointmentsOfTask(id).ToList();
            foreach (var item in listAppointments)
            {
                details.Appointments.Add(new Appointment { Id = item.Id, TaskId = item.TaskId });
            }

            List<Data.Document> listDocuments = documentsDatabase.GetDocumentsOfTast(id).ToList();
            foreach (var item in listDocuments)
            {
                details.Documents.Add(new Document { Id = item.Id, TaskId = item.TaskId });
            }

            List<Data.Document> listNotes = documentsDatabase.GetDocumentsOfTast(id).ToList();
            foreach (var item in listNotes)
            {
                details.Notes.Add(new Note { Id = item.Id, TaskId = item.TaskId });
            }

            //-----------------------------End of details data gathering.
            //*/
            /*vincents method*/
            Details details = new Details(taskDatabase, id);
            return View(details);
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            Task task = new Task();

            return View(task);
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Task/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
