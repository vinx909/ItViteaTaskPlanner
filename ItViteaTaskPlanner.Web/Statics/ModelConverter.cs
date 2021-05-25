using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using ItViteaTaskPlanner.Data;

namespace ItViteaTaskPlanner.Web.Statics
{
    public static class ModelConverter
    {
        /// <summary>
        /// Convert fromObject to toObject
        /// Based on nothing but there own name
        /// </summary>
        /// <typeparam name="F"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="fromObject"></param>
        /// <param name="toObject"></param>
        /// <returns></returns>
        public static T Convert<F, T>(F fromObject, T toObject)
        {
            Type typeFromObject = fromObject.GetType();
            Type typeToObject = toObject.GetType();

            PropertyInfo[] propertysFromObject = typeFromObject.GetProperties();
            PropertyInfo[] propertysToObject = typeToObject.GetProperties();

            foreach (PropertyInfo fromProperty in propertysFromObject)
            {
                foreach (PropertyInfo toProperty in propertysToObject)
                {
                    if (fromProperty.Name == toProperty.Name)
                    {
                        if (fromProperty.PropertyType == toProperty.PropertyType)
                            toProperty.SetValue(toObject, fromProperty.GetValue(fromObject));
                    }
                }
            }

            return toObject;
        }

        /// <summary>
        /// Convert fromObject to toObject
        /// That have the same FieldNameAttribute string.
        /// </summary>
        /// <typeparam name="F"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="fromObject"></param>
        /// <param name="toObject"></param>
        /// <returns></returns>
        public static T ConvertByAttribute<F, T>(F fromObject, T toObject)
        {
            Type typeFromObject = fromObject.GetType();
            Type typeToObject = toObject.GetType();

            PropertyInfo[] propertysFromObject = typeFromObject.GetProperties();
            PropertyInfo[] propertysToObject = typeToObject.GetProperties();

            foreach (PropertyInfo fromProperty in propertysFromObject)
            {
                if (!Attribute.IsDefined(fromProperty, typeof(FieldNameAttribute)))
                {
                    continue;
                }

                foreach (PropertyInfo toProperty in propertysToObject)
                {
                    if (!Attribute.IsDefined(toProperty, typeof(FieldNameAttribute)))
                    {
                        continue;
                    }

                    if (fromProperty.GetCustomAttribute<FieldNameAttribute>().StringValue == toProperty.GetCustomAttribute<FieldNameAttribute>().StringValue)
                    {
                        if (fromProperty.PropertyType == toProperty.PropertyType)
                        {
                            toProperty.SetValue(toObject, fromProperty.GetValue(fromObject));
                        }
                    }
                }
            }
            return toObject;
        }
    }
}