using System;
using System.Reflection;

namespace Sodiqwebapplication.Utils
{
    public class Util
    {
        private Util()
        {
        }
        public static void propertyCopy(Object source,Object destination){
            var sourceProperties = source.GetType().GetProperties();
            foreach (var property in sourceProperties)
            {
                var value = property.GetValue(source);
                if (value == null)
                {
                    continue;
                }
                PropertyInfo prop = destination.GetType().GetProperty(property.Name, BindingFlags.Public | BindingFlags.Instance);

                if (null != prop && prop.CanWrite && prop.PropertyType.Equals(property.PropertyType))
                {
                    prop.SetValue(destination, value, null);
                }
            }
        }
    }
}
