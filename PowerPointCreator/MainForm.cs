using System;
using System.Linq;
using System.Windows.Forms;
using PowerPointHook;

namespace PowerPointCreator {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void cancel_button_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void ok_button_Click(object sender, EventArgs e) {
            RadioButton chosen = this.panel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (chosen.Name.Equals(this.Generate_radioButton.Name)) {
                //Start SelectionForm
            }
            else if(chosen.Name.Equals(this.Existing_radioButton.Name)){
                OpenFileDialog fileChooser = GetFileChooser("Browse for Presentation");
                DialogResult result = fileChooser.ShowDialog();
                if (result == DialogResult.OK) {
                    //Open PowerPoint with the existing presentation
                    Program.REF_APPLICATION = PowerPointControl.OpenPowerPointApplication();
                    Program.REF_PRESENTATION = PowerPointControl.StartExistingPresentation(ref Program.REF_APPLICATION, fileChooser.FileName);
                    SlideShowObserver observer = new SlideShowObserver(ref Program.REF_APPLICATION, ref Program.REF_PRESENTATION, "http://localhost/powerpointcontrol");
                    //Start API
                    API.Register();
                    //Hide window
                    WindowState = FormWindowState.Minimized;
                }
            }
            else {
                throw new NotSupportedException("This functionality should never be reached");
            }
        }

        private OpenFileDialog GetFileChooser(string title) {
            OpenFileDialog fileChooser = new OpenFileDialog();
            fileChooser.InitialDirectory = Program.CONFIG.BROWSING_SETTINGS.default_location;
            fileChooser.Title = title;
            fileChooser.Filter = Program.CONFIG.BROWSING_SETTINGS.file_types;
            fileChooser.CheckFileExists = true;
            fileChooser.CheckPathExists = true;
            return fileChooser;
        }


        //Minimise Events
        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void MainForm_Resize(object sender, EventArgs e) {
            if (WindowState == FormWindowState.Minimized) {
                Hide();
            }
        }

        private void MainForm_Load(object sender, EventArgs e) {
            trayIcon.BalloonTipText = "Application window active.";
        }
    }
}
