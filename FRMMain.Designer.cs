namespace RFMDev1
{
    partial class FRMMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            TXTOutput = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(23, 12);
            button1.Name = "button1";
            button1.Size = new Size(188, 58);
            button1.TabIndex = 0;
            button1.Text = "Test";
            button1.UseVisualStyleBackColor = true;
            // 
            // TXTOutput
            // 
            TXTOutput.Location = new Point(23, 89);
            TXTOutput.Multiline = true;
            TXTOutput.Name = "TXTOutput";
            TXTOutput.ScrollBars = ScrollBars.Both;
            TXTOutput.Size = new Size(2023, 644);
            TXTOutput.TabIndex = 1;
            // 
            // FRMMain
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2059, 768);
            Controls.Add(TXTOutput);
            Controls.Add(button1);
            Name = "FRMMain";
            Text = "Roku Feed Manager v0.02";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox TXTOutput;
    }
}
