using System;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.PowerPoint;
using SlideMaster;
using SlideMaster_Models;

namespace TestingPowerPointControl
{
    class Program
    {
        static Config config = new Config();
        static void Main(string[] args)
        {
            GetOpenPpt();
            Console.WriteLine("Application Found!");

            foreach (DocumentWindow window in config.pptApplication.Windows)
            {
                Console.WriteLine(window.Caption);
            }

            Console.WriteLine("Please press [Enter] to close...");
            Console.ReadLine();
        }
        public static bool GetOpenPpt()
        {
            bool success = false;
            try
            {
                config.pptApplication = Marshal.GetActiveObject("PowerPoint.Application") as Microsoft.Office.Interop.PowerPoint.Application;
            }
            catch
            {
                //Nothing to put in here
            }
            if (config.pptApplication != null)
            {
                success = true;
            }
            return success;
        }
    }
}
