using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using Microsoft.VisualBasic;

namespace automatic_workspace
{
    public partial class Form_workspace : Form
    {
        private readonly string connect_string = "Host = localhost; Username = postgres; password = postgres; Database = lab6";
        public Form_workspace()
        {
            InitializeComponent();
            if (User_info.status == 0 || User_info.status == 1)
            {
                data_grid_view.AllowUserToAddRows = true;
                data_grid_view.AllowUserToDeleteRows = true;
                data_grid_view.ReadOnly = false;
            }
            if (User_info.status == 1)
            {
                data_grid_view_operators.AllowUserToAddRows = true;
                data_grid_view_operators.AllowUserToDeleteRows = true;
                data_grid_view_operators.ReadOnly = false;
            }
            if (User_info.status == -1 || User_info.status == 0)
            {
                tabPage2.Dispose();
            }
            InitializePresentation();
            InitializeListView();
        }
        private void InitializePresentation()
        {
            data_grid_view.Rows.Clear();
            data_grid_view.Columns.Clear();
            DataTable data = new DataTable();
            status_load(data);
            {
                data_grid_view.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "id_question",
                    ValueType = typeof(uint),
                    Visible = false
                });
                data_grid_view.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "link_id",
                    HeaderText = "link_id",
                    ValueType = typeof(uint)
                });
                data_grid_view.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "count_view",
                    HeaderText = "count_view",
                    ValueType = typeof(uint),
                });
                data_grid_view.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "count_like",
                    HeaderText = "count_like",
                    ValueType = typeof(uint),
                });
                data_grid_view.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "user_id",
                    HeaderText = "id_user",
                    Visible = false,
                    ValueType = typeof(uint)
                });
                data_grid_view.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "login",
                    HeaderText = "login",
                    ValueType = typeof(string)
                });
                data_grid_view.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "age",
                    HeaderText = "age",
                    ValueType = typeof(uint)
                });
                data_grid_view.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "status_id",
                    HeaderText = "status_id",
                    Visible = false,
                    ValueType = typeof(uint)
                });
                data_grid_view.Columns.Add(new DataGridViewComboBoxColumn
                {
                    Name = "status",
                    HeaderText = "status",
                    ValueType = typeof(string),
                    DataSource = data,
                    DisplayMember = "name"
                });
            }
            using (var connect = new NpgsqlConnection(connect_string))
            {
                connect.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = connect,
                    CommandText = @"select * from questions inner join users u on questions.user_id = u.id_user inner join statuses s on u.status_id = s.id_status;"
                };
                var reader = sCommand.ExecuteReader();
                while (reader.Read())
                {
                    data_grid_view.Rows.Add(reader["id_question"], reader["link_id"], reader["count_view"], reader["count_like"], reader["user_id"], reader["login"], reader["age"], reader["status_id"],
                        reader["name"]); //fill data_grid_view
                }
            }
            foreach (DataGridViewRow row in data_grid_view.Rows)
            {
                if (!row.IsNewRow)
                {
                    var tag = new List<object>();
                    foreach (DataGridViewCell cell in row.Cells)
                        tag.Add(cell.Value);
                    row.Tag = tag;
                } //assign a tag for each added row equal his values
            }
        }

        private void InitializeListView()
        {
            data_grid_view_operators.Rows.Clear();
            data_grid_view_operators.Columns.Clear();
            data_grid_view_operators.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "login",
                HeaderText = "login",
                ValueType = typeof(string)
            });
            data_grid_view_operators.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "password",
                HeaderText = "password",
                ValueType = typeof(string)
            });
            data_grid_view_operators.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "is_admin",
                HeaderText = "is_admin",
                TrueValue = true,
                FalseValue = false
            });
            using var connect = new NpgsqlConnection("Host = localhost; Username = postgres; password = postgres; DataBase = lab6");
            connect.Open();
            var reader = connect.ExecuteReader("select login, password, is_admin from operator_table");
            while (reader.Read())
            {
                data_grid_view_operators.Rows.Add(reader["login"], reader["password"], reader["is_admin"]);
            }
            reader.Close();

            connect.Close();
            foreach (DataGridViewRow row in data_grid_view_operators.Rows)
            {
                if (!row.IsNewRow)
                {
                    var tag = new List<object>();
                    foreach (DataGridViewCell cell in row.Cells)
                        tag.Add(cell.Value);
                    row.Tag = tag;
                } //assign a tag for each added row equal his values
            }

        }
        private void status_load(DataTable data)
        {
            using var connect = new NpgsqlConnection(connect_string);
            connect.Open();
            using var command = new NpgsqlCommand("select name from statuses", connect);
            data.Load(command.ExecuteReader());
            connect.Close();
        }

        private void data_grid_view_operators_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = data_grid_view_operators.Rows[e.RowIndex];
            if (data_grid_view_operators.IsCurrentRowDirty)
                if (!e.Cancel)
                {
                    row.Cells["is_admin"].Value = row.Cells["is_admin"].Value ?? false;
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["login"].Value == null)
                        {
                            MessageBox.Show("not null");
                            row.Cells["login"].Value = ((List<object>)row.Tag)[0];
                        }
                        if (row.Cells["password"].Value == null)
                        {
                            MessageBox.Show("not null");
                            row.Cells["password"].Value = ((List<object>)row.Tag)[0];
                        }
                    }
                    string login = row.Cells["login"].Value.ToString();
                    string password = Hash.HashMD5(row.Cells["password"].Value.ToString() + Hash.salt);
                    bool is_admin = bool.Parse(row.Cells["is_admin"].Value.ToString());

                    if (row.Tag == null) //this is new row
                    {
                        var connect = new NpgsqlConnection("Host = localhost; Username = postgres; Password = postgres; DataBase = lab6");
                        connect.Open();
                        connect.Execute("insert into operator_table(login, password, is_admin) values (@login, @password, @is_admin)",
                            new {login, password, is_admin});
                        connect.Close();
                        row.Cells["password"].Value = password;
                    }
                    else
                    {
                        var connect = new NpgsqlConnection("Host = localhost; Username = postgres; Password = postgres; DataBase = lab6");
                        connect.Open();
                        string old_login = ((List<object>)row.Tag)[0].ToString();

                        
                        connect.Execute("update operator_table set login=@login, password=@password, is_admin=@is_admin where login = @old_login",
                            new { login, password, is_admin, old_login });
                        connect.Close();
                        row.Cells["password"].Value = password;
                    }

                    var list = new List<object>();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        list.Add(cell.Value);
                    }
                    row.Tag = list;

                }
        }
    }
}
