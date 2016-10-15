using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EF.DAL
{
    public static class Debug
    {
        /// <summary>
        /// Store SQL query in a file
        /// </summary>
        /// <param name="message"></param>
        /// <remarks>could be interesting for the analysis of the execution plan</remarks>
        public static void LogQuery(string message)
        {
            using (var writer = new StreamWriter("log.txt", true))
            {
                writer.Write(message);
            }
        }
    }
}
