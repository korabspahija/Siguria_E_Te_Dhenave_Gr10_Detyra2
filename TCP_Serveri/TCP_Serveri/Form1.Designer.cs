﻿namespace TCP_Serveri
{
    partial class Serveri
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
            this.txtMesazhi = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMesazhi
            // 
            this.txtMesazhi.Location = new System.Drawing.Point(27, 51);
            this.txtMesazhi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMesazhi.Multiline = true;
            this.txtMesazhi.Name = "txtMesazhi";
            this.txtMesazhi.Size = new System.Drawing.Size(369, 76);
            this.txtMesazhi.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(27, 16);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(101, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Serveri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 319);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtMesazhi);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Serveri";
            this.Text = "Serveri";
            this.Load += new System.EventHandler(this.Serveri_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMesazhi;
        private System.Windows.Forms.Button btnStart;
    }
}

