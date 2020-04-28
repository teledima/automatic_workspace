namespace automatic_workspace
{
    partial class Form_workspace
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.main_page = new System.Windows.Forms.TabPage();
            this.ans_quest = new System.Windows.Forms.DataGridView();
            this.questions = new System.Windows.Forms.DataGridView();
            this.subject_page = new System.Windows.Forms.TabPage();
            this.subjects = new System.Windows.Forms.DataGridView();
            this.users_page = new System.Windows.Forms.TabPage();
            this.users = new System.Windows.Forms.DataGridView();
            this.statuses_page = new System.Windows.Forms.TabPage();
            this.statuses = new System.Windows.Forms.DataGridView();
            this.operators_page = new System.Windows.Forms.TabPage();
            this.data_grid_view_operators = new System.Windows.Forms.DataGridView();
            this.query_page = new System.Windows.Forms.TabPage();
            this.label_second = new System.Windows.Forms.Label();
            this.label_first = new System.Windows.Forms.Label();
            this.comboBox_query = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.main_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ans_quest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questions)).BeginInit();
            this.subject_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subjects)).BeginInit();
            this.users_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.users)).BeginInit();
            this.statuses_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statuses)).BeginInit();
            this.operators_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_view_operators)).BeginInit();
            this.query_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.main_page);
            this.tabControl.Controls.Add(this.subject_page);
            this.tabControl.Controls.Add(this.users_page);
            this.tabControl.Controls.Add(this.statuses_page);
            this.tabControl.Controls.Add(this.operators_page);
            this.tabControl.Controls.Add(this.query_page);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1054, 669);
            this.tabControl.TabIndex = 0;
            // 
            // main_page
            // 
            this.main_page.Controls.Add(this.ans_quest);
            this.main_page.Controls.Add(this.questions);
            this.main_page.Location = new System.Drawing.Point(4, 25);
            this.main_page.Name = "main_page";
            this.main_page.Padding = new System.Windows.Forms.Padding(3);
            this.main_page.Size = new System.Drawing.Size(1046, 640);
            this.main_page.TabIndex = 0;
            this.main_page.Text = "main page";
            this.main_page.UseVisualStyleBackColor = true;
            // 
            // ans_quest
            // 
            this.ans_quest.AllowUserToAddRows = false;
            this.ans_quest.AllowUserToDeleteRows = false;
            this.ans_quest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ans_quest.Location = new System.Drawing.Point(6, 337);
            this.ans_quest.Name = "ans_quest";
            this.ans_quest.ReadOnly = true;
            this.ans_quest.RowHeadersWidth = 51;
            this.ans_quest.RowTemplate.Height = 24;
            this.ans_quest.Size = new System.Drawing.Size(565, 206);
            this.ans_quest.TabIndex = 3;
            this.ans_quest.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ans_quest_CellEndEdit);
            this.ans_quest.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.ans_quest_RowValidating);
            this.ans_quest.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.UserDeletingRow_grid);
            this.ans_quest.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_grid);
            // 
            // questions
            // 
            this.questions.AllowUserToAddRows = false;
            this.questions.AllowUserToDeleteRows = false;
            this.questions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.questions.Location = new System.Drawing.Point(3, 30);
            this.questions.Name = "questions";
            this.questions.ReadOnly = true;
            this.questions.RowHeadersWidth = 51;
            this.questions.RowTemplate.Height = 24;
            this.questions.Size = new System.Drawing.Size(977, 292);
            this.questions.TabIndex = 0;
            this.questions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.questions_CellClick);
            this.questions.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.questions_CellEndEdit);
            this.questions.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.questions_DataError);
            this.questions.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.questions_RowValidating);
            this.questions.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.UserDeletingRow_grid);
            this.questions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_grid);
            // 
            // subject_page
            // 
            this.subject_page.Controls.Add(this.subjects);
            this.subject_page.Location = new System.Drawing.Point(4, 25);
            this.subject_page.Name = "subject_page";
            this.subject_page.Padding = new System.Windows.Forms.Padding(3);
            this.subject_page.Size = new System.Drawing.Size(1046, 640);
            this.subject_page.TabIndex = 1;
            this.subject_page.Text = "subjects";
            this.subject_page.UseVisualStyleBackColor = true;
            // 
            // subjects
            // 
            this.subjects.AllowUserToAddRows = false;
            this.subjects.AllowUserToDeleteRows = false;
            this.subjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subjects.Location = new System.Drawing.Point(7, 7);
            this.subjects.Name = "subjects";
            this.subjects.ReadOnly = true;
            this.subjects.RowHeadersWidth = 51;
            this.subjects.RowTemplate.Height = 24;
            this.subjects.Size = new System.Drawing.Size(409, 627);
            this.subjects.TabIndex = 0;
            this.subjects.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.Infomation_RowValidating);
            this.subjects.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.UserDeletingRow_grid);
            this.subjects.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_grid);
            // 
            // users_page
            // 
            this.users_page.Controls.Add(this.users);
            this.users_page.Location = new System.Drawing.Point(4, 25);
            this.users_page.Name = "users_page";
            this.users_page.Padding = new System.Windows.Forms.Padding(3);
            this.users_page.Size = new System.Drawing.Size(1046, 640);
            this.users_page.TabIndex = 2;
            this.users_page.Text = "users";
            this.users_page.UseVisualStyleBackColor = true;
            // 
            // users
            // 
            this.users.AllowUserToAddRows = false;
            this.users.AllowUserToDeleteRows = false;
            this.users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.users.Location = new System.Drawing.Point(7, 7);
            this.users.Name = "users";
            this.users.ReadOnly = true;
            this.users.RowHeadersWidth = 51;
            this.users.RowTemplate.Height = 24;
            this.users.Size = new System.Drawing.Size(796, 462);
            this.users.TabIndex = 0;
            this.users.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.users_RowValidating);
            this.users.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.UserDeletingRow_grid);
            this.users.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_grid);
            // 
            // statuses_page
            // 
            this.statuses_page.Controls.Add(this.statuses);
            this.statuses_page.Location = new System.Drawing.Point(4, 25);
            this.statuses_page.Name = "statuses_page";
            this.statuses_page.Padding = new System.Windows.Forms.Padding(3);
            this.statuses_page.Size = new System.Drawing.Size(1046, 640);
            this.statuses_page.TabIndex = 3;
            this.statuses_page.Text = "statuses";
            this.statuses_page.UseVisualStyleBackColor = true;
            // 
            // statuses
            // 
            this.statuses.AllowUserToAddRows = false;
            this.statuses.AllowUserToDeleteRows = false;
            this.statuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statuses.Location = new System.Drawing.Point(6, 6);
            this.statuses.Name = "statuses";
            this.statuses.ReadOnly = true;
            this.statuses.RowHeadersWidth = 51;
            this.statuses.RowTemplate.Height = 24;
            this.statuses.Size = new System.Drawing.Size(445, 628);
            this.statuses.TabIndex = 0;
            this.statuses.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.Infomation_RowValidating);
            this.statuses.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.UserDeletingRow_grid);
            this.statuses.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_grid);
            // 
            // operators_page
            // 
            this.operators_page.Controls.Add(this.data_grid_view_operators);
            this.operators_page.Location = new System.Drawing.Point(4, 25);
            this.operators_page.Name = "operators_page";
            this.operators_page.Padding = new System.Windows.Forms.Padding(3);
            this.operators_page.Size = new System.Drawing.Size(1046, 640);
            this.operators_page.TabIndex = 4;
            this.operators_page.Text = "operators";
            this.operators_page.UseVisualStyleBackColor = true;
            // 
            // data_grid_view_operators
            // 
            this.data_grid_view_operators.AllowUserToAddRows = false;
            this.data_grid_view_operators.AllowUserToDeleteRows = false;
            this.data_grid_view_operators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_grid_view_operators.Location = new System.Drawing.Point(6, 6);
            this.data_grid_view_operators.Name = "data_grid_view_operators";
            this.data_grid_view_operators.ReadOnly = true;
            this.data_grid_view_operators.RowHeadersWidth = 51;
            this.data_grid_view_operators.RowTemplate.Height = 24;
            this.data_grid_view_operators.Size = new System.Drawing.Size(627, 361);
            this.data_grid_view_operators.TabIndex = 0;
            this.data_grid_view_operators.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.data_grid_view_operators_RowValidating);
            this.data_grid_view_operators.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.UserDeletingRow_grid);
            this.data_grid_view_operators.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_grid);
            // 
            // query_page
            // 
            this.query_page.Controls.Add(this.label_second);
            this.query_page.Controls.Add(this.label_first);
            this.query_page.Controls.Add(this.comboBox_query);
            this.query_page.Controls.Add(this.numericUpDown1);
            this.query_page.Controls.Add(this.label2);
            this.query_page.Controls.Add(this.label1);
            this.query_page.Location = new System.Drawing.Point(4, 25);
            this.query_page.Name = "query_page";
            this.query_page.Padding = new System.Windows.Forms.Padding(3);
            this.query_page.Size = new System.Drawing.Size(1046, 640);
            this.query_page.TabIndex = 5;
            this.query_page.Text = "queries";
            this.query_page.UseVisualStyleBackColor = true;
            // 
            // label_second
            // 
            this.label_second.AutoSize = true;
            this.label_second.Location = new System.Drawing.Point(413, 100);
            this.label_second.Name = "label_second";
            this.label_second.Size = new System.Drawing.Size(0, 17);
            this.label_second.TabIndex = 7;
            // 
            // label_first
            // 
            this.label_first.AutoSize = true;
            this.label_first.Location = new System.Drawing.Point(7, 89);
            this.label_first.Name = "label_first";
            this.label_first.Size = new System.Drawing.Size(0, 17);
            this.label_first.TabIndex = 6;
            // 
            // comboBox_query
            // 
            this.comboBox_query.FormattingEnabled = true;
            this.comboBox_query.Location = new System.Drawing.Point(879, 5);
            this.comboBox_query.Name = "comboBox_query";
            this.comboBox_query.Size = new System.Drawing.Size(161, 24);
            this.comboBox_query.TabIndex = 5;
            this.comboBox_query.TextChanged += new System.EventHandler(this.comboBox_query_TextChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(234, 7);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            140,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(92, 22);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(413, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(403, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Количество вопросов, данных пользователями со статусом";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пользователи, которым больше";
            // 
            // Form_workspace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 747);
            this.Controls.Add(this.tabControl);
            this.Name = "Form_workspace";
            this.Text = "Form1";
            this.tabControl.ResumeLayout(false);
            this.main_page.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ans_quest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questions)).EndInit();
            this.subject_page.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.subjects)).EndInit();
            this.users_page.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.users)).EndInit();
            this.statuses_page.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statuses)).EndInit();
            this.operators_page.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_view_operators)).EndInit();
            this.query_page.ResumeLayout(false);
            this.query_page.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage main_page;
        private System.Windows.Forms.TabPage subject_page;
        private System.Windows.Forms.DataGridView questions;
        private System.Windows.Forms.DataGridView data_grid_view_operators;
        private System.Windows.Forms.TabPage users_page;
        private System.Windows.Forms.DataGridView users;
        private System.Windows.Forms.TabPage statuses_page;
        private System.Windows.Forms.DataGridView ans_quest;
        private System.Windows.Forms.DataGridView subjects;
        private System.Windows.Forms.TabPage operators_page;
        private System.Windows.Forms.DataGridView statuses;
        private System.Windows.Forms.TabPage query_page;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox comboBox_query;
        private System.Windows.Forms.Label label_first;
        private System.Windows.Forms.Label label_second;
    }
}

