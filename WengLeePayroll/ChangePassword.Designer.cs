namespace WengLeePayroll
{
    partial class ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            this.label1 = new System.Windows.Forms.Label();
            this.txtOld = new System.Windows.Forms.TextBox();
            this.buttonLastest1 = new WengLeePayroll.ButtonLastest();
            this.labelGradient2 = new WengLeePayroll.LabelGradient();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Enter Old Password:";
            // 
            // txtOld
            // 
            this.txtOld.Location = new System.Drawing.Point(225, 86);
            this.txtOld.Name = "txtOld";
            this.txtOld.Size = new System.Drawing.Size(246, 20);
            this.txtOld.TabIndex = 17;
            this.txtOld.UseSystemPasswordChar = true;
            // 
            // buttonLastest1
            // 
            this.buttonLastest1.BackColor = System.Drawing.Color.White;
            this.buttonLastest1.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.buttonLastest1.FlatAppearance.BorderSize = 5;
            this.buttonLastest1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLastest1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonLastest1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.buttonLastest1.Location = new System.Drawing.Point(225, 177);
            this.buttonLastest1.Name = "buttonLastest1";
            this.buttonLastest1.Size = new System.Drawing.Size(161, 40);
            this.buttonLastest1.TabIndex = 0;
            this.buttonLastest1.Text = "Change Password";
            this.buttonLastest1.UseVisualStyleBackColor = false;
            this.buttonLastest1.Click += new System.EventHandler(this.buttonLastest1_Click);
            // 
            // labelGradient2
            // 
            this.labelGradient2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.labelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient2.ForeColor = System.Drawing.Color.White;
            this.labelGradient2.GradientColorTwo = System.Drawing.Color.Black;
            this.labelGradient2.Location = new System.Drawing.Point(-6, -6);
            this.labelGradient2.Name = "labelGradient2";
            this.labelGradient2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelGradient2.Size = new System.Drawing.Size(524, 57);
            this.labelGradient2.TabIndex = 30;
            this.labelGradient2.Text = "Change Password";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Location = new System.Drawing.Point(225, 138);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Size = new System.Drawing.Size(246, 20);
            this.txtConfirmPass.TabIndex = 32;
            this.txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "Confirm New Password:";
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(225, 112);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(246, 20);
            this.txtNewPass.TabIndex = 34;
            this.txtNewPass.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "Enter New Password:";
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(514, 250);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelGradient2);
            this.Controls.Add(this.txtOld);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLastest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePassword";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmPayPeriod_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ButtonLastest buttonLastest1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOld;
        private LabelGradient labelGradient2;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label label3;
    }
}