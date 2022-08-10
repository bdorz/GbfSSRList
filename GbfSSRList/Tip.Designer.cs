
namespace GbfSSRList
{
    partial class Tip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tip));
            this.tbTip = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbTip
            // 
            this.tbTip.Font = new System.Drawing.Font("新細明體", 12F);
            this.tbTip.Location = new System.Drawing.Point(12, 11);
            this.tbTip.Multiline = true;
            this.tbTip.Name = "tbTip";
            this.tbTip.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTip.Size = new System.Drawing.Size(547, 377);
            this.tbTip.TabIndex = 0;
            this.tbTip.Text = resources.GetString("tbTip.Text");
            // 
            // Tip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(571, 400);
            this.Controls.Add(this.tbTip);
            this.Name = "Tip";
            this.Text = "Tip";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTip;
    }
}