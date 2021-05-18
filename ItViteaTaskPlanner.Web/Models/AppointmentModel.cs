using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItViteaTaskPlanner.Web.Models
{
    public enum AppointmentType
    {
        MobileCall,
        OnlineCall,
        Personal
    }

    public class AppointmentModel
    {
        public int Id { get; set; }
        public AppointmentType Type { get; set; }
    }
}