using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItViteaTaskPlanner.Data
{
    public class FieldNameAttribute : Attribute
    {
        public string StringValue { get; protected set; }
        
        public FieldNameAttribute(string value)
        {
            this.StringValue = value;
        }
    }
}