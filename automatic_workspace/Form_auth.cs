using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            using (var connect = new NpgsqlConnection("Host = localhost; Username = postgres; Password = postgres; Database = lab6"))
            {
                connect.Open();
                var com_string = "select password, is_admin from operator_table where login = @login";
                using (var command = new NpgsqlCommand(com_string, connect))
                {
                    var parametr_log = new NpgsqlParameter("@login", NpgsqlTypes.NpgsqlDbType.Varchar, 50) { Value = login };
                    command.Parameters.Add(parametr_log);
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader.GetValue(0).Equals(Hash.HashMD5(password + Hash.salt)))
                        {
                            User_info.Current_status = reader["is_admin"].Equals(true)?User_info.Status.Admin:User_info.Status.Operator;
                            result = true;
                        }
                        else
                            result = false;
                    }
                    else
                    {
                        result = false;
                    }
                }
                connect.Close();
            }
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
            using var connection = new NpgsqlConnection("Host = localhost; Username = postgres; Password = postgres; DataBase = lab6");
            connection.Open();
            using var command = new NpgsqlCommand() { Connection = connection };
            command.CommandText = "insert into operator_table(login, password) values (@login, @password)";
            var param_log = new NpgsqlParameter("@login", NpgsqlTypes.NpgsqlDbType.Varchar) { Value = login };
            command.Parameters.Add(param_log);
            var param_pass = new NpgsqlParameter("@password", NpgsqlTypes.NpgsqlDbType.Text) { Value = password };
            command.Parameters.Add(param_pass);
            try
            {
                command.ExecuteNonQuery();
                label_result.Text = "Registration has finished successfully";
            }
            catch (NpgsqlException ex)
            {
                label_result.Text = string.Format("User with the login \"{0}\" already exist. {1}", login, ex.Message);
            }
            connection.Close();
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
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            var hash_password = new StringBuilder();
            foreach (byte hash_b in hash)
                hash_password.Append(hash_b.ToString("X2"));
            return hash_password.ToString().ToLower();
        }
    }
}
