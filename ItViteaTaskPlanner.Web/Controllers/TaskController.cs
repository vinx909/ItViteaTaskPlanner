using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ItViteaTaskPlanner.Data.Services.Infrastructure.InMemory;
using ItViteaTaskPlanner.Web.Statics;
using ItViteaTaskPlanner.Web.Models;

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
        private void GetDatabases()
        {
            taskDatabase = new InMemoryTaskData();
            appointmentDatabase = new InMemoryAppointmentData();
            categoryDatabase = new InMemoryCategoryData();
            noteDatabase = new InMemoryNoteData();
            documentsDatabase = new InMemoryDocumentsData();
        }
        // GET: Task
        public ActionResult Index()
        {
            GetDatabases();
            List<Overview> OverviewList = new List<Overview>();

            for (int categoryID = 0; categoryID < categoryDatabase.Count(); categoryID++) //Theres no list we can pull from
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
                        AppointmentsCount = appointmentDatabase.Count(task.Id),
                        NotesCount = noteDatabase.Count(task.Id)
                    });
                }
            }


            return View(OverviewList);
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            GetDatabases();
            Details details;

            #region old
            //bool usePerrys = false;
            //if (usePerrys)
            //{
            //    bool ByAttribute = true;
            //    if (ByAttribute)
            //    {
            //        //---------------------------------------------------------------- < omdat ja hey moeten het aleen hier hebben toch?
            //        Data.Task BackendTask = taskDatabase.Get(id);
            //        Data.Category category = categoryDatabase.Get(id);

            //        //-------------------------------------------------------------------------- Lang level easy to use converters :D
            //        details = ModelConverter.ConvertByAttribute(BackendTask, new Details());
            //        details = ModelConverter.ConvertByAttribute(category, details);

            //        details.Appointments = ModelConverter.ConvertByAttribute(
            //            appointmentDatabase.GetAppointmentsOfTast(id), new List<Appointment>());

            //        details.Documents = ModelConverter.ConvertByAttribute(
            //            documentsDatabase.GetDocumentsOfTast(id), new List<Document>());

            //        details.Notes = ModelConverter.ConvertByAttribute(
            //            noteDatabase.GetNotesOfTast(id), new List<Note>());
            //    }
            //    else
            //    {
            //        //---------------------------------------------------------------- < omdat ja hey moeten het aleen hier hebben toch?
            //        Data.Task BackendTask = taskDatabase.Get(id);
            //        Data.Category category = categoryDatabase.Get(id);

            //        //-------------------------------------------------------------------------- Lang level easy to use converters :D
            //        details = ModelConverter.Convert(BackendTask, new Details());
            //        details = ModelConverter.Convert(category, details);

            //        details.Appointments = ModelConverter.Convert(
            //            appointmentDatabase.GetAppointmentsOfTast(id), new List<Appointment>());

            //        details.Documents = ModelConverter.Convert(
            //            documentsDatabase.GetDocumentsOfTast(id), new List<Document>());

            //        details.Notes = ModelConverter.Convert(
            //            noteDatabase.GetNotesOfTast(id), new List<Note>());
            //    }
            //}
            //else
            //{
            #endregion

            details = new Details();
            details.Appointments = new List<Appointment>();
            details.Documents = new List<Document>();
            details.Notes = new List<Note>();
            details.TaskId = id;
            details.TaskName = taskDatabase.Get(id).Name;
            details.TaskCategoryId = taskDatabase.Get(id).CategoryId;
            details.TaskStartTime = taskDatabase.Get(id).StartTime;
            details.TaskEndTime = taskDatabase.Get(id).EndTime;
            foreach (var item in noteDatabase.GetNotesOfTast(id))
            {
                details.Notes.Add(new Note() { Id = item.Id, TaskId = item.TaskId, NoteText = item.NoteText });
            }
            foreach (var item in documentsDatabase.GetDocumentsOfTast(id))
            {
                details.Documents.Add(new Document() { Id = item.Id, TaskId = item.TaskId });
            }
            foreach (var item in appointmentDatabase.GetAppointmentsOfTast(id))
            {
                details.Appointments.Add(new Appointment() { Id = item.Id, TaskId = item.TaskId });
            }
            
            //}
            //-----------------------------End of details data gathering.
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
