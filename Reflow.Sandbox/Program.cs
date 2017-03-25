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
            Console.WriteLine(app.GetFilesInDirectory("E:\\Downloads\\Network").Result);

            Console.WriteLine("ADDING TAG ======");
            app.AddTag("TestAfk");

            Console.WriteLine("RETURNING TAGS");
            Console.WriteLine(app.GetTags().Result);
        }
    }
}
