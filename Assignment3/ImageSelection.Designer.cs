namespace Assignment3
{
    partial class ImageSelection
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
            this.imageView = new System.Windows.Forms.ListView();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imageView
            // 
            this.imageView.BackColor = System.Drawing.SystemColors.HighlightText;
            this.imageView.HideSelection = false;
            this.imageView.LargeImageList = this.ImageList;
            this.imageView.Location = new System.Drawing.Point(12, 12);
            this.imageView.MultiSelect = false;
            this.imageView.Name = "imageView";
            this.imageView.Size = new System.Drawing.Size(1036, 540);
            this.imageView.SmallImageList = this.ImageList;
            this.imageView.TabIndex = 3;
            this.imageView.UseCompatibleStateImageBehavior = false;
            // 
            // ImageList
            // 
            this.ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ImageList.ImageSize = new System.Drawing.Size(256, 256);
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectImage.Location = new System.Drawing.Point(437, 578);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(164, 58);
            this.btnSelectImage.TabIndex = 4;
            this.btnSelectImage.Text = "SELECT";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // ImageSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 648);
            this.Controls.Add(this.btnSelectImage);
            this.Controls.Add(this.imageView);
            this.Name = "ImageSelection";
            this.Text = "ImageSelection";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView imageView;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.ImageList ImageList;
    }
}