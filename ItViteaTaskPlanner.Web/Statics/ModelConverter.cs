using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ItViteaTaskPlanner.Web.Statics
{
    public static class ModelConverter
    {
        public static T Convert<F,T>(F fromObject, T toObject)
        {
            Type typeFromObject = fromObject.GetType();
            Type typeToObject = toObject.GetType();

            PropertyInfo[] propertysFromObject = typeFromObject.GetProperties();
            PropertyInfo[] propertysToObject = typeToObject.GetProperties();

            foreach (PropertyInfo fromProperty in propertysFromObject)
            {
                foreach (PropertyInfo toProperty in propertysFromObject)
                {
                    if(fromProperty.Name == toProperty.Name)
                    {
                        toProperty.SetValue(toObject, fromProperty.GetValue(fromObject));
                    }
                }
            }

            return toObject;
        }
    }
}