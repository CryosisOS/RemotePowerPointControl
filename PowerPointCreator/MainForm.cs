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

            }
            else if(chosen.Name.Equals(this.Existing_radioButton.Name)){
                OpenFileDialog fileChooser = GetFileChooser("Browse for Presentation");
                DialogResult result = fileChooser.ShowDialog();
                if (result == DialogResult.OK) {
                    var application = PowerPointControl.CreatePowerPointApplication();
                    PowerPointControl.StartExistingPresentation(ref application, fileChooser.FileName);
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
            trayIcon.BalloonTipText = "Application Minimized.";
        }
    }
}
