using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DAL
{
    public static class Debug
    {
        public static void LogQuery(string message)
        {
            using (var writer = new StreamWriter("log.txt", true))
            {
                writer.Write(message);
            }
        }
    }
}
