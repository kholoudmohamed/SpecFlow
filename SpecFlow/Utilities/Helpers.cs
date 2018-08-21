using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.Utilities
{
    public class Helpers
    {
        public static string GetCurrentProjectPath()
        {
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            return projectPath;
        }
    }
}
