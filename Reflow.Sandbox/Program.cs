using System;
using System.IO;
using ReflowCore.Reflow;

namespace Reflow.Sandbox
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            ReflowController app = new ReflowController();
            app.UpdateFiles(
                "{\r\n  \"Type\": \"AutoIncrementTag\",\r\n  \"StartFrom\": 11,\r\n  \"Skip\": 25,\r\n  \"LeadingZero\": true\r\n}");
            Console.WriteLine(app.GetFilters().Result);
        }
    }
}
