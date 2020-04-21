using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Dapper;
using System;
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
            #endregion
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
            if (questions.Rows[e.RowIndex].IsNewRow || questions.IsCurrentRowDirty) return;
            var connect = new NpgsqlConnection(connect_string);
            int id_question = (int)questions.Rows[e.RowIndex].Cells["id_question"].Value;
            connect.Open();
            var reader = connect.ExecuteReader("select id_user, login, age, id_status, name from answers inner join users u on answers.user_id_ans = u.id_user inner join statuses s on u.status_id = s.id_status where question_id = @id_question",
                new { id_question });
            ans_quest.Rows.Clear();
            ans_quest.Visible = true;
            while (reader.Read())
            {
                ans_quest.Rows.Add(reader["id_user"],reader["login"], reader["age"], reader["id_status"], reader["name"]);
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
                    int id_status = (int)connect.ExecuteScalar("select id_status from statuses where name = @status", new { status });
                    int question_id = (int)ans_quest.Tag;
                    if (row.Tag == null) //если мы вставляем новую запись
                    {
                        int user_id_ans;
                        if (row.Cells["user_id"].Value == null) //если пользователя нет, то сначала создаём его
                        {
                            // добавляем нового пользователя в таблицу users
                            string login = row.Cells["login"].Value.ToString();
                            int age = (int)(uint)row.Cells["age"].Value;
                            int status_id = id_status;
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
                            int status_id = id_status;
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
                    List<object> list = new List<object>();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        list.Add(cell.Value);
                    }
                    row.Tag = list;
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
                    command_check.Parameters.AddWithValue("@login", dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    id_user = (int?)command_check.ExecuteScalar();
                }
                if (id_user == null)
                {
                    dataGrid.Rows[e.RowIndex].Cells["user_id"].Value = null;
                    dataGrid.Rows[e.RowIndex].Cells["user_id"].ReadOnly = false;
                    dataGrid.Rows[e.RowIndex].Cells["age"].ReadOnly = false;
                    dataGrid.Rows[e.RowIndex].Cells["status"].ReadOnly = false;
                    return;
                }
                using (var command_select_data = new NpgsqlCommand() { Connection = connect })
                {
                    command_select_data.CommandText = "select id_user, login, age, name from users inner join statuses s on users.status_id = s.id_status where login = @login";
                    command_select_data.Parameters.AddWithValue("@login", dataGrid.Rows[e.RowIndex].Cells["login"].Value);
                    var reader = command_select_data.ExecuteReader();
                    bool check = reader.Read();
                    dataGrid.Rows[e.RowIndex].Cells["user_id"].Value = reader["id_user"];
                    dataGrid.Rows[e.RowIndex].Cells["user_id"].ReadOnly = true;
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

        private void questions_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = questions.Rows[e.RowIndex];

            if (questions.IsCurrentRowDirty)
            {
                if (!e.Cancel)
                {
                    if (row.Cells["login"].Value == null)
                    {
                        MessageBox.Show("Заполните обязательное поле login", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (row.Cells["status"].Value == null) row.Cells["status"].Value = "Hide";
                    using var connect = new NpgsqlConnection(connect_string);
                    connect.Open();

                    using var command_status = new NpgsqlCommand() { Connection = connect };
                    command_status.CommandText = "select id_status from statuses where name = @name";
                    command_status.Parameters.AddWithValue("@name", row.Cells["status"].Value);
                    int id_status = (int)command_status.ExecuteScalar();

                    string subject = row.Cells["subject"].Value.ToString();
                    int id_subject = (int)connect.ExecuteScalar("select id from subject where subject_name = @subject", new { subject });

                    using var command_check = new NpgsqlCommand() { Connection = connect };
                    command_check.CommandText = "select id_user from users where login = @login";
                    command_check.Parameters.AddWithValue("@login", row.Cells["login"].Value.ToString());
                    int? id_user = (int?)command_check.ExecuteScalar();

                    using var command_user = new NpgsqlCommand() { Connection = connect };
                    command_user.Parameters.AddWithValue("@age", NpgsqlDbType.Unknown, row.Cells["age"].Value ?? DBNull.Value);
                    command_user.Parameters.AddWithValue("@status_id", NpgsqlDbType.Unknown, id_status);
                    command_user.Parameters.AddWithValue("@login", row.Cells["login"].Value);

                    using var command_for_questions = new NpgsqlCommand() { Connection = connect };
                    command_for_questions.Parameters.AddWithValue("@link_id", NpgsqlDbType.Unknown, row.Cells["link_id"].Value ?? System.DBNull.Value);
                    command_for_questions.Parameters.AddWithValue("@count_view", NpgsqlDbType.Unknown, row.Cells["count_view"].Value ?? DBNull.Value);
                    command_for_questions.Parameters.AddWithValue("@subject_id", id_subject);

                    if (row.Tag != null) //if a tag of the mutable row is null, then this row is new
                    {
                        func_update_user(connect, command_user, id_user, ((List<object>)row.Tag)[0]);
                        func_update_question(command_for_questions, row.Cells["id_question"].Value);
                        UpdateUserInfoDataGrid(row, id_status);
                    }
                    else
                    {
                        if (id_user == null) id_user = func_insert_user(command_user);
                        int id_question = func_insert_question(command_for_questions, id_user);

                        row.Cells["id_question"].Value = id_question;
                        row.Cells["subject_id"].Value = id_subject;
                        row.Cells["user_id"].Value = id_user;
                        row.Cells["status_id"].Value = id_status;
                    }
                    connect.Close();

                    var list = new List<object>();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        list.Add(cell.Value);
                    }
                    row.Tag = list; //change a tag this row 

                    row.ErrorText = string.Empty; //clear error text
                    row.Cells["age"].ReadOnly = false;
                    row.Cells["status"].ReadOnly = false;
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
            command_for_questions.Parameters.AddWithValue("@id_user", NpgsqlDbType.Unknown, id_user);
            return (int)command_for_questions.ExecuteScalar();
        }

        private void func_update_user(NpgsqlConnection connection, NpgsqlCommand command_user, int? id_user, object id_question)
        {
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
            command_update_questions.Parameters.AddWithValue("@user_id", NpgsqlDbType.Unknown, id_user);
            command_update_questions.Parameters.AddWithValue("@id_question", NpgsqlDbType.Unknown, id_question);
            command_update_questions.ExecuteNonQuery();
        }

        private void func_update_question(NpgsqlCommand command_for_questions, object id_question)
        {
            command_for_questions.CommandText = @"update questions set link_id = @link_id, count_view = @count_view, subject_id = @subject_id where id_question = @id_question";
            command_for_questions.Parameters.AddWithValue("@id_question", NpgsqlDbType.Unknown, id_question);
            command_for_questions.ExecuteNonQuery();
        }

        private void UpdateUserInfoDataGrid(DataGridViewRow row, int id_status)
        {
            if (row.Cells["login"].Value.ToString() == ((List<object>)row.Tag)[6].ToString())
            {
                if ((int?)row.Cells["status_id"].Value != id_status) // if status is changed
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
    }
}
