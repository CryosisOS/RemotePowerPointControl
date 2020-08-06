namespace PowerPointHook_Models {
    public class SlideInsert {
        public string _filename { get; set; }
        public int _insertAtIndex { get; set; }
        public int _fromSlide { get; set; }
        public int _toSlide { get; set; }
    }

    public class Presentation {
        public int _choice { get; set; }
        public string _name { get; set; }
    }

    public class Config {
        public Microsoft.Office.Interop.PowerPoint.Application pptApplication { get; set; }

        public Microsoft.Office.Interop.PowerPoint.Presentation presentation { get; set; }
    }
}
