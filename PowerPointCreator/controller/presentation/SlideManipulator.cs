using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace PowerPointCreator.controller.presentation
{
    class SlideManipulator
    {
        // Reserved     1   // Reserved     1
        // Insert       2   // Reserved     2
        // Reserved     3   // Reserved     3
        // Insert       4   // Reserved     4
        // Reserved     5   // Reserved     5
        // Insert       6   // Reserved     6
        // Reserved     7   // Reserved     7
        // Reserved     8   // Reserved     8
        // Insert       9
        // Reserved    10
        // Insert      11
        // Reserved    12
        // Reserved    13

        // Insert After 6
        // Insert After 5
        // Insert After 3
        // Insert After 2
        // Insert After 1

        public static void generatePresentation(Dictionary<string, string> filenames)
        {
            //Initialise PowerPoint app instance
            var app = new PowerPoint.Application();
            var presentations = app.Presentations;

            //Get template
            var template = getPresentation(presentations, /* TODO: Fill this out -- Filename*/ "");
            /*
                KEYS:           VALUES:
                "CONVOCATION",  convocation_path_textBox.Text},
                "PRAISE",       praise_path_textBox.Text},
                "WORSHIP",      worship_path_textBox.Text},
                "RALLYING",     rallying_path_textBox.Text},
                "OFFERING",     offering_path_textBox.Text},
             */
            //Insert into template
            template.Slides.InsertFromFile(filenames["OFFERING"],       6, 1, -1);
            template.Slides.InsertFromFile(filenames["RALLYING"],       5, 1, -1);
            template.Slides.InsertFromFile(filenames["WORSHIP"],        3, 1, -1);
            template.Slides.InsertFromFile(filenames["PRAISE"],         2, 1, -1);
            template.Slides.InsertFromFile(filenames["CONVOCATION"],    1, 1, -1);

            //TODO: Generate Time Stamp
            //TODO: Save file with Time Stamp
            //TODO: Open Presentation in PowerPoint.
        }


        private static PowerPoint.Presentation getPresentation(PowerPoint.Presentations presentations, string filename)
        {
            return presentations.Open(filename, MsoTriState.msoTrue, MsoTriState.msoTrue, MsoTriState.msoFalse);
        }
    }
}
