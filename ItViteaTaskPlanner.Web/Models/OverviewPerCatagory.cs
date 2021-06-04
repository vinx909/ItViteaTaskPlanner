using ItViteaTaskPlanner.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItViteaTaskPlanner.Web.Models
{
    public class OverviewPerCatagory
    {
        public OverviewPerCatagory(ICategoryData categoryData)
        {
            TasksPerCatagories = new List<TasksPerCatagory>();
            foreach (Data.Category category in categoryData.GetAll())
            {
                TasksPerCatagories.Add(new TasksPerCatagory(category));
            }
        }

        public List<TasksPerCatagory> TasksPerCatagories{get; set;}

        public class TasksPerCatagory
        {
            public Category Category { get; set; }
            public List<Overview> Overviews { get; set; }

            public TasksPerCatagory(Data.Category category)
            {
                Category = new Category(category);
                Overviews = new List<Overview>();
                if(category.Tasks != null)
                {
                    foreach (Data.Task task in category.Tasks)
                    {
                        Overviews.Add(new Overview(task));
                    }
                }
            }
        }
    }
}