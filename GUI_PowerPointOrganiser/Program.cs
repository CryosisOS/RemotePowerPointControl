using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using GUI_PowerPointOrganiser.model.settings;
using Newtonsoft.Json;

namespace GUI_PowerPointOrganiser
{
    static class Program
    {
        internal class config
        {
            public readonly BrowsingSettings BROWSING_SETTINGS;

            public config()
            {
                BROWSING_SETTINGS = initialiseBrowsingSettings();
            }

            internal BrowsingSettings initialiseBrowsingSettings()
            {
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
        static void Main()
        {
            Console.WriteLine("Default Location: " + CONFIG.BROWSING_SETTINGS.default_location);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PowerPointGenerationForm());
        }
    }
}
