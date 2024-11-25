namespace kursach
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
            this.ApplySwitch = new System.Windows.Forms.Button();
            this.ReadSwitch = new System.Windows.Forms.Button();
            this.GoButton = new System.Windows.Forms.Button();
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.WatermarkBox = new System.Windows.Forms.PictureBox();
            this.ResultBox = new System.Windows.Forms.PictureBox();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.Exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WatermarkBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ApplySwitch
            // 
            this.ApplySwitch.Location = new System.Drawing.Point(640, 333);
            this.ApplySwitch.Name = "ApplySwitch";
            this.ApplySwitch.Size = new System.Drawing.Size(111, 44);
            this.ApplySwitch.TabIndex = 0;
            this.ApplySwitch.Text = "Apply Mode";
            this.ApplySwitch.UseVisualStyleBackColor = true;
            this.ApplySwitch.Click += new System.EventHandler(this.ApplySwitch_Click);
            // 
            // ReadSwitch
            // 
            this.ReadSwitch.Location = new System.Drawing.Point(69, 333);
            this.ReadSwitch.Name = "ReadSwitch";
            this.ReadSwitch.Size = new System.Drawing.Size(111, 44);
            this.ReadSwitch.TabIndex = 1;
            this.ReadSwitch.Text = "Read mode";
            this.ReadSwitch.UseVisualStyleBackColor = true;
            this.ReadSwitch.Click += new System.EventHandler(this.ReadSwitch_Click);
            // 
            // GoButton
            // 
            this.GoButton.Location = new System.Drawing.Point(350, 333);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(111, 44);
            this.GoButton.TabIndex = 2;
            this.GoButton.Text = "Apply";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // ImageBox
            // 
            this.ImageBox.Location = new System.Drawing.Point(12, 12);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(242, 247);
            this.ImageBox.TabIndex = 3;
            this.ImageBox.TabStop = false;
            this.ImageBox.Click += new System.EventHandler(this.ImageBox_Click);
            // 
            // WatermarkBox
            // 
            this.WatermarkBox.Location = new System.Drawing.Point(291, 9);
            this.WatermarkBox.Name = "WatermarkBox";
            this.WatermarkBox.Size = new System.Drawing.Size(254, 249);
            this.WatermarkBox.TabIndex = 4;
            this.WatermarkBox.TabStop = false;
            this.WatermarkBox.Click += new System.EventHandler(this.WatermarkBox_Click);
            // 
            // ResultBox
            // 
            this.ResultBox.Location = new System.Drawing.Point(570, 7);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.Size = new System.Drawing.Size(221, 250);
            this.ResultBox.TabIndex = 5;
            this.ResultBox.TabStop = false;
            this.ResultBox.Click += new System.EventHandler(this.ResultBox_Click);
            // 
            // Progress
            // 
            this.Progress.Location = new System.Drawing.Point(291, 404);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(239, 23);
            this.Progress.TabIndex = 6;
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(726, 427);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 7;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.WatermarkBox);
            this.Controls.Add(this.ImageBox);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.ReadSwitch);
            this.Controls.Add(this.ApplySwitch);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WatermarkBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ApplySwitch;
        private System.Windows.Forms.Button ReadSwitch;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.PictureBox ImageBox;
        private System.Windows.Forms.PictureBox WatermarkBox;
        private System.Windows.Forms.PictureBox ResultBox;
        private System.Windows.Forms.ProgressBar Progress;
        private System.Windows.Forms.Button Exit;
    }
}

