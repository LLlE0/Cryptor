﻿namespace Cryptor
{
    partial class ImageCryptor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageCryptor));
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.ENCRYPT = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.RichTextBox();
            this.DECRYPT = new System.Windows.Forms.Button();
            this.Selector = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.PictureBox.BackgroundImage = global::Cryptor.Properties.Resources._1;
            this.PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictureBox.Location = new System.Drawing.Point(10, 11);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(521, 421);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            this.PictureBox.WaitOnLoad = true;
            this.PictureBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.PictureBox_DragDrop);
            this.PictureBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.PictureBox_DragEnter);
            this.PictureBox.DoubleClick += new System.EventHandler(this.PictureBox_DoubleClick);
            // 
            // ENCRYPT
            // 
            this.ENCRYPT.BackColor = System.Drawing.SystemColors.Control;
            this.ENCRYPT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENCRYPT.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ENCRYPT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(20)))), ((int)(((byte)(192)))));
            this.ENCRYPT.Image = global::Cryptor.Properties.Resources._31;
            this.ENCRYPT.Location = new System.Drawing.Point(546, 264);
            this.ENCRYPT.Name = "ENCRYPT";
            this.ENCRYPT.Size = new System.Drawing.Size(241, 76);
            this.ENCRYPT.TabIndex = 2;
            this.ENCRYPT.Text = "ENCRYPT";
            this.ENCRYPT.UseVisualStyleBackColor = false;
            this.ENCRYPT.Click += new System.EventHandler(this.ENCRYPT_Click);
            // 
            // log
            // 
            this.log.BackColor = System.Drawing.SystemColors.WindowText;
            this.log.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.log.ForeColor = System.Drawing.Color.DarkOrchid;
            this.log.Location = new System.Drawing.Point(549, 12);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(239, 146);
            this.log.TabIndex = 4;
            this.log.Text = "";
            // 
            // DECRYPT
            // 
            this.DECRYPT.BackColor = System.Drawing.SystemColors.Control;
            this.DECRYPT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DECRYPT.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DECRYPT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(20)))), ((int)(((byte)(192)))));
            this.DECRYPT.Image = global::Cryptor.Properties.Resources._31;
            this.DECRYPT.Location = new System.Drawing.Point(547, 356);
            this.DECRYPT.Name = "DECRYPT";
            this.DECRYPT.Size = new System.Drawing.Size(241, 76);
            this.DECRYPT.TabIndex = 5;
            this.DECRYPT.Text = "DECRYPT";
            this.DECRYPT.UseVisualStyleBackColor = false;
            this.DECRYPT.Click += new System.EventHandler(this.DECRYPT_Click);
            // 
            // Selector
            // 
            this.Selector.BackColor = System.Drawing.SystemColors.Control;
            this.Selector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Selector.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Selector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Selector.Image = global::Cryptor.Properties.Resources._31;
            this.Selector.Location = new System.Drawing.Point(546, 176);
            this.Selector.Name = "Selector";
            this.Selector.Size = new System.Drawing.Size(241, 72);
            this.Selector.TabIndex = 6;
            this.Selector.Text = "SELECT A FILE";
            this.Selector.UseVisualStyleBackColor = false;
            this.Selector.Click += new System.EventHandler(this.Selector_Click);
            // 
            // ImageCryptor
            // 
            this.AcceptButton = this.ENCRYPT;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Cryptor.Properties.Resources._31;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Selector);
            this.Controls.Add(this.DECRYPT);
            this.Controls.Add(this.log);
            this.Controls.Add(this.ENCRYPT);
            this.Controls.Add(this.PictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImageCryptor";
            this.Text = "Image Cryptor v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Button ENCRYPT;
        private Button DECRYPT;
        private Button Selector;
        public PictureBox PictureBox;
        public RichTextBox log;
    }
}