using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication.Helpers
{
    public static class GitCommit
    {

        /// <summary>
        /// When the application is deployed, Kudu writes a file containing the active
        /// git hash.  For convenience this helper allows it to be pulled into the
        /// interface.
        /// </summary>
        /// <returns></returns>
        public static string Hash()
        {
            string active = "//";
            if (Environment.GetEnvironmentVariable("HOME") != null)
            {
                active = Environment.GetEnvironmentVariable("HOME").ToString() + "//site//deployments//active";
            }
            string contents = "In development, no hash file found.";
            if (System.IO.File.Exists(active))
            {
                StreamReader reader = new StreamReader(active);
                contents = reader.ReadToEnd();
                reader.Close();
            }
            return contents;
        }
    }
}