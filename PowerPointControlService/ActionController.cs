using System.Web.Http;

namespace PowerPointControlService {
    public class ActionController : ApiController {
        public void StartSlideShow() {
            PowerPointInteraction.StartPresentation();
        }

        public void EndSlideShow() {
            PowerPointInteraction.EndPresentation();
        }

        public void NextSlide() {
            PowerPointInteraction.NextSlide();
        }

        public void PreviousSlide() {
            PowerPointInteraction.PreviousSlide();
        }
    }
}
