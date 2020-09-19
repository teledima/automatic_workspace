using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using automatic_workspace;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace automatic_workspace
{
    public partial class Form_auth : Form
    {
        public Form_auth()
        {
            InitializeComponent();
            if (Info_operate.Current_operation == Info_operate.Types.add_from_auth)
            {
                button_guest.Visible = false;
                button_login.Visible = false;
                button_registration.Location = button_login.Location;
            }
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (Check_log_in(textbox_login.Text, textbox_password.Text))
                Close();
            else
                label_result.Text = "Failed to log in";
        }

        private bool Check_log_in(string login, string password)
        {
            bool result;
            using BrainlyContext db = new BrainlyContext();
            OperatorWorkspace user = db.OperatorsWorkspace.Where(op => op.Login == login).FirstOrDefault();
            if (user != null)
            {
                if (user.Password == Hash.HashMD5(password))
                {
                    User_info.Current_status = user.IsAdmin ? User_info.Status.Admin : User_info.Status.Operator;
                    result = true;
                }
                else
                    result = false;
            }
            else
                result = false;
            return result;
        }

        private void button_registration_Click(object sender, EventArgs e)
        {
            if (Info_operate.Current_operation != Info_operate.Types.add_from_auth)
            {
                Info_operate.Current_operation = Info_operate.Types.add_from_auth;
                new Form_auth().ShowDialog();
            }
            else
            {
                ExecuteAdd_registration(textbox_login.Text, Hash.HashMD5(textbox_password.Text + Hash.salt));
                var timer = new Timer() { Interval = 3000 };
                timer.Tick += new EventHandler(delegate (object _s, EventArgs _e) {
                    timer.Stop();
                    Close();
                });
                timer.Start();
            }
        }
        private void ExecuteAdd_registration(string login, string password)
        {
            using BrainlyContext db = new BrainlyContext();
            db.OperatorsWorkspace.Add(new OperatorWorkspace(login, password));
            try
            {
                db.SaveChanges();
                label_result.Text = "Registration has finished successfully";
            }
            catch (DbUpdateException ex)
            {
                PostgresException postgresException = (PostgresException)ex.InnerException;
                if (postgresException.SqlState == "23505")
                    label_result.Text = string.Format("User with the login \"{0}\" already exist. {1}", login, ex.Message);
                
            }
        }

        private void button_guest_Click(object sender, EventArgs e)
        {
            User_info.Current_status = User_info.Status.Guest;
            Close();
        }
    }

    public static class Info_operate
    {
        public enum Types{ add, delete, update, add_from_auth}
        public static Types? Current_operation { get; set; }
    }

    public static class Hash
    {
        public const string salt = "BbfbGYY55$Yvdv";
        public static string HashMD5(string password)
        {
            using var md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password+salt));
            var hash_password = new StringBuilder();
            foreach (byte hash_b in hash)
                hash_password.Append(hash_b.ToString("X2"));
            return hash_password.ToString().ToLower();
        }
    }
}
