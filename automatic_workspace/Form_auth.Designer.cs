namespace automatic_workspace
{
    partial class Form_auth
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
            this.button_login = new System.Windows.Forms.Button();
            this.button_registration = new System.Windows.Forms.Button();
            this.textbox_login = new System.Windows.Forms.TextBox();
            this.textbox_password = new System.Windows.Forms.TextBox();
            this.label_log = new System.Windows.Forms.Label();
            this.label_pass = new System.Windows.Forms.Label();
            this.label_result = new System.Windows.Forms.Label();
            this.strenght_password = new System.Windows.Forms.Label();
            this.label_update = new System.Windows.Forms.Label();
            this.textBox_old = new System.Windows.Forms.TextBox();
            this.label_old = new System.Windows.Forms.Label();
            this.button_guest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(106, 281);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(207, 43);
            this.button_login.TabIndex = 0;
            this.button_login.Text = "Log in";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // button_registration
            // 
            this.button_registration.Location = new System.Drawing.Point(328, 281);
            this.button_registration.Name = "button_registration";
            this.button_registration.Size = new System.Drawing.Size(184, 43);
            this.button_registration.TabIndex = 1;
            this.button_registration.Text = "Sign up";
            this.button_registration.UseVisualStyleBackColor = true;
            this.button_registration.Click += new System.EventHandler(this.button_registration_Click);
            // 
            // textbox_login
            // 
            this.textbox_login.Location = new System.Drawing.Point(106, 135);
            this.textbox_login.Name = "textbox_login";
            this.textbox_login.Size = new System.Drawing.Size(325, 22);
            this.textbox_login.TabIndex = 2;
            // 
            // textbox_password
            // 
            this.textbox_password.Location = new System.Drawing.Point(106, 216);
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.Size = new System.Drawing.Size(321, 22);
            this.textbox_password.TabIndex = 3;
            this.textbox_password.UseSystemPasswordChar = true;
            // 
            // label_log
            // 
            this.label_log.AutoSize = true;
            this.label_log.Location = new System.Drawing.Point(103, 104);
            this.label_log.Name = "label_log";
            this.label_log.Size = new System.Drawing.Size(43, 17);
            this.label_log.TabIndex = 4;
            this.label_log.Text = "Login";
            // 
            // label_pass
            // 
            this.label_pass.AutoSize = true;
            this.label_pass.Location = new System.Drawing.Point(103, 186);
            this.label_pass.Name = "label_pass";
            this.label_pass.Size = new System.Drawing.Size(69, 17);
            this.label_pass.TabIndex = 5;
            this.label_pass.Text = "Password";
            // 
            // label_result
            // 
            this.label_result.AutoSize = true;
            this.label_result.Location = new System.Drawing.Point(103, 369);
            this.label_result.Name = "label_result";
            this.label_result.Size = new System.Drawing.Size(0, 17);
            this.label_result.TabIndex = 6;
            // 
            // strenght_password
            // 
            this.strenght_password.AutoSize = true;
            this.strenght_password.Location = new System.Drawing.Point(459, 221);
            this.strenght_password.Name = "strenght_password";
            this.strenght_password.Size = new System.Drawing.Size(0, 17);
            this.strenght_password.TabIndex = 7;
            // 
            // label_update
            // 
            this.label_update.AutoSize = true;
            this.label_update.Location = new System.Drawing.Point(116, 42);
            this.label_update.Name = "label_update";
            this.label_update.Size = new System.Drawing.Size(0, 17);
            this.label_update.TabIndex = 8;
            // 
            // textBox_old
            // 
            this.textBox_old.Location = new System.Drawing.Point(462, 135);
            this.textBox_old.Name = "textBox_old";
            this.textBox_old.PasswordChar = '*';
            this.textBox_old.Size = new System.Drawing.Size(255, 22);
            this.textBox_old.TabIndex = 9;
            this.textBox_old.Visible = false;
            // 
            // label_old
            // 
            this.label_old.AutoSize = true;
            this.label_old.Location = new System.Drawing.Point(459, 104);
            this.label_old.Name = "label_old";
            this.label_old.Size = new System.Drawing.Size(95, 17);
            this.label_old.TabIndex = 10;
            this.label_old.Text = "Old Password";
            this.label_old.Visible = false;
            // 
            // button_guest
            // 
            this.button_guest.Location = new System.Drawing.Point(537, 282);
            this.button_guest.Name = "button_guest";
            this.button_guest.Size = new System.Drawing.Size(116, 42);
            this.button_guest.TabIndex = 11;
            this.button_guest.Text = "Log in as guest";
            this.button_guest.UseVisualStyleBackColor = true;
            this.button_guest.Click += new System.EventHandler(this.button_guest_Click);
            // 
            // Form_auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_guest);
            this.Controls.Add(this.label_old);
            this.Controls.Add(this.textBox_old);
            this.Controls.Add(this.label_update);
            this.Controls.Add(this.strenght_password);
            this.Controls.Add(this.label_result);
            this.Controls.Add(this.label_pass);
            this.Controls.Add(this.label_log);
            this.Controls.Add(this.textbox_password);
            this.Controls.Add(this.textbox_login);
            this.Controls.Add(this.button_registration);
            this.Controls.Add(this.button_login);
            this.Name = "Form_auth";
            this.Text = "Add_Update_Delete";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Button button_registration;
        private System.Windows.Forms.TextBox textbox_login;
        private System.Windows.Forms.Label label_log;
        private System.Windows.Forms.Label label_pass;
        private System.Windows.Forms.Label label_result;
        private System.Windows.Forms.Label strenght_password;
        public System.Windows.Forms.TextBox textbox_password;
        private System.Windows.Forms.Label label_update;
        private System.Windows.Forms.TextBox textBox_old;
        private System.Windows.Forms.Label label_old;
        private System.Windows.Forms.Button button_guest;
    }
}