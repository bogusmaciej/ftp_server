﻿
namespace ftp_server
{
    partial class startingServerForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.connect_btn = new System.Windows.Forms.Button();
            this.port_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // connect_btn
            // 
            this.connect_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.connect_btn.Location = new System.Drawing.Point(58, 55);
            this.connect_btn.Name = "connect_btn";
            this.connect_btn.Size = new System.Drawing.Size(181, 35);
            this.connect_btn.TabIndex = 2;
            this.connect_btn.Text = "start server";
            this.connect_btn.UseVisualStyleBackColor = true;
            this.connect_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // port_textBox
            // 
            this.port_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.port_textBox.Location = new System.Drawing.Point(86, 29);
            this.port_textBox.Name = "port_textBox";
            this.port_textBox.Size = new System.Drawing.Size(153, 20);
            this.port_textBox.TabIndex = 3;
            this.port_textBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "port";
            // 
            // message
            // 
            this.message.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.message.AutoSize = true;
            this.message.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.message.Location = new System.Drawing.Point(58, 93);
            this.message.MinimumSize = new System.Drawing.Size(181, 0);
            this.message.Name = "message";
            this.message.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.message.Size = new System.Drawing.Size(181, 13);
            this.message.TabIndex = 5;
            this.message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.message.Click += new System.EventHandler(this.message_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 121);
            this.Controls.Add(this.message);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.port_textBox);
            this.Controls.Add(this.connect_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button connect_btn;
        private System.Windows.Forms.TextBox port_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label message;
    }
}
