using Microsoft.Office.Interop.PowerPoint;
using System.Diagnostics;

namespace PowerPointHook {
    public class SlideShowObserver {
        public Slide PreviousSlide { get; private set; }
        public Slide CurrentSlide { get; private set; }
        public Slide NextSlide { get; private set; }

        private int count;
        //Instantiate Observer methods
        public SlideShowObserver(ref Application application, ref Presentation presentation) {
            count = presentation.Slides.Count;
            application.SlideShowBegin += Event_BeginSlideShow;
            application.SlideShowNextSlide += Event_NextSlide;
        }

        /// <summary>
        /// Occures whenever a presentation starts
        /// </summary>
        /// <param name="window"></param>
        private void Event_BeginSlideShow(SlideShowWindow window) {
            count = window.Presentation.Slides.Count;
            Debug.WriteLine("Event: Begin Slide Show has occured");
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
            Debug.WriteLine("Event: Next Slide Show has occured");
        }
    }
}
