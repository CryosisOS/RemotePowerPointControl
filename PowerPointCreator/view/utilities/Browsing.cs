using System;
using System.Windows.Forms;

namespace PowerPointCreator.view.utilities
{
    public struct SearchResult
    {
        public DialogResult result;
        public string filename;
    }

    public class Browsing
    {
        public static SearchResult BrowseFileSystem()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Program.CONFIG.BROWSING_SETTINGS.default_location;
            dialog.RestoreDirectory = true;
            dialog.AutoUpgradeEnabled = true;
            dialog.Title = "File Selection...";
            dialog.DefaultExt = "pptx";
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;

            //Show Dialogue
            SearchResult searchResult = new SearchResult();
            searchResult.result = dialog.ShowDialog();
            searchResult.filename = dialog.FileName;
            //Get the path of the file
            return searchResult;
        }
    }
}
