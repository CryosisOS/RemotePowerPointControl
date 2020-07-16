using Newtonsoft.Json;
using PowerPointCreator.model.settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPointCreator {
    static class Program {
        //GLOBAL REFERENCES
        public static Microsoft.Office.Interop.PowerPoint.Application REF_APPLICATION;
        public static Microsoft.Office.Interop.PowerPoint.Presentation REF_PRESENTATION;

        static private MainForm mainForm;
        internal class config {
            public readonly BrowsingSettings BROWSING_SETTINGS;

            public config() {
                BROWSING_SETTINGS = initialiseBrowsingSettings();
            }

            internal BrowsingSettings initialiseBrowsingSettings() {
                string json = File.ReadAllText(@".\Resources\configurations\browsing_settings.json");
                BrowsingSettings settings = new BrowsingSettings();
                settings = JsonConvert.DeserializeObject<BrowsingSettings>(json);
                return settings;
            }
        };

        public static readonly config CONFIG = new config();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}
