using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using SlideMaster;
using SlideMaster_Models;

namespace WebServer.Controllers {
    public class EndPointsController : ApiController {
        [HttpPost]
        public IHttpActionResult RefreshApplicationEndPoint() {
            if (LocalSystem.GetOpenPpt(WebApiApplication.CONFIGURATION)) {
                return Ok();
            }
            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult GetPresentations() {
            if (!LocalSystem.GetOpenPpt(WebApiApplication.CONFIGURATION))
            {
                return NotFound();
            }
            IList<Presentation> presentations = null;
            presentations = LocalSystem.GetPresentationList(WebApiApplication.CONFIGURATION);
            //The list contained 0 items
            if (presentations.Count == 0) {
                return NotFound();
            }
            //Found a list of at least 1 or more items.
            return Ok(presentations);
        }

        [HttpPost]
        public IHttpActionResult SelectPresentation(int choice, string name) {
            bool choiceResult = LocalSystem.SelectPresentation(WebApiApplication.CONFIGURATION, new Presentation { _choice = choice, _name = name });
            if (choiceResult) {
                return Ok();
            }
            else {
                return NotFound();
            }
        }

        [HttpPost]
        public IHttpActionResult StartSlideShow() {
            bool choiceResult = LocalSystem.StartPresentation(WebApiApplication.CONFIGURATION);
            if (choiceResult) {
                return Ok();
            }
            else {
                return NotFound();
            }
        }

        [HttpPost]
        public IHttpActionResult EndSlideShow() {
            bool choiceResult = LocalSystem.EndPresentation(WebApiApplication.CONFIGURATION);
            if (choiceResult) {
                return Ok();
            }
            else {
                return NotFound();
            }
        }

        [HttpPost]
        public IHttpActionResult NextSlide() {
            bool choiceResult = LocalSystem.NextSlide(WebApiApplication.CONFIGURATION);
            if (choiceResult) {
                return Ok();
            }
            else {
                return NotFound();
            }
        }

        [HttpPost]
        public IHttpActionResult PreviousSlide() {
            bool choiceResult = LocalSystem.PreviousSlide(WebApiApplication.CONFIGURATION);
            if (choiceResult) {
                return Ok();
            }
            else {
                return NotFound();
            }
        }
    }
}