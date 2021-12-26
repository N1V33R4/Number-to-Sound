
namespace Number_to_Sound
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
            this.instructionLabel = new System.Windows.Forms.Label();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.readButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.robotVoiceRadio = new System.Windows.Forms.RadioButton();
            this.satyaVoiceRadio = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // instructionLabel
            // 
            this.instructionLabel.AutoSize = true;
            this.instructionLabel.Location = new System.Drawing.Point(111, 54);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(106, 17);
            this.instructionLabel.TabIndex = 0;
            this.instructionLabel.Text = "Enter a number";
            // 
            // numberTextBox
            // 
            this.numberTextBox.Location = new System.Drawing.Point(223, 51);
            this.numberTextBox.Multiline = true;
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(106, 22);
            this.numberTextBox.TabIndex = 1;
            // 
            // readButton
            // 
            this.readButton.Location = new System.Drawing.Point(148, 146);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(83, 64);
            this.readButton.TabIndex = 2;
            this.readButton.Text = "Read";
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Location = new System.Drawing.Point(232, 178);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(83, 32);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.stopButton.Location = new System.Drawing.Point(232, 146);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(83, 32);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // robotVoiceRadio
            // 
            this.robotVoiceRadio.AutoSize = true;
            this.robotVoiceRadio.Checked = true;
            this.robotVoiceRadio.Location = new System.Drawing.Point(162, 112);
            this.robotVoiceRadio.Name = "robotVoiceRadio";
            this.robotVoiceRadio.Size = new System.Drawing.Size(67, 21);
            this.robotVoiceRadio.TabIndex = 5;
            this.robotVoiceRadio.TabStop = true;
            this.robotVoiceRadio.Text = "Robot";
            this.robotVoiceRadio.UseVisualStyleBackColor = true;
            // 
            // satyaVoiceRadio
            // 
            this.satyaVoiceRadio.AutoSize = true;
            this.satyaVoiceRadio.Location = new System.Drawing.Point(235, 112);
            this.satyaVoiceRadio.Name = "satyaVoiceRadio";
            this.satyaVoiceRadio.Size = new System.Drawing.Size(65, 21);
            this.satyaVoiceRadio.TabIndex = 6;
            this.satyaVoiceRadio.Text = "Satya";
            this.satyaVoiceRadio.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Voices:";
            // 
            // Form1
            // 
            this.AcceptButton = this.readButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(460, 255);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.satyaVoiceRadio);
            this.Controls.Add(this.robotVoiceRadio);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(this.instructionLabel);
            this.Name = "Form1";
            this.Text = "Number to Sound ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label instructionLabel;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.RadioButton robotVoiceRadio;
        private System.Windows.Forms.RadioButton satyaVoiceRadio;
        private System.Windows.Forms.Label label1;
    }
}

