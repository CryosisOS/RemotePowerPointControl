using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.PowerPoint;
using System.Collections.Generic;
using PowerPointHook_Models;
using System;

namespace PowerPointHook {


    public class SlideShowControl {
        public static bool GetOpenPpt(Config config) {
            bool success = false;
            try
            {
                config.pptApplication = Marshal.GetActiveObject("PowerPoint.Application") as Microsoft.Office.Interop.PowerPoint.Application;
            }
            catch
            {
                
            }
            if (config.pptApplication != null)
            {
                success = true;
            }
            return success;
        }

        public static List<PowerPointHook_Models.Presentation> GetPresentationList(Config config) {
            int count = 0;
            List<PowerPointHook_Models.Presentation> presentations = new List<PowerPointHook_Models.Presentation>();
            foreach (DocumentWindow window in config.pptApplication.Windows) {
                presentations.Add(new PowerPointHook_Models.Presentation { _choice = ++count, _name = window.Caption });
            }
            return presentations;
        }

        public static bool SelectPresentation(Config config, PowerPointHook_Models.Presentation presentationChoice) {
            try {
                config.presentation = config.pptApplication.Windows[presentationChoice._choice].Presentation;
                return true;
            }
            catch {
                return false;
            }
        }


        public static bool StartPresentation(Config config) {
            try {
                config.presentation.SlideShowSettings.Run();
                return true;
            }
            catch {
                return false;
            }
        }

        public static bool EndPresentation(Config config) {
            try {
                config.pptApplication.SlideShowWindows[1].View.Exit();
                return true;
            }
            catch {
                return false;
            }
        }

        public static bool NextSlide(Config config) {
            try {
                config.presentation.SlideShowWindow.View.Next();
                return true;
            }
            catch {
                return false;
            }
        }

        public static bool PreviousSlide(Config config) {
            try {
                config.presentation.SlideShowWindow.View.Previous();
                return true;
            }
            catch {
                return false;
            }
        }
    }
}
