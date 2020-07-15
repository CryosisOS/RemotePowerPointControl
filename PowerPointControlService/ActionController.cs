using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SlideMaster;
using SlideMaster_Models;

namespace PowerPointControlService {
    public class ActionController : ApiController {
        public string RefreshApplicationEndPoint() {
            if (PowerPointInteraction.GetOpenPpt()) {
                return "Refreshed";
            }
            else {
                return "Failed";
            }
        }

        public IEnumerable<Presentation> GetPresentations() {
            IEnumerable<Presentation> presentations = null;
            presentations = PowerPointInteraction.GetPresentationList();
            //The list contained 0 items
            if (presentations.ToArray().Length == 0) {
                return null;
            }
            //Found a list of at least 1 or more items.
            return presentations;
        }

        public void SelectPresentation(int choice, string name) {
            PowerPointInteraction.SelectPresentation(new Presentation { _choice = choice, _name = name });
        }

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
