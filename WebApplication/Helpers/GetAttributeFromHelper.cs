using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Helpers
{
    public static class GetAttributeFromHelper
    {
        public static T GetAttributeFrom<T>(this object instance, string propertyName) where T : Attribute
        {
            var attrType = typeof(T);
            var property = instance.GetType().GetProperty(propertyName);
            var attributes = property.GetCustomAttributes(attrType, false);
            if (attributes.Length == 0) { return null; }
            return (T)property.GetCustomAttributes(attrType, false).First();
        }
    }
}