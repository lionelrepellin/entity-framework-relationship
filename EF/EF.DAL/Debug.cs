using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
