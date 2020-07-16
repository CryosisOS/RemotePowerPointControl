using Microsoft.Office.Core;
using PowerPointHook_Models;

namespace PowerPointHook {
    public class PowerPointControl {
        public static Microsoft.Office.Interop.PowerPoint.Application OpenPowerPointApplication() {
            return new Microsoft.Office.Interop.PowerPoint.Application();
        }

        public static Microsoft.Office.Interop.PowerPoint.Presentation CreateNewPresentation(
            ref Microsoft.Office.Interop.PowerPoint.Application application, string template_filename) {
            return application.Presentations.Open(template_filename, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoFalse);
        }

        public static void InsertSlide(ref Microsoft.Office.Interop.PowerPoint.Presentation presentation, SlideInsert slides) {
            presentation.Slides.InsertFromFile(slides._filename, slides._insertAtIndex, slides._fromSlide, slides._toSlide);
        }

        public static void SavePresentation(ref Microsoft.Office.Interop.PowerPoint.Presentation presentation, string filename) {
            presentation.SaveAs(filename);
        }

        public static Microsoft.Office.Interop.PowerPoint.Presentation StartExistingPresentation(
            ref Microsoft.Office.Interop.PowerPoint.Application application, string filename) {
            return application.Presentations.Open(filename, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);
        }
    }
}
