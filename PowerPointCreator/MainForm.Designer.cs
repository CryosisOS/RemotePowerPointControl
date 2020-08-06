namespace PowerPointCreator {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.title_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Existing_radioButton = new System.Windows.Forms.RadioButton();
            this.Generate_radioButton = new System.Windows.Forms.RadioButton();
            this.cancel_button = new System.Windows.Forms.Button();
            this.ok_button = new System.Windows.Forms.Button();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_label.Location = new System.Drawing.Point(77, 63);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(295, 33);
            this.title_label.TabIndex = 0;
            this.title_label.Text = "Power Point Creator";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.Existing_radioButton);
            this.panel1.Controls.Add(this.Generate_radioButton);
            this.panel1.Location = new System.Drawing.Point(83, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 104);
            this.panel1.TabIndex = 1;
            // 
            // Existing_radioButton
            // 
            this.Existing_radioButton.AutoSize = true;
            this.Existing_radioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Existing_radioButton.Location = new System.Drawing.Point(4, 34);
            this.Existing_radioButton.Name = "Existing_radioButton";
            this.Existing_radioButton.Size = new System.Drawing.Size(209, 24);
            this.Existing_radioButton.TabIndex = 1;
            this.Existing_radioButton.TabStop = true;
            this.Existing_radioButton.Text = "Use Existing Presentation";
            this.Existing_radioButton.UseVisualStyleBackColor = true;
            // 
            // Generate_radioButton
            // 
            this.Generate_radioButton.AutoSize = true;
            this.Generate_radioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Generate_radioButton.Location = new System.Drawing.Point(4, 4);
            this.Generate_radioButton.Name = "Generate_radioButton";
            this.Generate_radioButton.Size = new System.Drawing.Size(189, 24);
            this.Generate_radioButton.TabIndex = 0;
            this.Generate_radioButton.TabStop = true;
            this.Generate_radioButton.Text = "Generate Presentation";
            this.Generate_radioButton.UseVisualStyleBackColor = true;
            // 
            // cancel_button
            // 
            this.cancel_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_button.Location = new System.Drawing.Point(375, 281);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 2;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // ok_button
            // 
            this.ok_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok_button.Location = new System.Drawing.Point(294, 281);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(75, 23);
            this.ok_button.TabIndex = 3;
            this.ok_button.Text = "OK";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.BalloonTipText = "Double click to open application window";
            this.trayIcon.BalloonTipTitle = "Power Point Creator";
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Power Point Creator";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 316);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.title_label);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.cancel_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton Existing_radioButton;
        private System.Windows.Forms.RadioButton Generate_radioButton;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.NotifyIcon trayIcon;
    }
}