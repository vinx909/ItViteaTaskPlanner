using ItViteaTaskPlanner.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItViteaTaskPlanner.Web.Controllers
{
    public class TaskController : Controller
    {
        List<TaskModel> testData;

        private void FillTestData()
        {
            testData = new List<TaskModel>();
            testData.Add(new TaskModel { Id = 0, Title = "title id 0", Discription = "this task is shit", Type = 0, AppointmentIds = new int[0], DocumentIds = new int[0], StartTime = DateTime.Now, EndTime = DateTime.Now });
            testData.Add(new TaskModel { Id = 1, Title = "title id 1", Discription = "this task is also shit", Type = 0, AppointmentIds = new int[0], DocumentIds = new int[0], StartTime = DateTime.Now, EndTime = DateTime.Now });
            testData.Add(new TaskModel { Id = 2, Title = "title id 2", Discription = "i will fire myself so i dont have to do this task", Type = 1, AppointmentIds = new int[0], DocumentIds = new int[0], StartTime = DateTime.Now, EndTime = DateTime.Now });
            testData.Add(new TaskModel { Id = 3, Title = "title id 3", Discription = "...", Type = 2, AppointmentIds = new int[0], DocumentIds = new int[0], StartTime = DateTime.Now, EndTime = DateTime.Now });

        }

        // GET: Task
        public ActionResult Index()
        {
            FillTestData();
            return View(testData);
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            FillTestData();
            TaskModel taskDetails = testData.First(t => t.Id == id);
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
