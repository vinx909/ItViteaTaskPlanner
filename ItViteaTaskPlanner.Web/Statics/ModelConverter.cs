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
                foreach (PropertyInfo toProperty in propertysToObject)
                {
                    if(fromProperty.Name == toProperty.Name)
                    {
                        if(fromProperty.PropertyType == toProperty.PropertyType)
                            toProperty.SetValue(toObject, fromProperty.GetValue(fromObject));
                    }
                }
            }

            return toObject;
        }
        public static List<T> Convert<F, T>(List<F> fromObject, List<T> toObject)
        {
            for (int i = 0; i < fromObject.Count(); i++)
            {
                toObject[i] = Convert<F, T>(fromObject[i], toObject[i]);
            }
            return toObject;
        }
    }
}