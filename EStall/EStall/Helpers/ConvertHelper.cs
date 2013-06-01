using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EStall.Helpers
{
    public static class ConvertHelper
    {
        public static T To<T>(this object dbObject)
        {
            T value = default(T);
            if (!(dbObject is DBNull))
            {
                if (typeof(T) == typeof(bool))
                {
                    value = (T)Convert.ChangeType(dbObject.ToString().Equals("S"), typeof(T));
                }
                else
                {
                    value = (T)Convert.ChangeType(dbObject, typeof(T));
                }
            }

            return value;
        }

    }
}