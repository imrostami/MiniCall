
namespace MiniCall
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.start_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inDeviceList = new System.Windows.Forms.ComboBox();
            this.OutDeviceList = new System.Windows.Forms.ComboBox();
            this.MuteBox = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MiniCall = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(185, 100);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(75, 23);
            this.start_btn.TabIndex = 0;
            this.start_btn.Text = "Start";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input Device : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output Device : ";
            // 
            // inDeviceList
            // 
            this.inDeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inDeviceList.FormattingEnabled = true;
            this.inDeviceList.Location = new System.Drawing.Point(100, 22);
            this.inDeviceList.Name = "inDeviceList";
            this.inDeviceList.Size = new System.Drawing.Size(160, 21);
            this.inDeviceList.TabIndex = 3;
            this.inDeviceList.SelectedIndexChanged += new System.EventHandler(this.inDeviceList_SelectedIndexChanged);
            // 
            // OutDeviceList
            // 
            this.OutDeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OutDeviceList.FormattingEnabled = true;
            this.OutDeviceList.Location = new System.Drawing.Point(100, 58);
            this.OutDeviceList.Name = "OutDeviceList";
            this.OutDeviceList.Size = new System.Drawing.Size(160, 21);
            this.OutDeviceList.TabIndex = 4;
            this.OutDeviceList.SelectedIndexChanged += new System.EventHandler(this.OutDeviceList_SelectedIndexChanged);
            // 
            // MuteBox
            // 
            this.MuteBox.AutoSize = true;
            this.MuteBox.Enabled = false;
            this.MuteBox.Location = new System.Drawing.Point(12, 104);
            this.MuteBox.Name = "MuteBox";
            this.MuteBox.Size = new System.Drawing.Size(109, 17);
            this.MuteBox.TabIndex = 5;
            this.MuteBox.Text = "Mute Microphone";
            this.MuteBox.UseVisualStyleBackColor = true;
            this.MuteBox.CheckedChanged += new System.EventHandler(this.MuteBox_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MiniCall
            // 
            this.MiniCall.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.MiniCall.Text = "Notfication";
            this.MiniCall.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 138);
            this.Controls.Add(this.MuteBox);
            this.Controls.Add(this.OutDeviceList);
            this.Controls.Add(this.inDeviceList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.start_btn);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "MiniCall";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox inDeviceList;
        private System.Windows.Forms.ComboBox OutDeviceList;
        private System.Windows.Forms.CheckBox MuteBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon MiniCall;
    }
}

