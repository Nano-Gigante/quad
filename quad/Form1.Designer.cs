
namespace quad
{
    partial class Form1
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
            this.img1 = new System.Windows.Forms.PictureBox();
            this.img2 = new System.Windows.Forms.PictureBox();
            this.render_pb = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.img1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img2)).BeginInit();
            this.SuspendLayout();
            // 
            // img1
            // 
            this.img1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.img1.Location = new System.Drawing.Point(13, 13);
            this.img1.Name = "img1";
            this.img1.Size = new System.Drawing.Size(512, 512);
            this.img1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img1.TabIndex = 0;
            this.img1.TabStop = false;
            this.img1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.img1_MouseClick);
            // 
            // img2
            // 
            this.img2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.img2.Location = new System.Drawing.Point(531, 13);
            this.img2.Name = "img2";
            this.img2.Size = new System.Drawing.Size(512, 512);
            this.img2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img2.TabIndex = 1;
            this.img2.TabStop = false;
            this.img2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.img2_MouseClick);
            // 
            // render_pb
            // 
            this.render_pb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.render_pb.Location = new System.Drawing.Point(13, 532);
            this.render_pb.Name = "render_pb";
            this.render_pb.Size = new System.Drawing.Size(1030, 25);
            this.render_pb.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 569);
            this.Controls.Add(this.render_pb);
            this.Controls.Add(this.img2);
            this.Controls.Add(this.img1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.img1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox img1;
        private System.Windows.Forms.PictureBox img2;
        private System.Windows.Forms.ProgressBar render_pb;
    }
}

