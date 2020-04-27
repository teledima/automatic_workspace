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
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.main_page);
            this.tabControl.Controls.Add(this.subject_page);
            this.tabControl.Controls.Add(this.users_page);
            this.tabControl.Controls.Add(this.statuses_page);
            this.tabControl.Controls.Add(this.operators_page);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(994, 669);
            this.tabControl.TabIndex = 0;
            // 
            // main_page
            // 
            this.main_page.Controls.Add(this.ans_quest);
            this.main_page.Controls.Add(this.questions);
            this.main_page.Location = new System.Drawing.Point(4, 25);
            this.main_page.Name = "main_page";
            this.main_page.Padding = new System.Windows.Forms.Padding(3);
            this.main_page.Size = new System.Drawing.Size(986, 640);
            this.main_page.TabIndex = 0;
            this.main_page.Text = "main page";
            this.main_page.UseVisualStyleBackColor = true;
            // 
            // ans_quest
            // 
            this.ans_quest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ans_quest.Location = new System.Drawing.Point(6, 337);
            this.ans_quest.Name = "ans_quest";
            this.ans_quest.RowHeadersWidth = 51;
            this.ans_quest.RowTemplate.Height = 24;
            this.ans_quest.Size = new System.Drawing.Size(565, 206);
            this.ans_quest.TabIndex = 3;
            this.ans_quest.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ans_quest_CellEndEdit);
            this.ans_quest.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.RowsRemoved);
            this.ans_quest.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.ans_quest_RowValidating);
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
            this.questions.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.RowsRemoved);
            this.questions.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.questions_RowValidating);
            this.questions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_grid);
            // 
            // subject_page
            // 
            this.subject_page.Controls.Add(this.subjects);
            this.subject_page.Location = new System.Drawing.Point(4, 25);
            this.subject_page.Name = "subject_page";
            this.subject_page.Padding = new System.Windows.Forms.Padding(3);
            this.subject_page.Size = new System.Drawing.Size(986, 640);
            this.subject_page.TabIndex = 1;
            this.subject_page.Text = "subjects";
            this.subject_page.UseVisualStyleBackColor = true;
            // 
            // subjects
            // 
            this.subjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subjects.Location = new System.Drawing.Point(7, 7);
            this.subjects.Name = "subjects";
            this.subjects.RowHeadersWidth = 51;
            this.subjects.RowTemplate.Height = 24;
            this.subjects.Size = new System.Drawing.Size(215, 627);
            this.subjects.TabIndex = 0;
            this.subjects.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.Infomation_RowValidating);
            // 
            // users_page
            // 
            this.users_page.Controls.Add(this.users);
            this.users_page.Location = new System.Drawing.Point(4, 25);
            this.users_page.Name = "users_page";
            this.users_page.Padding = new System.Windows.Forms.Padding(3);
            this.users_page.Size = new System.Drawing.Size(986, 640);
            this.users_page.TabIndex = 2;
            this.users_page.Text = "users";
            this.users_page.UseVisualStyleBackColor = true;
            // 
            // users
            // 
            this.users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.users.Location = new System.Drawing.Point(7, 7);
            this.users.Name = "users";
            this.users.RowHeadersWidth = 51;
            this.users.RowTemplate.Height = 24;
            this.users.Size = new System.Drawing.Size(796, 462);
            this.users.TabIndex = 0;
            this.users.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.users_RowValidating);
            this.users.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_grid);
            // 
            // statuses_page
            // 
            this.statuses_page.Controls.Add(this.statuses);
            this.statuses_page.Location = new System.Drawing.Point(4, 25);
            this.statuses_page.Name = "statuses_page";
            this.statuses_page.Padding = new System.Windows.Forms.Padding(3);
            this.statuses_page.Size = new System.Drawing.Size(986, 640);
            this.statuses_page.TabIndex = 3;
            this.statuses_page.Text = "statuses";
            this.statuses_page.UseVisualStyleBackColor = true;
            // 
            // statuses
            // 
            this.statuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statuses.Location = new System.Drawing.Point(6, 6);
            this.statuses.Name = "statuses";
            this.statuses.RowHeadersWidth = 51;
            this.statuses.RowTemplate.Height = 24;
            this.statuses.Size = new System.Drawing.Size(208, 628);
            this.statuses.TabIndex = 0;
            this.statuses.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.Infomation_RowValidating);
            // 
            // operators_page
            // 
            this.operators_page.Controls.Add(this.data_grid_view_operators);
            this.operators_page.Location = new System.Drawing.Point(4, 25);
            this.operators_page.Name = "operators_page";
            this.operators_page.Padding = new System.Windows.Forms.Padding(3);
            this.operators_page.Size = new System.Drawing.Size(986, 640);
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
            this.data_grid_view_operators.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_grid);
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
    }
}

