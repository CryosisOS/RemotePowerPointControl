using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using PowerPointHook;
using PowerPointHook_Models;

namespace PowerPointCreator {
    public class ActionController : ApiController {

        public void StartSlideShow() {
            SlideShowControl.StartPresentation(ref Program.REF_PRESENTATION);
        }

        public void EndSlideShow() {
            SlideShowControl.EndPresentation(ref Program.REF_PRESENTATION);
        }

        public void NextSlide() {
            SlideShowControl.NextSlide(ref Program.REF_PRESENTATION);
        }

        public void PreviousSlide() {
            SlideShowControl.PreviousSlide(ref Program.REF_PRESENTATION);
        }
    }
}
