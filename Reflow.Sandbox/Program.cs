using System;
using System.IO;
using ReflowCore.Reflow;
using System.Threading.Tasks;
using Logger;
using Logger.Contract;

namespace Reflow.Sandbox
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);


            Console.WriteLine(path);
            ReflowController app = new ReflowController();

            Console.WriteLine("FZ");
            Console.WriteLine(app.GetFilesInDirectory(@"D:\CG Stuff\Programming\Projects - Personal\Reflow\").Result);
            app.UpdateFiles("{\r\n  \"Type\": \"AutoIncrementTag\",\r\n  \"StartFrom\": 11,\r\n  \"Skip\": 25,\r\n  \"LeadingZero\": true\r\n}");
            //Console.WriteLine(app.GetFilters().Result);
        }
    }
}
