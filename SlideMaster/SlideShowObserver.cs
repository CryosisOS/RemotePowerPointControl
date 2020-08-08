using Microsoft.Office.Interop.PowerPoint;
using RestSharp;
using System.Diagnostics;
using System.Dynamic;
using System.Threading;

namespace PowerPointHook {
    public class SlideShowObserver {
        public Slide PreviousSlide { get; private set; }
        public Slide CurrentSlide { get; private set; }
        public Slide NextSlide { get; private set; }

        private string broadcast_url { get; set; }
        private RestClient client { get; set; }

        private int count;

        private bool started = false;
        private bool next_slide_mutex = false;
        //Instantiate Observer methods
        public SlideShowObserver(ref Application application, ref Presentation presentation, string BROADCAST_URL) {
            count = presentation.Slides.Count;
            application.SlideShowBegin += Event_BeginSlideShow;
            application.SlideShowNextSlide += Event_NextSlide;
            application.SlideShowEnd += Event_EndSlideShow;
            this.broadcast_url = BROADCAST_URL;
            client = new RestClient(this.broadcast_url);
            started = false;
            next_slide_mutex = false;
        }

        /// <summary>
        /// Occures whenever a presentation starts
        /// </summary>
        /// <param name="window"></param>
        private void Event_BeginSlideShow(SlideShowWindow window) {
            //count = window.Presentation.Slides.Count;
            if(started == false) {
                started = true;
                Thread thread = new Thread(() => {
                    Debug.WriteLine("Event: Begin Slide Show has occured");
                    RestRequest request = new RestRequest("Broadcast/NetworkEvent_SlideShowStart");
                    client.Post(request);
                });
                thread.Start();
            }
        }

        /// <summary>
        /// Occures whenever a presentation ends
        /// </summary>
        /// <param name="window"></param>
        private void Event_EndSlideShow(Presentation presentation) {
            if (started == true) {
                started = false;
                Thread thread = new Thread(() => {
                    Debug.WriteLine("Event: End Slide Show has occured");
                    RestRequest request = new RestRequest("Broadcast/NetworkEvent_SlideShowEnd");
                    client.Post(request);
                });
                thread.Start();
            }
        }

        /// <summary>
        /// Occurs whenever a transition between slides is made either forwards or backwards.
        /// </summary>
        /// <param name="window"></param>
        private void Event_NextSlide(SlideShowWindow window) {
            //count = window.Presentation.Slides.Count;
            //int currentIndex = window.View.Slide.SlideIndex;
            //int prevIndex = currentIndex - 1;
            //int nextIndex = currentIndex + 1;
            //this.PreviousSlide = (currentIndex == 1) ? null : window.Presentation.Slides[prevIndex];
            //this.CurrentSlide = window.Presentation.Slides[currentIndex];
            //this.NextSlide = (currentIndex == count) ? null : window.Presentation.Slides[nextIndex];
            if (next_slide_mutex == false) {
                next_slide_mutex = true;
                Thread thread = new Thread(() => {
                    Debug.WriteLine("Event: Next Slide Show has occured");
                    RestRequest request = new RestRequest("Broadcast/NetworkEvent_SlideChange");
                    client.Post(request);
                    next_slide_mutex = false;
                });
                thread.Start();
            }
        }
    }
}
