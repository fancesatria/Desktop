
namespace Perpustakaan
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpw = new System.Windows.Forms.TextBox();
            this.txtcaptcha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnlogin = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btncaptcha = new System.Windows.Forms.Button();
            this.boxcaptcha = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "USERNAME";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(20, 88);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(291, 20);
            this.txtuser.TabIndex = 1;
            this.txtuser.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "PASSWORD";
            // 
            // txtpw
            // 
            this.txtpw.Location = new System.Drawing.Point(20, 139);
            this.txtpw.Name = "txtpw";
            this.txtpw.PasswordChar = 'o';
            this.txtpw.Size = new System.Drawing.Size(291, 20);
            this.txtpw.TabIndex = 3;
            // 
            // txtcaptcha
            // 
            this.txtcaptcha.Location = new System.Drawing.Point(20, 241);
            this.txtcaptcha.Name = "txtcaptcha";
            this.txtcaptcha.Size = new System.Drawing.Size(291, 20);
            this.txtcaptcha.TabIndex = 4;
            this.txtcaptcha.TextChanged += new System.EventHandler(this.txtcaptcha_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "CAPTCHA";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Crimson;
            this.btnclose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnclose.Location = new System.Drawing.Point(20, 333);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(291, 37);
            this.btnclose.TabIndex = 6;
            this.btnclose.Text = "TUTUP APLIKASI";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnlogin
            // 
            this.btnlogin.Location = new System.Drawing.Point(20, 282);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(291, 37);
            this.btnlogin.TabIndex = 7;
            this.btnlogin.Text = "LOGIN";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(121, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = "LOGIN";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btncaptcha
            // 
            this.btncaptcha.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btncaptcha.ForeColor = System.Drawing.SystemColors.Control;
            this.btncaptcha.Location = new System.Drawing.Point(214, 194);
            this.btncaptcha.Name = "btncaptcha";
            this.btncaptcha.Size = new System.Drawing.Size(73, 26);
            this.btncaptcha.TabIndex = 12;
            this.btncaptcha.Text = "Muat Ulang";
            this.btncaptcha.UseVisualStyleBackColor = false;
            this.btncaptcha.Click += new System.EventHandler(this.btncaptcha_Click);
            // 
            // boxcaptcha
            // 
            this.boxcaptcha.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.boxcaptcha.Font = new System.Drawing.Font("Lucida Handwriting", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxcaptcha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.boxcaptcha.Location = new System.Drawing.Point(83, 183);
            this.boxcaptcha.Multiline = true;
            this.boxcaptcha.Name = "boxcaptcha";
            this.boxcaptcha.Size = new System.Drawing.Size(125, 37);
            this.boxcaptcha.TabIndex = 14;
            this.boxcaptcha.Text = "captcha";
            this.boxcaptcha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 384);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 15;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnclose;
            this.ClientSize = new System.Drawing.Size(329, 424);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.boxcaptcha);
            this.Controls.Add(this.btncaptcha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtcaptcha);
            this.Controls.Add(this.txtpw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN USER";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpw;
        private System.Windows.Forms.TextBox txtcaptcha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btncaptcha;
        private System.Windows.Forms.TextBox boxcaptcha;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
    }
}

