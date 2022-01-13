
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
            this.speakerGif = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.speakerGif)).BeginInit();
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
            this.numberTextBox.Size = new System.Drawing.Size(115, 22);
            this.numberTextBox.TabIndex = 1;
            // 
            // readButton
            // 
            this.readButton.Location = new System.Drawing.Point(148, 112);
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
            this.exitButton.Location = new System.Drawing.Point(232, 144);
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
            this.stopButton.Location = new System.Drawing.Point(232, 112);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(83, 32);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // speakerGif
            // 
            this.speakerGif.Image = global::Number_to_Sound.Properties.Resources.Speaker_All_Assets___Download_Free_3D_Illustrations__Icons__Lottie_Animations;
            this.speakerGif.Location = new System.Drawing.Point(12, 112);
            this.speakerGif.Name = "speakerGif";
            this.speakerGif.Size = new System.Drawing.Size(103, 101);
            this.speakerGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.speakerGif.TabIndex = 5;
            this.speakerGif.TabStop = false;
            this.speakerGif.Visible = false;
            // 
            // Form1
            // 
            this.AcceptButton = this.readButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(460, 225);
            this.Controls.Add(this.speakerGif);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(this.instructionLabel);
            this.Name = "Form1";
            this.Text = "Number to Sound ";
            ((System.ComponentModel.ISupportInitialize)(this.speakerGif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label instructionLabel;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.PictureBox speakerGif;
    }
}

