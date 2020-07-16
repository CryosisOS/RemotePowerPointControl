using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.PowerPoint;
using System.Collections.Generic;
using PowerPointHook_Models;
using System;

namespace PowerPointHook {


    public class SlideShowControl {
        public static bool StartPresentation(ref PowerPoint.Presentation presentation) {
            try {
                presentation.SlideShowSettings.Run();
                return true;
            }
            catch {
                return false;
            }
        }

        public static bool EndPresentation(ref PowerPoint.Presentation presentation) {
            try {
                presentation.SlideShowWindow.View.Exit();
                return true;
            }
            catch {
                return false;
            }
        }

        public static bool NextSlide(ref PowerPoint.Presentation presentation) {
            try {
                presentation.SlideShowWindow.View.Next();
                return true;
            }
            catch {
                return false;
            }
        }

        public static bool PreviousSlide(ref PowerPoint.Presentation presentation) {
            try {
                presentation.SlideShowWindow.View.Previous();
                return true;
            }
            catch {
                return false;
            }
        }
    }
}
