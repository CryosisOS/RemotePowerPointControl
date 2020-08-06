using Microsoft.Office.Interop.PowerPoint;
using RestSharp;
using System.Diagnostics;

namespace PowerPointHook {
    public class SlideShowObserver {
        public Slide PreviousSlide { get; private set; }
        public Slide CurrentSlide { get; private set; }
        public Slide NextSlide { get; private set; }

        private string broadcast_url { get; set; }

        private int count;
        //Instantiate Observer methods
        public SlideShowObserver(ref Application application, ref Presentation presentation, string BROADCAST_URL) {
            count = presentation.Slides.Count;
            application.SlideShowBegin += Event_BeginSlideShow;
            application.SlideShowEnd += Event_EndSlideShow;
            application.SlideShowNextSlide += Event_NextSlide;
            this.broadcast_url = BROADCAST_URL;
        }

        /// <summary>
        /// Occures whenever a presentation starts
        /// </summary>
        /// <param name="window"></param>
        private void Event_BeginSlideShow(SlideShowWindow window) {
            count = window.Presentation.Slides.Count;
            Debug.WriteLine("Event: Begin Slide Show has occured");
            RestClient client = new RestClient(this.broadcast_url);
            RestRequest request = new RestRequest("Broadcast/NetworkEvent_SlideShowStart");
            IRestResponse response = client.Post(request);
        }

        /// <summary>
        /// Occures whenever a presentation ends
        /// </summary>
        /// <param name="window"></param>
        private void Event_EndSlideShow(Presentation presentation) {
            Debug.WriteLine("Event: End Slide Show has occured");
            RestClient client = new RestClient(this.broadcast_url);
            RestRequest request = new RestRequest("Broadcast/NetworkEvent_SlideShowEnd");
            IRestResponse response = client.Post(request);
        }

        /// <summary>
        /// Occurs whenever a transition between slides is made either forwards or backwards.
        /// </summary>
        /// <param name="window"></param>
        private void Event_NextSlide(SlideShowWindow window) {
            count = window.Presentation.Slides.Count;
            int currentIndex = window.View.Slide.SlideIndex;
            int prevIndex = currentIndex - 1;
            int nextIndex = currentIndex + 1;
            this.PreviousSlide = (currentIndex == 1) ? null : window.Presentation.Slides[prevIndex];
            this.CurrentSlide = window.Presentation.Slides[currentIndex];
            this.NextSlide = (currentIndex == count) ? null : window.Presentation.Slides[nextIndex];
            RestClient client = new RestClient(this.broadcast_url);
            RestRequest request = new RestRequest("Broadcast/NetworkEvent_SlideChange");
            IRestResponse response = client.Post(request);
        }
    }
}
