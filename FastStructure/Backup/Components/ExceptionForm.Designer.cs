namespace FastStructure.GUI
{
    partial class ExceptionForm
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
        public override void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionForm));
            this.picError = new System.Windows.Forms.PictureBox();
            this.btSubmit = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblExceptionPrompt = new System.Windows.Forms.Label();
            this.lblExceptionTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.SuspendLayout();
            // 
            // picError
            // 
            this.picError.ErrorImage = null;
            this.picError.Image = ((System.Drawing.Image)(resources.GetObject("picError.Image")));
            this.picError.InitialImage = null;
            this.picError.Location = new System.Drawing.Point(12, 29);
            this.picError.Name = "picError";
            this.picError.Size = new System.Drawing.Size(29, 32);
            this.picError.TabIndex = 12;
            this.picError.TabStop = false;
            // 
            // btSubmit
            // 
            this.btSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btSubmit.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btSubmit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSubmit.Location = new System.Drawing.Point(340, 194);
            this.btSubmit.Name = "btSubmit";
            this.btSubmit.Size = new System.Drawing.Size(73, 23);
            this.btSubmit.TabIndex = 11;
            this.btSubmit.Text = "OK";
            this.btSubmit.UseVisualStyleBackColor = false;
            this.btSubmit.Click += new System.EventHandler(this.btSubmit_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(-1, 99);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(416, 78);
            this.lblMessage.TabIndex = 10;
            // 
            // lblExceptionPrompt
            // 
            this.lblExceptionPrompt.BackColor = System.Drawing.Color.White;
            this.lblExceptionPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExceptionPrompt.Location = new System.Drawing.Point(-5, 31);
            this.lblExceptionPrompt.Name = "lblExceptionPrompt";
            this.lblExceptionPrompt.Size = new System.Drawing.Size(440, 52);
            this.lblExceptionPrompt.TabIndex = 9;
            this.lblExceptionPrompt.Text = "                    The following information about this unexpected exception.   " +
                "                           You can find  detailed information in the log file.";
            this.lblExceptionPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExceptionTitle
            // 
            this.lblExceptionTitle.BackColor = System.Drawing.Color.White;
            this.lblExceptionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExceptionTitle.Location = new System.Drawing.Point(-5, 3);
            this.lblExceptionTitle.Name = "lblExceptionTitle";
            this.lblExceptionTitle.Size = new System.Drawing.Size(440, 40);
            this.lblExceptionTitle.TabIndex = 8;
            this.lblExceptionTitle.Text = "            An unexpected exception occurred";
            this.lblExceptionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 221);
            this.Controls.Add(this.picError);
            this.Controls.Add(this.btSubmit);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblExceptionPrompt);
            this.Controls.Add(this.lblExceptionTitle);
            this.Name = "ExceptionForm";
            this.Text = "ExceptionForm";
            this.Load += new System.EventHandler(this.ExceptionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picError;
        private System.Windows.Forms.Button btSubmit;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblExceptionPrompt;
        private System.Windows.Forms.Label lblExceptionTitle;
    }
}