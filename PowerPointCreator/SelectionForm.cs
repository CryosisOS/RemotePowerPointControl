using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PowerPointCreator.view.utilities;

namespace PowerPointCreator
{
    public partial class SelectionForm : Form
    {
        public SelectionForm()
        {
            InitializeComponent();
        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> filenames = new Dictionary<string, string>{
                {"CONVOCATION", convocation_path_textBox.Text},
                {"PRAISE", praise_path_textBox.Text},
                {"WORSHIP", worship_path_textBox.Text},
                {"RALLYING", rallying_path_textBox.Text},
                {"OFFERING", offering_path_textBox.Text},
            };
            foreach(string key in filenames.Keys)
            {
                Console.WriteLine(key);
                if (filenames[key].Equals("") || filenames[key] == null || filenames[key].Equals(" path to file..."))
                {
                    var confirmResult = MessageBox.Show(string.Format("You have left the path for {0} blank", key), "Do you wish to proceed?", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        //TODO: continue
                    }
                    else
                    {
                        //DO nothing... yet
                    }
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Sets the textbox text to the filepath of the file that is selected.
        //For the Convocation group.
        private void Convocation_browse_button_Click(object sender, EventArgs e)
        {
            updateTextBoxOnBrowse(convocation_path_textBox);
        }

        //Clears the textbox text and resets it to default.
        //For the Convocation group.
        private void convocation_clear_button_Click(object sender, EventArgs e)
        {
            updateTextBoxOnClear(convocation_path_textBox);
        }

        //Sets the textbox text to the filepath of the file that is selected.
        //For the Praise group.
        private void Praise_browse_button_Click(object sender, EventArgs e)
        {
            updateTextBoxOnBrowse(praise_path_textBox);
        }

        //Clears the textbox text and resets it to default.
        //For the Praise group.
        private void praise_clear_button_Click(object sender, EventArgs e)
        {
            updateTextBoxOnClear(praise_path_textBox);
        }

        //Sets the textbox text to the filepath of the file that is selected.
        //For the Worship group.
        private void Worship_browse_button_Click(object sender, EventArgs e)
        {
            updateTextBoxOnBrowse(worship_path_textBox);
        }

        //Clears the textbox text and resets it to default.
        //For the Worship group.
        private void worship_clear_button_Click(object sender, EventArgs e)
        {
            updateTextBoxOnClear(worship_path_textBox);
        }

        //Sets the textbox text to the filepath of the file that is selected.
        //For the Rallying group.
        private void Rallying_browse_button_Click(object sender, EventArgs e)
        {
            updateTextBoxOnBrowse(rallying_path_textBox);
        }

        //Clears the textbox text and resets it to default.
        //For the Rallying group.
        private void rallying_clear_button_Click(object sender, EventArgs e)
        {
            updateTextBoxOnClear(rallying_path_textBox);
        }

        //Sets the textbox text to the filepath of the file that is selected.
        //For the Offering group.
        private void Offering_browse_button_Click(object sender, EventArgs e)
        {
            updateTextBoxOnBrowse(offering_path_textBox);
        }

        //Clears the textbox text and resets it to default.
        //For the Offering group.
        private void offering_clear_button_Click(object sender, EventArgs e)
        {
            updateTextBoxOnClear(offering_path_textBox);
        }

        private void updateTextBoxOnClear(TextBox context)
        {
            context.Text = " path to file...";
            context.ForeColor = Color.Gray;
            context.Font = new Font(context.Font, FontStyle.Italic);
        }

        private void updateTextBoxOnBrowse(TextBox context)
        {
            SearchResult result = Browsing.BrowseFileSystem();
            if(result.result == DialogResult.OK)
            {
                context.Text = result.filename;
                context.ForeColor = Color.Black;
                context.Font = new Font(context.Font, FontStyle.Regular);
            }
        }

    }
}
