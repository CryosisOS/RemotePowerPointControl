using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using SlideMaster_Models;
using System.Net.Http;

namespace PowerPointControlService {
    static class Program {
        public static readonly Config CONFIGURATION = new Config();
        public static Microsoft.Office.Interop.PowerPoint.Application pptApplication { get; set; }
        public static Microsoft.Office.Interop.PowerPoint.Presentation presentation { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string [] args) {
            string baseAddress = "http://localhost:9000/";
            WebApp.Start<API>(url: baseAddress);
            //using (WebApp.Start<RegisterAPI>(url: baseAddress)) {
            //    // Create HttpClient and make a request to api/values 
            //    HttpClient client = new HttpClient();
            //    var response = client.PostAsync(baseAddress + "api/Action/RefreshApplicationEndPoint", null).Result;
            //    Console.WriteLine(response);
            //    response = client.GetAsync(baseAddress + "api/Action/GetPresentations").Result;
            //
            //    Console.WriteLine(response);
            //    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            //    Console.ReadLine();
            //}
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new PowerPointControl()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
