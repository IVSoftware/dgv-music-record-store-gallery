namespace dgv_music_record_store_gallery
{
    partial class MainForm
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
            this.dataGridViewGallery = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGallery)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewGallery
            // 
            this.dataGridViewGallery.AllowUserToAddRows = false;
            this.dataGridViewGallery.AllowUserToDeleteRows = false;
            this.dataGridViewGallery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGallery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGallery.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewGallery.Name = "dataGridViewGallery";
            this.dataGridViewGallery.ReadOnly = true;
            this.dataGridViewGallery.RowHeadersWidth = 62;
            this.dataGridViewGallery.Size = new System.Drawing.Size(1178, 394);
            this.dataGridViewGallery.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 394);
            this.Controls.Add(this.dataGridViewGallery);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGallery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridViewGallery;
    }
}