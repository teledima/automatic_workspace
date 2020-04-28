using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Dapper;
using System;
using NpgsqlTypes;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Extensions;
using SqlKata.Execution;

namespace automatic_workspace
{
    public partial class Form_workspace : Form
    {
        private readonly string connect_string = "Host = localhost; Username = postgres; password = postgres; Database = lab6";

        private delegate void StatusesHandler(DataGridView sender, InfoEventArgs e);
        private event StatusesHandler ChangeStatus;

        public Form_workspace()
        {
            InitializeComponent();
            if (User_info.Current_status == User_info.Status.Operator || User_info.Current_status == User_info.Status.Admin)
            {
                questions.AllowUserToAddRows = true;
                questions.AllowUserToDeleteRows = true;
                questions.ReadOnly = false;

                ans_quest.AllowUserToAddRows = true;
                ans_quest.AllowUserToDeleteRows = true;
                ans_quest.ReadOnly = false;

                subjects.AllowUserToAddRows = true;
                subjects.AllowUserToDeleteRows = true;
                subjects.ReadOnly = false;

                users.AllowUserToAddRows = true;
                users.AllowUserToDeleteRows = true;
                users.ReadOnly = false;

                this.statuses.AllowUserToAddRows = true;
                this.statuses.AllowUserToDeleteRows = true;
                this.statuses.ReadOnly = false;
            }
            if (User_info.Current_status == User_info.Status.Admin)
            {
                data_grid_view_operators.AllowUserToAddRows = true;
                data_grid_view_operators.AllowUserToDeleteRows = true;
                data_grid_view_operators.ReadOnly = false;
            }
            if (User_info.Current_status == User_info.Status.Guest || User_info.Current_status == User_info.Status.Operator)
            {
                operators_page.Dispose();
            }
            InitializeQuestions();
            InitializeOperators();
            InitializeSubjects();
            InitializeUsers();
            Initialize_user_ans();
            InitializeStatuses();

            DataTable statuses = new DataTable();
            dates_load(statuses, "select name from statuses");
            comboBox_query.DataSource = statuses;
            comboBox_query.DisplayMember = "name";
            comboBox_query.Text = string.Empty;
        }
        private void InitializeQuestions()
        {
            questions.Rows.Clear();
            questions.Columns.Clear();
            DataTable data_subject = new DataTable();
            DataTable data_statuses = new DataTable();
            dates_load(data_statuses, "select name from statuses");
            dates_load(data_subject, "select name from subject");
            #region
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
                DisplayMember = "name"
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

            #endregion
            using (var connect = new NpgsqlConnection(connect_string))
            {
                connect.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = connect,
                    CommandText = @"select id_question, link_id, count_view, subject_id, subject.name s_name, user_id, login, age, status_id, s.name st_name from questions
                                    inner join subject on questions.subject_id = subject.id
                                    left outer join users u on questions.user_id = u.id_user
                                    left outer join statuses s on u.status_id = s.id_status"
                };
                var reader = sCommand.ExecuteReader();
                while (reader.Read())
                {
                    questions.Rows.Add(reader["id_question"], reader["link_id"], reader["count_view"], reader["subject_id"], reader["s_name"], reader["user_id"], reader["login"], reader["age"], reader["status_id"],
                        reader["st_name"]); //fill data_grid_view
                }
            }
            questions.Columns["age"].ReadOnly = true;
            questions.Columns["status"].ReadOnly = true;
            questions.Columns["status_id"].ReadOnly = true;
            FillTag(questions);
        }
        private void InitializeUsers()
        {
            users.Rows.Clear();
            users.Columns.Clear();
            DataTable statuses = new DataTable();
            dates_load(statuses, "select * from statuses");
            users.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id_user",
                Visible =false
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
            var reader = connect.ExecuteReader("select * from users u left join statuses s on u.status_id = s.id_status");
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
                Name = "id_user",
                Visible =false
            });
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
            var reader = connect.ExecuteReader("select id_user, login, password, is_admin from operator_table");
            while (reader.Read())
            {
                data_grid_view_operators.Rows.Add(reader["id_user"], reader["login"], reader["password"], reader["is_admin"]);
            }
            reader.Close();

            connect.Close();
            FillTag(data_grid_view_operators);

        }
        private void Initialize_user_ans()
        {
            ans_quest.Rows.Clear();
            ans_quest.Columns.Clear();
            DataTable statuses = new DataTable();
            dates_load(statuses, "select name from statuses");
            ans_quest.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "user_id",
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
            ans_quest.Visible = false;
            ans_quest.Columns["age"].ReadOnly = true;
            ans_quest.Columns["status_id"].ReadOnly = true;
            ans_quest.Columns["status"].ReadOnly = true;
        }
        private void InitializeSubjects()
        {
            subjects.Rows.Clear();
            subjects.Columns.Clear();
            subjects.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "subject_id",
                Visible = false
            });
            subjects.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "subject",
                HeaderText = "subject",
            });
            using var connect = new NpgsqlConnection(connect_string);
            connect.Open();
            var reader = connect.ExecuteReader("select * from subject");
            while (reader.Read())
            {
                subjects.Rows.Add(reader["id"], reader["name"]);
            }
            connect.Close();
            FillTag(subjects);
        }
        private void InitializeStatuses()
        {
            statuses.Rows.Clear();
            statuses.Columns.Clear();
            statuses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id_status",
                Visible = false
            });
            statuses.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "status",
                HeaderText = "status"
            });
            using var connect = new NpgsqlConnection(connect_string);
            connect.Open();
            var reader = connect.ExecuteReader("select * from statuses where id_status != 3");
            while (reader.Read())
                statuses.Rows.Add(reader["id_status"], reader["name"]);
            connect.Close();
            FillTag(statuses);
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
                    int? id_user = (int?)row.Cells["id_user"].Value;
                    if (row.Tag == null) //this is new row
                    {
                        string login = row.Cells["login"].Value.ToString();
                        string password = Hash.HashMD5(row.Cells["password"].Value.ToString() + Hash.salt);
                        bool is_admin = bool.Parse(row.Cells["is_admin"].Value.ToString());
                        var connect = new NpgsqlConnection("Host = localhost; Username = postgres; Password = postgres; DataBase = lab6");
                        connect.Open();
                        id_user = (int?)connect.ExecuteScalar("insert into operator_table(login, password, is_admin) values (@login, @password, @is_admin) returning id_user",
                            new { login, password, is_admin });
                        connect.Close();
                        row.Cells["password"].Value = password;
                    }
                    else
                    {
                        string login = row.Cells["login"].Value.ToString();
                        string old_login = ((List<object>)row.Tag)[1].ToString();
                        bool is_admin = bool.Parse(row.Cells["is_admin"].Value.ToString());
                        var connect = new NpgsqlConnection("Host = localhost; Username = postgres; Password = postgres; DataBase = lab6");
                        connect.Open();

                        string command;
                        if (row.Cells["password"].Value.ToString() == ((List<object>)row.Tag)[2].ToString())
                        {
                            command = "update operator_table set login = @login, is_admin = @is_admin where login=@old_login";
                            connect.Execute(command, new { login, is_admin, old_login });
                        }
                        else
                        {
                            string password = Hash.HashMD5(row.Cells["password"].Value.ToString() + Hash.salt);
                            connect.Execute("update operator_table set login=@login, password=@password, is_admin=@is_admin where login = @old_login",
                                     new { login, password, is_admin, old_login });
                            row.Cells["password"].Value = password;
                        }


                        connect.Close();
                    }

                    row.Cells["id_user"].Value = id_user;
                    FillRowTag(row);
                }
        }

        private void users_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = users.Rows[e.RowIndex];
            if (users.IsCurrentRowDirty)
            {
                if (!e.Cancel)
                {
                    using var connect = new NpgsqlConnection(connect_string);
                    connect.Open();
                    int? id_user = (int?)row.Cells["id_user"].Value;
                    string login = row.Cells["login"].Value.ToString();
                    object age = int.Parse(row.Cells["age"].Value.ToString());
                    object status = row.Cells["status"].Value;
                    int? id_status = (int?)connect.ExecuteScalar("select id_status from statuses where name = @status", new { status });
                    
                    if (row.Tag == null)
                    {
                        id_user = (int?)connect.ExecuteScalar("insert into users(login, age, status_id) values (@login, @age, @id_status) returning id_user",
                            new { login, age, id_status});

                    }
                    else
                    {
                        connect.Execute("update users set login = @login, age = @age, status_id = @id_status where id_user = @id_user",
                            new { login, age, id_status, id_user });
                        Update_User_info_questions(id_user, login, age, id_status, status);
                    }
                    connect.Close();
                    row.Cells["id_user"].Value = id_user;
                    row.Cells["status_id"].Value = id_status;
                    FillRowTag(row);
                }
            }
        }
        private void Update_User_info_questions(object id_user, object new_login, object new_age, object new_status_id, object new_status)
        {
            foreach (DataGridViewRow row in questions.Rows)
            {
                if (!row.IsNewRow)
                    if (row.Cells["user_id"].Value.Equals(id_user))
                    {
                        row.Cells["login"].Value = new_login;
                        row.Cells["age"].Value = new_age;
                        row.Cells["status_id"].Value = new_status_id;
                        row.Cells["status"].Value = new_status;
                        FillRowTag(row);
                    }
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
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (questions.Rows[e.RowIndex].IsNewRow || questions.IsCurrentRowDirty
                || questions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) return;
            var connect = new NpgsqlConnection(connect_string);
            int id_question = (int)questions.Rows[e.RowIndex].Cells["id_question"].Value;
            connect.Open();
            var reader = connect.ExecuteReader("select id_user, login, age, id_status, name from answers inner join users u on answers.user_id_ans = u.id_user inner join statuses s on u.status_id = s.id_status where question_id = @id_question",
                new { id_question });
            ans_quest.Rows.Clear();
            ans_quest.Visible = true;
            while (reader.Read())
            {
                ans_quest.Rows.Add(reader["id_user"], reader["login"], reader["age"], reader["id_status"], reader["name"]);
            }
            ans_quest.Tag = id_question;
            FillTag(ans_quest);
            connect.Close();
        }

        private void ans_quest_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {

            var row = ans_quest.Rows[e.RowIndex];
            if (!e.Cancel)
            {
                if (ans_quest.IsCurrentRowDirty)
                {
                    using var connect = new NpgsqlConnection(connect_string);
                    connect.Open();
                    // ищем id_status
                    string status = row.Cells["status"].Value.ToString();
                    int? id_status = (int?)connect.ExecuteScalar("select id_status from statuses where name = @status", new { status });
                    int question_id = (int)ans_quest.Tag;
                    if (row.Tag == null) //если мы вставляем новую запись
                    {
                        int user_id_ans;
                        if (row.Cells["user_id"].Value == null) //если пользователя нет, то сначала создаём его
                        {
                            // добавляем нового пользователя в таблицу users
                            string login = row.Cells["login"].Value.ToString();
                            int age = (int)(uint)row.Cells["age"].Value;
                            int? status_id = id_status;
                            user_id_ans = (int)connect.ExecuteScalar("insert into users(login, age, status_id) values (@login, @age, @status_id) returning id_user", new { login, age, status_id });
                            // добавлеям пользователя в таблицу answers
                        }
                        else // иначе, если пользователь существует то надо только вставить новую запись в answers
                        {
                            user_id_ans = (int)row.Cells["user_id"].Value;
                        }
                        connect.Execute("insert into answers(question_id, user_id_ans) values (@question_id, @user_id_ans)", new { question_id, user_id_ans });
                    }
                    else // если мы обновляем запись
                    {
                        int old_user_id = (int)((List<object>)row.Tag)[0];
                        int new_user_id;
                        if (row.Cells["user_id"].Value == null) // если пользователя нет, то мы сначала вставляем нового пользователя, затем заменяем старый id_user на новый
                        {
                            // добавляем нового пользователя в таблицу users
                            string login = row.Cells["login"].Value.ToString();
                            int age = (int)row.Cells["age"].Value;
                            int? status_id = id_status;
                            new_user_id = (int)connect.ExecuteScalar("insert into users(login, age, status_id) values (@login, @age, @status_id) returning id_user", new { login, age, status_id });
                            // обновляем user_id_ans в таблице answers
                            connect.Execute("update answers set user_id_ans = @new_user_id where question_id = @question_id and user_id_ans = @old_user_id",
                                new { new_user_id, question_id, old_user_id });
                        }
                        else // если пользователь есть, то надо просто заменить старый id_user
                        {
                            new_user_id = (int)row.Cells["user_id"].Value;
                        }
                        connect.Execute("update answers set user_id_ans = @new_user_id where question_id = @question_id and user_id_ans = @old_user_id",
                            new { new_user_id, question_id, old_user_id });
                    }
                    connect.Close();
                    FillRowTag(row);
                }
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
                    command_check.Parameters.AddWithValue("@login", dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value ?? DBNull.Value);
                    id_user = (int?)command_check.ExecuteScalar();
                }
                if (id_user == null)
                {
                    dataGrid.Rows[e.RowIndex].Cells["user_id"].Value = null;
                    dataGrid.Rows[e.RowIndex].Cells["user_id"].ReadOnly = false;
                    dataGrid.Rows[e.RowIndex].Cells["age"].ReadOnly = false;
                    dataGrid.Rows[e.RowIndex].Cells["status_id"].ReadOnly = false;
                    dataGrid.Rows[e.RowIndex].Cells["status"].ReadOnly = false;
                    return;
                }
                using (var command_select_data = new NpgsqlCommand() { Connection = connect })
                {
                    command_select_data.CommandText = "select id_user, login, age, id_status, name from users left join statuses s on users.status_id = s.id_status where login = @login";
                    command_select_data.Parameters.AddWithValue("@login", dataGrid.Rows[e.RowIndex].Cells["login"].Value);
                    var reader = command_select_data.ExecuteReader();
                    bool check = reader.Read();
                    dataGrid.Rows[e.RowIndex].Cells["user_id"].Value = reader["id_user"];
                    dataGrid.Rows[e.RowIndex].Cells["user_id"].ReadOnly = true;
                    dataGrid.Rows[e.RowIndex].Cells["age"].Value = reader["age"] ?? null;
                    dataGrid.Rows[e.RowIndex].Cells["age"].ReadOnly = true;
                    dataGrid.Rows[e.RowIndex].Cells["status_id"].Value = reader["id_status"] ?? null;
                    dataGrid.Rows[e.RowIndex].Cells["status_id"].ReadOnly = true;
                    dataGrid.Rows[e.RowIndex].Cells["status"].Value = reader["name"] ?? null;
                    dataGrid.Rows[e.RowIndex].Cells["status"].ReadOnly = true;
                }
                connect.Close();
            }
        }

        private void FillTag(DataGridView dataGrid)
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
                FillRowTag(row);
        }

        private void FillRowTag(DataGridViewRow row)
        {
            if (!row.IsNewRow)
            {
                var tag = new List<object>();
                foreach (DataGridViewCell cell in row.Cells)
                    tag.Add(cell.Value);
                row.Tag = tag;
            } //assign a tag for each added row equal his values
        }

        private void questions_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = questions.Rows[e.RowIndex];
            if (!row.IsNewRow)
            {
                if (!e.Cancel)
                {
                    if (row.Cells["link_id"].Value == null || row.Cells["link_id"].Value == DBNull.Value || row.Cells["subject"].Value == null)
                    {
                        if (MessageBox.Show("Заполните обязательные поля {link_id, subject}", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                            e.Cancel = true;
                        else
                        {
                            if (row.Cells["id_question"].Value != null)
                            {
                                for (int i = 0; i < row.Cells.Count; i++)
                                    row.Cells[i].Value = ((List<object>)row.Tag)[i];
                            }
                        }
                        return;
                    }
                    if (questions.IsCurrentRowDirty)
                    {
                        using var connect = new NpgsqlConnection(connect_string);
                        connect.Open();

                        using var command_status = new NpgsqlCommand() { Connection = connect };
                        command_status.CommandText = "select id_status from statuses where name = @name";
                        command_status.Parameters.AddWithValue("@name", row.Cells["status"].Value ?? DBNull.Value);
                        int? id_status = (int?)command_status.ExecuteScalar();

                        string subject = row.Cells["subject"].Value.ToString();
                        int? id_subject = (int?)connect.ExecuteScalar("select id from subject where name = @subject", new { subject });

                        using var command_check = new NpgsqlCommand() { Connection = connect };
                        command_check.CommandText = "select id_user from users where login = @login";
                        command_check.Parameters.AddWithValue("@login", row.Cells["login"].Value ?? DBNull.Value);
                        int? id_user = (int?)command_check.ExecuteScalar();

                        using var command_user = new NpgsqlCommand() { Connection = connect };
                        command_user.Parameters.AddWithValue("@age", NpgsqlDbType.Unknown, row.Cells["age"].Value ?? DBNull.Value);
                        command_user.Parameters.AddWithValue("@status_id", NpgsqlDbType.Unknown, (object)id_status ?? DBNull.Value);
                        command_user.Parameters.AddWithValue("@login", row.Cells["login"].Value ?? DBNull.Value);

                        using var command_for_questions = new NpgsqlCommand() { Connection = connect };
                        command_for_questions.Parameters.AddWithValue("@link_id", NpgsqlDbType.Unknown, row.Cells["link_id"].Value ?? DBNull.Value);
                        command_for_questions.Parameters.AddWithValue("@count_view", NpgsqlDbType.Unknown, row.Cells["count_view"].Value ?? DBNull.Value);
                        command_for_questions.Parameters.AddWithValue("@subject_id", id_subject);

                        if (row.Tag != null) //if a tag of the mutable row is null, then this row is new
                        {
                            func_update_user(connect, command_user, id_user, ((List<object>)row.Tag)[0], row.Cells["login"].Value);
                            if (row.Cells["login"].Value != null)
                            {
                                UpdateUserInfoDataGrid(row, id_status);
                            }

                            func_update_question(command_for_questions, row.Cells["id_question"].Value);
                        }
                        else
                        {
                            if (id_user == null && row.Cells["login"].Value != null)
                               id_user = func_insert_user(command_user);
                            int id_question = func_insert_question(command_for_questions, id_user);

                            row.Cells["id_question"].Value = id_question;
                            row.Cells["subject_id"].Value = id_subject;
                            row.Cells["user_id"].Value = id_user;
                            row.Cells["status_id"].Value = id_status;
                        }
                        connect.Close();

                        FillRowTag(row);

                        row.ErrorText = string.Empty; //clear error text
                        row.Cells["age"].ReadOnly = false;
                        row.Cells["status_id"].ReadOnly = false;
                        row.Cells["status"].ReadOnly = false;
                    }
                }
            }
        }
        private int? func_insert_user(NpgsqlCommand command_user)
        {
            command_user.CommandText = @"insert into users(login, age, status_id) values (@login, @age, @status_id) returning id_user";
            return (int?)command_user.ExecuteScalar();
        }

        private int func_insert_question(NpgsqlCommand command_for_questions, int? id_user)
        {
            command_for_questions.CommandText = @"insert into questions(link_id, count_view, subject_id, user_id) values (@link_id, @count_view, @subject_id, @id_user) returning id_question";
            command_for_questions.Parameters.AddWithValue("@id_user", NpgsqlDbType.Unknown, (object)id_user ?? DBNull.Value);
            return (int)command_for_questions.ExecuteScalar();
        }

        private void func_update_user(NpgsqlConnection connection, NpgsqlCommand command_user, int? id_user, object id_question, object login)
        {
            if (login != null)
                if (id_user == null) //если нового пользователя нету, то мы вставляем его 
                {
                    command_user.CommandText = "insert into users(login, age, status_id) values (@login, @age, @status_id) returning id_user";

                    id_user = (int)command_user.ExecuteScalar();
                }
                else
                {
                    command_user.CommandText = "update users set age = @age, status_id = @status_id where login = @login";
                    command_user.ExecuteNonQuery();
                }

            using var command_update_questions = new NpgsqlCommand() { Connection = connection };
            command_update_questions.CommandText = "update questions set user_id = @user_id where  id_question = @id_question";
            command_update_questions.Parameters.AddWithValue("@user_id", NpgsqlDbType.Unknown, (object)id_user ?? DBNull.Value);
            command_update_questions.Parameters.AddWithValue("@id_question", NpgsqlDbType.Unknown, id_question);
            command_update_questions.ExecuteNonQuery();
        }

        private void func_update_question(NpgsqlCommand command_for_questions, object id_question)
        {
            command_for_questions.CommandText = @"update questions set link_id = @link_id, count_view = @count_view, subject_id = @subject_id where id_question = @id_question";
            command_for_questions.Parameters.AddWithValue("@id_question", NpgsqlDbType.Unknown, id_question);
            command_for_questions.ExecuteNonQuery();
        }

        private void UpdateUserInfoDataGrid(DataGridViewRow row, int? id_status)
        {
            if (row.Cells["login"].Value.ToString() == ((List<object>)row.Tag)[6].ToString())
            {
                if (!row.Cells["status_id"].Value.Equals(id_status)) // if status is changed
                {
                    foreach (DataGridViewRow row_up in questions.Rows)
                    {
                        if (!row_up.IsNewRow)
                            if (row_up.Cells["login"].Value.ToString() == row.Cells["login"].Value.ToString()) // in all rows with this login change the status
                            {
                                row_up.Cells["status_id"].Value = id_status;
                                row_up.Cells["status"].Value = row.Cells["status"].Value;
                            }
                    }
                }

                if (row.Cells["age"].Value.ToString() != ((List<object>)row.Tag)[7].ToString())
                {
                    foreach (DataGridViewRow row_up in questions.Rows)
                    {
                        if (!row_up.IsNewRow)
                            if (row_up.Cells["login"].Value.ToString() == row.Cells["login"].Value.ToString()) // in all rows with this login change the status
                            {
                                row_up.Cells["age"].Value = row.Cells["age"].Value;
                            }
                    }
                }
            }
        }

        private void Infomation_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView data = (DataGridView)sender;
            var row = data.Rows[e.RowIndex];
            if (!e.Cancel)
            {
                if (data.IsCurrentRowDirty)
                {
                    using var connect = new NpgsqlConnection(connect_string);
                    connect.Open();
                    if (row.Cells[1].Value == null) return;
                    object new_id = row.Cells[0].Value;
                    string status = row.Cells[1].Value.ToString();
                    string table_name, col_name, index_col;
                    col_name = "name";
                    if (data == statuses)
                    {
                        table_name = "statuses";
                        index_col = "status";
                    }
                    else
                    {
                        table_name = "subject";
                        index_col = "subject";
                    }

                    if (HasDuplicates(data, e.ColumnIndex, row.Cells[1].Value)) return;
                    if (row.Tag == null)
                    {
                        var res = new PostgresCompiler()
                            .Compile(new Query(table_name)
                            .AsInsert(new { name = status }, true));
                        using var command = new NpgsqlCommand() { Connection = connect, CommandText = res.Sql };
                        command.Parameters.AddWithValue(res.NamedBindings.Keys.AsList()[0], res.NamedBindings.Values.AsList()[0]);
                        new_id = command.ExecuteScalar();
                        ChangeStatus?.Invoke(data, new InfoEventArgs(true, table_name, col_name, index_col));
                    }
                    else
                    {
                        // при изменении имени существующего статуса необходимо обновить его сначала в базе данных, потом в data grid
                        string col_id = data == statuses ? "id_status" : "id";
                        var res = new PostgresCompiler()
                            .Compile(new Query(table_name).AsUpdate(new string[] { col_name }, new string[] { status }).Where(col_id, ((List<object>)row.Tag)[0]));
                        using var command = new NpgsqlCommand()
                        {
                            Connection = connect,
                            CommandText = res.Sql
                        };
                        command.Parameters.AddWithValue(res.NamedBindings.Keys.AsList()[0], res.NamedBindings.Values.AsList()[0]);
                        command.Parameters.AddWithValue(res.NamedBindings.Keys.AsList()[1], res.NamedBindings.Values.AsList()[1]);
                        command.ExecuteNonQuery();
                        ChangeStatus?.Invoke(data, new InfoEventArgs(false, table_name, col_name, index_col, data == statuses ? "status_id" : "subject_id", ((List<object>)row.Tag)[0], row.Cells[1].Value));
                    }
                    row.Cells[0].Value = new_id;
                    connect.Close();
                }
            }
            FillTag(data);
        }

        bool HasDuplicates(DataGridView data, int index_primary_key, object find_value)
        {
            int count = 0;
            foreach (DataGridViewRow row in data.Rows)
                if (row.Cells[index_primary_key].Value == find_value)
                    count++;

            if (count > 1) return true;

            return false;
        }

        private void OnChangeItem(DataGridView sender, InfoEventArgs e)
        {
            if (e.Is_added == false)
            {
                foreach (DataGridViewRow row in questions.Rows)
                    if (!row.IsNewRow)
                        if (row.Cells[e.Index_Changed].Value.Equals(e.Id_changing))
                            row.Cells[e.Index_Column_Value].Value = e.New_Value;

                if (sender == statuses)
                {
                    foreach (DataGridViewRow row in users.Rows)
                        if (!row.IsNewRow)
                            if (row.Cells[e.Index_Changed].Value.Equals(e.Id_changing))
                                row.Cells[e.Index_Column_Value].Value = e.New_Value;

                    foreach (DataGridViewRow row in ans_quest.Rows)
                        if (!row.IsNewRow)
                            if (row.Cells[e.Index_Changed].Value.Equals(e.Id_changing))
                                row.Cells[e.Index_Column_Value].Value = e.New_Value;
                }
            }
            DataTable tableStatus = new DataTable();
            dates_load(tableStatus, new PostgresCompiler().Compile(new Query(e.Table_name).Select(e.Column_name)).RawSql);

            ((DataGridViewComboBoxColumn)questions.Columns[e.Index_Column_Value]).DataSource = tableStatus;
            ((DataGridViewComboBoxColumn)questions.Columns[e.Index_Column_Value]).DisplayMember = e.Column_name;

            if (sender == statuses)
            {
                ((DataGridViewComboBoxColumn)ans_quest.Columns[e.Index_Column_Value]).DataSource = tableStatus;
                ((DataGridViewComboBoxColumn)ans_quest.Columns[e.Index_Column_Value]).DisplayMember = e.Column_name;

                ((DataGridViewComboBoxColumn)users.Columns[e.Index_Column_Value]).DataSource = tableStatus;
                ((DataGridViewComboBoxColumn)users.Columns[e.Index_Column_Value]).DisplayMember = e.Column_name;
            }
        }

        private void questions_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void Delete_one_row(DataGridViewRow row)
        {
            DataGridView gridView = row.DataGridView;
            using var connect = new NpgsqlConnection(connect_string);
            object id = row.Cells[0].Value;
            connect.Open();
            if (gridView == questions)
            {
                connect.Execute("delete from questions where id_question = @id", new { id });
                ans_quest.Rows.Clear();
            }
            else if (gridView == ans_quest)
            {
                int question_id = (int)gridView.Tag;
                connect.Execute("delete from answers where question_id = @question_id and user_id_ans = @id",
                    new { question_id, id });
            }
            else if (gridView == data_grid_view_operators)
            {
                connect.Execute("delete from operator_table where id_user = @id", new { id });
            }
            else if (gridView == users)
            {
                connect.Execute("delete from users where id_user = @id", new { id });
                Setnull_user(id);
            }
            else if (gridView == statuses)
            {
                connect.Execute("delete from statuses where id_status = @id", new { id });
                Setnull_status(id);
            }
            else if (gridView == subjects)
            {
                
                connect.Execute("delete from subject where id = @id", new { id });
                Setnull_subject(id);
            }

            connect.Close();
        }

        private bool HasQuestionsWithThisSubject(object id_subject)
        {
            foreach (DataGridViewRow row in questions.Rows)
                if (row.Cells["subject_id"].Value != null)
                    if (row.Cells["subject_id"].Value.Equals(id_subject))
                        return true;
            return false;

        }
        private void Setnull_user(object id_user)
        {
            foreach (DataGridViewRow row in questions.Rows)
            {
                if (row.Cells["user_id"].Value != null)
                    if (row.Cells["user_id"].Value.Equals(id_user))
                    {
                        row.Cells["user_id"].Value = null;
                        row.Cells["login"].Value = null;
                        row.Cells["age"].Value = null;
                        row.Cells["status_id"].Value = null;
                        row.Cells["status"].Value = null;
                    }
            }

            ans_quest.Visible = false;
        }

        private void Setnull_status(object id_status)
        {
            foreach (DataGridViewRow row in users.Rows)
                if (row.Cells["status"].Value != null)
                    if (row.Cells["status"].Value.Equals(id_status))
                    {
                        row.Cells["status_id"].Value = null;
                        row.Cells["status"].Value = null;
                    }

            foreach (DataGridViewRow row in questions.Rows)
                if (row.Cells["status"].Value != null)
                    if (row.Cells["status"].Value.Equals(id_status))
                    {
                        row.Cells["status_id"].Value = null;
                        row.Cells["status"].Value = null;
                    }

            ans_quest.Visible = false;
        }

        private void Setnull_subject(object id_subject)
        {
            foreach (DataGridViewRow row in questions.Rows)
                if (row.Cells["subject"].Value != null)
                    if (row.Cells["subject"].Value.Equals(id_subject))
                    {
                        row.Cells["subject_id"].Value = null;
                        row.Cells["subject"].Value = null;
                    }
        }
        private void KeyDown_grid(object sender, KeyEventArgs e)
        {
            DataGridView dataGrid = (DataGridView)sender;
            switch (e.KeyCode)
            {
                case Keys.Back:
                    foreach (DataGridViewRow row in dataGrid.SelectedRows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.ColumnIndex != 0)
                                cell.Value = null;
                        }
                    }
                    break;
            }
        }

        private void UserDeletingRow_grid(object sender, DataGridViewRowCancelEventArgs e)
        {
            var row = e.Row;
            DataGridView dataGrid = (DataGridView)sender;
            if (!row.IsNewRow)
            {
                if (dataGrid == subjects)
                    if (HasQuestionsWithThisSubject(row.Cells[0].Value))
                    {
                        MessageBox.Show("Невозмможно удалить данную строку так как есть вопросы связанные с этим предметом");
                        e.Cancel = true;
                        return;
                    }
                Delete_one_row(row);
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            label_first.Text = string.Empty;
            object current_value = numericUpDown1.Value;
            var res = new PostgresCompiler().Compile(new Query("users").Select(new string[] { "login", "age" }).Where("age", ">", current_value));
            using var connect = new NpgsqlConnection(connect_string);
            connect.Open();
            using var command = new NpgsqlCommand()
            {
                Connection = connect,
                CommandText = res.Sql
            };
            command.Parameters.AddWithValue(res.NamedBindings.Keys.AsList()[0], res.NamedBindings.Values.AsList()[0]);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                label_first.Text += string.Format("{0}  {1}", reader["login"].ToString(), reader["age"].ToString());
                label_first.Text += "\n";
            }
            connect.Close();
        }

        private void comboBox_query_TextChanged(object sender, EventArgs e)
        {
            if (comboBox_query.Text != null)
            {
                label_second.Text = string.Empty;
                using var connect = new NpgsqlConnection(connect_string);
                connect.Open();
                var query = new PostgresCompiler().Compile(new Query("questions")
                    .Join("users", "user_id", "id_user")
                    .Where("status_id", "=",
                    new Query("statuses")
                        .Select("id_status")
                        .Where("name", "=", comboBox_query.Text))
                        .AsCount());
                using var command = new NpgsqlCommand() { Connection = connect, CommandText = query.Sql };
                command.Parameters.AddWithValue(query.NamedBindings.Keys.AsList()[0], query.NamedBindings.Values.AsList()[0]);
                object count = command.ExecuteScalar();
                label_second.Text = count.ToString() ?? "Empty";
                connect.Close();
            }
        }
    }

    public class InfoEventArgs
    {
        public bool Is_added { get; private set; }

        public string Table_name { get; private set; }

        public string Column_name { get; private set; }

        public string Index_Column_Value { get; private set; }

        public string Index_Changed { get; private set; }

        public object Id_changing { get; private set; }

        public object New_Value { get; private set; }

        public InfoEventArgs(bool is_added, string table_name, string column_name, string index_column)
        {
            this.Is_added = is_added;
            this.Table_name = table_name;
            this.Column_name = column_name;
            this.Index_Column_Value = index_column;
        }

        public InfoEventArgs(bool is_added, string table_name, string column_name, string index_column_value, string index_changed, object id_changing, object new_value)
        {
            this.Is_added = is_added;
            this.Table_name = table_name;
            this.Column_name = column_name;
            this.Index_Column_Value = index_column_value;
            this.Index_Changed = index_changed;
            this.Id_changing = id_changing;
            this.New_Value = new_value;
        }
    }
}
