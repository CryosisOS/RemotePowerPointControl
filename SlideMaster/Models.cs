namespace SlideMaster_Models {
    public class Presentation {
        public int _choice { get; set; }
        public string _name { get; set; }
    }

    public class Config {
        public Microsoft.Office.Interop.PowerPoint.Application pptApplication { get; set; }

        public Microsoft.Office.Interop.PowerPoint.Presentation presentation { get; set; }
    }
}
