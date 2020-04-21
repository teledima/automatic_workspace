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
using SqlKata;
using SqlKata.Compilers;
using NpgsqlTypes;

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
                questions.AllowUserToAddRows = true;
                questions.AllowUserToDeleteRows = true;
                questions.ReadOnly = false;
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
            InitializeQuestions();
            InitializeOperators();
            InitializeSubjects();
            InitializeUsers();
            Initialize_user_ans();
        }
        private void InitializeQuestions()
        {
            questions.Rows.Clear();
            questions.Columns.Clear();
            DataTable data_subject = new DataTable();
            DataTable data_statuses = new DataTable();
            dates_load(data_statuses, "select name from statuses");
            dates_load(data_subject, "select subject_name from subject");
            {
                questions.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "id_question",
                    ValueType = typeof(uint),
                    Visible = false
                });
                questions.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "link_id",
                    HeaderText = "link_id",
                    ValueType = typeof(uint)
                });
                questions.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "count_view",
                    HeaderText = "count_view",
                    ValueType = typeof(uint),
                });
                questions.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "subject_id",
                    Visible = false
                });
                questions.Columns.Add(new DataGridViewComboBoxColumn
                {
                    Name = "subject",
                    HeaderText = "subject",
                    ValueType = typeof(string),
                    DataSource = data_subject,
                    ValueMember = "subject_name"
                });
                questions.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "user_id",
                    Visible = false
                });
                questions.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "login",
                    HeaderText = "login",
                    ValueType = typeof(string)
                });
                questions.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "age",
                    HeaderText = "age",
                    ValueType = typeof(uint)
                });
                questions.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "status_id",
                    HeaderText = "status_id",
                    Visible = false,
                    ValueType = typeof(uint)
                });
                questions.Columns.Add(new DataGridViewComboBoxColumn
                {
                    Name = "status",
                    HeaderText = "status",
                    ValueType = typeof(string),
                    DataSource = data_statuses,
                    DisplayMember = "name"
                });
            }
            using (var connect = new NpgsqlConnection(connect_string))
            {
                connect.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = connect,
                    CommandText = @"select * from questions inner join subject s2 on questions.subject_id = s2.id inner join users u on questions.user_id = u.id_user inner join statuses s on u.status_id = s.id_status;"
                };
                var reader = sCommand.ExecuteReader();
                while (reader.Read())
                {
                    questions.Rows.Add(reader["id_question"], reader["link_id"], reader["count_view"], reader["subject_id"], reader["subject_name"], reader["user_id"], reader["login"], reader["age"], reader["status_id"],
                        reader["name"]); //fill data_grid_view
                }
            }
            FillTag(questions);
        }
        
        private void InitializeUsers()
        {
            users.Rows.Clear();
            users.Columns.Clear();
            DataTable statuses = new DataTable();
            dates_load(statuses, "select * from users u inner join statuses s on u.status_id = s.id_status");
            users.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id_user",
                Visible = false
            });
            users.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "login",
                HeaderText = "login"
            });
            users.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "age",
                HeaderText = "age",
                ValueType = typeof(uint)
            });
            users.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "status_id",
                Visible = false
            });
            users.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "status",
                DataSource = statuses,
                ValueMember = "name"
            });
            using var connect = new NpgsqlConnection("Host = localhost; Username = postgres; password = postgres; DataBase = lab6");
            connect.Open();
            var reader = connect.ExecuteReader("select * from users u inner join statuses s on u.status_id = s.id_status");
            while (reader.Read())
            {
                users.Rows.Add(reader["id_user"], reader["login"], reader["age"], reader["status_id"], reader["name"]);
            }
            reader.Close();

            connect.Close();
            FillTag(users);
        }
        private void InitializeOperators()
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
                ValueType = typeof(string),
                Width = 210
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
            FillTag(data_grid_view_operators);

        }

        private void InitializeSubjects()
        {
            DataTable subjects_table = new DataTable();
            dates_load(subjects_table, "select * from subject");
            foreach(DataRow row in subjects_table.Rows)
            {
                var row_list = new ListViewItem() { Name = row["subject_name"].ToString(), Text = row["subject_name"].ToString()};

                subjects.Items.Add(row_list);
            }
        }

        private void Initialize_user_ans()
        {
            ans_quest.Rows.Clear();
            ans_quest.Columns.Clear();
            DataTable statuses = new DataTable();
            dates_load(statuses, "select name from statuses");
            ans_quest.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id_user",
                Visible = false
            });
            ans_quest.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "login",
                HeaderText = "login"
            });
            ans_quest.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "age",
                HeaderText = "age",
                ValueType = typeof(uint)
            });
            ans_quest.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "status_id",
                Visible = false,
                ValueType = typeof(uint)
            });
            ans_quest.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "status",
                HeaderText = "status",
                DataSource = statuses,
                DisplayMember = "name"
            });
        }
        private void dates_load(DataTable data, string command_text)
        {
            using var connect = new NpgsqlConnection(connect_string);
            connect.Open();
            data.Load(connect.ExecuteReader(command_text));
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
                            row.Cells["password"].Value = ((List<object>)row.Tag)[1];
                        }
                    }

                    if (row.Tag == null) //this is new row
                    {
                        string login = row.Cells["login"].Value.ToString();
                        string password = Hash.HashMD5(row.Cells["password"].Value.ToString() + Hash.salt);
                        bool is_admin = bool.Parse(row.Cells["is_admin"].Value.ToString());
                        var connect = new NpgsqlConnection("Host = localhost; Username = postgres; Password = postgres; DataBase = lab6");
                        connect.Open();
                        connect.Execute("insert into operator_table(login, password, is_admin) values (@login, @password, @is_admin)",
                            new {login, password, is_admin});
                        connect.Close();
                        row.Cells["password"].Value = password;
                    }
                    else
                    {
                        string login = row.Cells["login"].Value.ToString();
                        string old_login = ((List<object>)row.Tag)[0].ToString();
                        bool is_admin = bool.Parse(row.Cells["is_admin"].Value.ToString());
                        var connect = new NpgsqlConnection("Host = localhost; Username = postgres; Password = postgres; DataBase = lab6");
                        connect.Open();

                        string command;
                        if (row.Cells["password"].Value.ToString() == ((List<object>)row.Tag)[1].ToString())
                        {
                            command = "update operator_table set login = @login, is_admin = @is_admin where login=@old_login";
                            connect.Execute(command, new { login, is_admin, old_login });
                        }
                        else
                        {
                            string password = Hash.HashMD5(row.Cells["password"].Value.ToString() + Hash.salt);
                            command = "update operator_table set login = @login, password = @password, is_admin = @is_admin where login=@old_login";
                            connect.Execute("update operator_table set login=@login, password=@password, is_admin=@is_admin where login = @old_login",
                                     new { login, password, is_admin, old_login });
                            row.Cells["password"].Value = password;
                        }
                        

                        connect.Close();
                    }

                    var list = new List<object>();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        list.Add(cell.Value);
                    }
                    row.Tag = list;

                }
        }

        private void questions_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == questions.Columns["link_id"].Index)
            {
                foreach (DataGridViewRow row in questions.Rows)
                    if (row != questions.Rows[e.RowIndex] && !row.IsNewRow)
                        if (row.Cells["link_id"].Value.ToString() == questions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
                        {
                            MessageBox.Show("В таблице уже есть такое значение");
                            questions.Rows.Remove(questions.Rows[e.RowIndex]);
                            return;
                        }
            }
            AutoFillUser(questions, sender, e);
        }

        private void questions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (questions.Rows[e.RowIndex].IsNewRow) return;
            var connect = new NpgsqlConnection(connect_string);
            int id_question = (int)questions.Rows[e.RowIndex].Cells["id_question"].Value;
            connect.Open();
            var reader = connect.ExecuteReader("select id_user, login, age, id_status, name from answers inner join users u on answers.user_id_ans = u.id_user inner join statuses s on u.status_id = s.id_status where question_id = @id_question",
                new { id_question });
            ans_quest.Rows.Clear();
            while (reader.Read())
            {
                ans_quest.Rows.Add(reader["id_user"],reader["login"], reader["age"], reader["id_status"], reader["name"]);
            }
            FillTag(ans_quest);
            connect.Close();
        }

        private void ans_quest_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = ans_quest.Rows[e.RowIndex];
            if (!e.Cancel)
            {

            }
        }

        private void ans_quest_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (ans_quest.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                foreach (DataGridViewRow row in ans_quest.Rows)
                    if (row != ans_quest.Rows[e.RowIndex] && !row.IsNewRow)
                        if (row.Cells["login"].Value.ToString() == ans_quest.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
                        {
                            MessageBox.Show("В таблице уже есть такое значение");

                            //ans_quest.Rows.Remove(ans_quest.Rows[e.RowIndex]);
                            return;
                        }
            }
            else
            {
                MessageBox.Show("Логин не может быть пустым");
                ans_quest.Rows.Remove(ans_quest.Rows[e.RowIndex]);
                return;
            }
            AutoFillUser(ans_quest, sender, e);
        }

        private void AutoFillUser(DataGridView dataGrid, object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGrid.Columns["login"].Index)
            {
                using var connect = new NpgsqlConnection(connect_string);
                connect.Open();
                int? id_user = null;
                using (var command_check = new NpgsqlCommand() { Connection = connect })
                {
                    command_check.CommandText = "select id_user from users where login = @login";
                    command_check.Parameters.AddWithValue("@login", dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    id_user = (int?)command_check.ExecuteScalar();
                }
                if (id_user == null)
                {
                    dataGrid.Rows[e.RowIndex].Cells["age"].ReadOnly = false;
                    dataGrid.Rows[e.RowIndex].Cells["status"].ReadOnly = false;
                    return;
                }
                using (var command_select_data = new NpgsqlCommand() { Connection = connect })
                {
                    command_select_data.CommandText = "select login, age, name from users inner join statuses s on users.status_id = s.id_status where login = @login";
                    command_select_data.Parameters.AddWithValue("@login", dataGrid.Rows[e.RowIndex].Cells["login"].Value);
                    var reader = command_select_data.ExecuteReader();
                    bool check = reader.Read();
                    dataGrid.Rows[e.RowIndex].Cells["age"].Value = reader["age"] ?? null;
                    dataGrid.Rows[e.RowIndex].Cells["age"].ReadOnly = true;
                    dataGrid.Rows[e.RowIndex].Cells["status"].Value = reader["name"] ?? null;
                    dataGrid.Rows[e.RowIndex].Cells["status"].ReadOnly = true;
                }
                connect.Close();
            }
        }

        private void FillTag(DataGridView dataGrid)
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
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
    }
}
