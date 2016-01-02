using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public static class ObjectExtension
    {
        public static string ShowProperties(this Object obj, int nbChars = 0)
        {
            var info = string.Format("Obj: {0}", obj.GetType().Name + Environment.NewLine + Environment.NewLine);
            foreach (var prop in obj.GetType().GetProperties())
            {
                info += string.Format("{3}{0}: {1}{2}", prop.Name, prop.GetValue(obj, null), Environment.NewLine, "".PadLeft(nbChars, ' '));
            }
            info += Environment.NewLine;
            return info;
        }
    }    
}