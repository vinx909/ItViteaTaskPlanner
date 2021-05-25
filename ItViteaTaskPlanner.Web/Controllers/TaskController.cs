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
        Data.Services.ITaskData TaskDataBase;

        // GET: Task
        public ActionResult Index()
        {
            TaskDataBase = new InMemoryTaskData();

            return View();
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            Data.Task BackendTask = TaskDataBase.Get(id);
            Task taskDetails = ModelConverter.Convert<Data.Task, Task>(BackendTask, new Task());

            return View(taskDetails);
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
            return View();
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
