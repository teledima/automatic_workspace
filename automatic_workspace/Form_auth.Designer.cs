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
            this.button_guest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_login
            // 
            this.button_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_login.Location = new System.Drawing.Point(15, 214);
            this.button_login.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(140, 52);
            this.button_login.TabIndex = 0;
            this.button_login.Text = "Log in";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // button_registration
            // 
            this.button_registration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_registration.Location = new System.Drawing.Point(160, 214);
            this.button_registration.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button_registration.Name = "button_registration";
            this.button_registration.Size = new System.Drawing.Size(140, 52);
            this.button_registration.TabIndex = 1;
            this.button_registration.Text = "Sign up";
            this.button_registration.UseVisualStyleBackColor = true;
            this.button_registration.Click += new System.EventHandler(this.button_registration_Click);
            // 
            // textbox_login
            // 
            this.textbox_login.Location = new System.Drawing.Point(15, 82);
            this.textbox_login.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textbox_login.Name = "textbox_login";
            this.textbox_login.Size = new System.Drawing.Size(457, 29);
            this.textbox_login.TabIndex = 2;
            // 
            // textbox_password
            // 
            this.textbox_password.Location = new System.Drawing.Point(15, 168);
            this.textbox_password.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.Size = new System.Drawing.Size(457, 29);
            this.textbox_password.TabIndex = 3;
            this.textbox_password.UseSystemPasswordChar = true;
            // 
            // label_log
            // 
            this.label_log.AutoSize = true;
            this.label_log.Location = new System.Drawing.Point(180, 55);
            this.label_log.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_log.Name = "label_log";
            this.label_log.Size = new System.Drawing.Size(57, 22);
            this.label_log.TabIndex = 4;
            this.label_log.Text = "Login";
            // 
            // label_pass
            // 
            this.label_pass.AutoSize = true;
            this.label_pass.Location = new System.Drawing.Point(180, 141);
            this.label_pass.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_pass.Name = "label_pass";
            this.label_pass.Size = new System.Drawing.Size(94, 22);
            this.label_pass.TabIndex = 5;
            this.label_pass.Text = "Password";
            // 
            // label_result
            // 
            this.label_result.AutoSize = true;
            this.label_result.Location = new System.Drawing.Point(10, 270);
            this.label_result.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_result.Name = "label_result";
            this.label_result.Size = new System.Drawing.Size(0, 22);
            this.label_result.TabIndex = 6;
            // 
            // strenght_password
            // 
            this.strenght_password.AutoSize = true;
            this.strenght_password.Location = new System.Drawing.Point(575, 360);
            this.strenght_password.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.strenght_password.Name = "strenght_password";
            this.strenght_password.Size = new System.Drawing.Size(0, 22);
            this.strenght_password.TabIndex = 7;
            // 
            // label_update
            // 
            this.label_update.AutoSize = true;
            this.label_update.Location = new System.Drawing.Point(115, 18);
            this.label_update.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_update.Name = "label_update";
            this.label_update.Size = new System.Drawing.Size(0, 22);
            this.label_update.TabIndex = 8;
            // 
            // button_guest
            // 
            this.button_guest.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_guest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_guest.Location = new System.Drawing.Point(310, 216);
            this.button_guest.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button_guest.Name = "button_guest";
            this.button_guest.Size = new System.Drawing.Size(162, 50);
            this.button_guest.TabIndex = 11;
            this.button_guest.Text = "Log in as guest";
            this.button_guest.UseVisualStyleBackColor = true;
            this.button_guest.Click += new System.EventHandler(this.button_guest_Click);
            // 
            // Form_auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(486, 332);
            this.Controls.Add(this.button_guest);
            this.Controls.Add(this.label_update);
            this.Controls.Add(this.strenght_password);
            this.Controls.Add(this.label_result);
            this.Controls.Add(this.label_pass);
            this.Controls.Add(this.label_log);
            this.Controls.Add(this.textbox_password);
            this.Controls.Add(this.textbox_login);
            this.Controls.Add(this.button_registration);
            this.Controls.Add(this.button_login);
            this.Font = new System.Drawing.Font("Cooper Black", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "Form_auth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Button button_guest;
    }
}