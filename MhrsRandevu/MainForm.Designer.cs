namespace MhrsRandevu
{
    partial class Anaform
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
            this.lblSorguAraligi = new System.Windows.Forms.Label();
            this.numericSorguAraligi = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericSorguAraligi)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSorguAraligi
            // 
            this.lblSorguAraligi.AutoSize = true;
            this.lblSorguAraligi.Location = new System.Drawing.Point(12, 9);
            this.lblSorguAraligi.Name = "lblSorguAraligi";
            this.lblSorguAraligi.Size = new System.Drawing.Size(120, 15);
            this.lblSorguAraligi.TabIndex = 3;
            this.lblSorguAraligi.Text = "Sorgu Aralığı (Saniye)";
            // 
            // numericSorguAraligi
            // 
            this.numericSorguAraligi.Location = new System.Drawing.Point(138, 6);
            this.numericSorguAraligi.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.numericSorguAraligi.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericSorguAraligi.Name = "numericSorguAraligi";
            this.numericSorguAraligi.Size = new System.Drawing.Size(51, 23);
            this.numericSorguAraligi.TabIndex = 2;
            this.numericSorguAraligi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericSorguAraligi.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numericSorguAraligi.ValueChanged += new System.EventHandler(this.numericSorguAraligi_ValueChanged);
            // 
            // Anaform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 36);
            this.Controls.Add(this.lblSorguAraligi);
            this.Controls.Add(this.numericSorguAraligi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Anaform";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Anaform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericSorguAraligi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSorguAraligi;
        private System.Windows.Forms.NumericUpDown numericSorguAraligi;
    }
}
