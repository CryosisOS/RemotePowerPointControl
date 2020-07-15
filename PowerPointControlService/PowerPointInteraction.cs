using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.PowerPoint;
using System.Collections.Generic;

namespace PowerPointControlService {


    public class PowerPointInteraction {
        public static bool GetOpenPpt() {
            bool success = false;
            try {
                Program.pptApplication = Marshal.GetActiveObject("PowerPoint.Application") as Microsoft.Office.Interop.PowerPoint.Application;
            }
            catch {

            }
            if (Program.pptApplication != null) {
                success = true;
            }
            return success;
        }

        public static List<SlideMaster_Models.Presentation> GetPresentationList() {
            int count = 0;
            List<SlideMaster_Models.Presentation> presentations = new List<SlideMaster_Models.Presentation>();
            foreach (DocumentWindow window in Program.pptApplication.Windows) {
                presentations.Add(new SlideMaster_Models.Presentation { _choice = ++count, _name = window.Caption });
            }
            return presentations;
        }

        public static bool SelectPresentation(SlideMaster_Models.Presentation presentationChoice) {
            try {
                Program.presentation = Program.pptApplication.Windows[presentationChoice._choice].Presentation;
                return true;
            }
            catch {
                return false;
            }
        }


        public static bool StartPresentation() {
            try {
                Program.presentation.SlideShowSettings.Run();
                return true;
            }
            catch {
                return false;
            }
        }

        public static bool EndPresentation() {
            try {
                //Could possibly use Program.pptApplication.SlideShowWindows to get active slideshows
                Program.pptApplication.SlideShowWindows[1].View.Exit();
                return true;
            }
            catch {
                return false;
            }
        }

        public static bool NextSlide() {
            try {
                Program.presentation.SlideShowWindow.View.Next();
                return true;
            }
            catch {
                return false;
            }
        }

        public static bool PreviousSlide() {
            try {
                Program.presentation.SlideShowWindow.View.Previous();
                return true;
            }
            catch {
                return false;
            }
        }
    }
}
