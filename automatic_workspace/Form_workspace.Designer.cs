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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ans_quest = new System.Windows.Forms.DataGridView();
            this.questions = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.subjects = new System.Windows.Forms.ListView();
            this.column_subject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.users_page = new System.Windows.Forms.TabPage();
            this.users = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.data_grid_view_operators = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ans_quest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questions)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.users_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.users)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_view_operators)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.users_page);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(994, 669);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ans_quest);
            this.tabPage1.Controls.Add(this.questions);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(986, 640);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ans_quest
            // 
            this.ans_quest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ans_quest.Location = new System.Drawing.Point(6, 337);
            this.ans_quest.Name = "ans_quest";
            this.ans_quest.RowHeadersWidth = 51;
            this.ans_quest.RowTemplate.Height = 24;
            this.ans_quest.Size = new System.Drawing.Size(498, 206);
            this.ans_quest.TabIndex = 3;
            this.ans_quest.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ans_quest_CellEndEdit);
            this.ans_quest.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.ans_quest_RowValidating);
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
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.subjects);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(986, 640);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "subjects";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // subjects
            // 
            this.subjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_subject});
            this.subjects.HideSelection = false;
            this.subjects.Location = new System.Drawing.Point(6, 6);
            this.subjects.Name = "subjects";
            this.subjects.Size = new System.Drawing.Size(254, 628);
            this.subjects.TabIndex = 1;
            this.subjects.UseCompatibleStateImageBehavior = false;
            this.subjects.View = System.Windows.Forms.View.Details;
            // 
            // column_subject
            // 
            this.column_subject.Text = "Subject name";
            this.column_subject.Width = 242;
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
            this.users.Size = new System.Drawing.Size(569, 365);
            this.users.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.data_grid_view_operators);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(986, 640);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
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
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ans_quest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questions)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.users_page.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.users)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_grid_view_operators)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView questions;
        private System.Windows.Forms.DataGridView data_grid_view_operators;
        private System.Windows.Forms.TabPage users_page;
        private System.Windows.Forms.ListView subjects;
        private System.Windows.Forms.ColumnHeader column_subject;
        private System.Windows.Forms.DataGridView users;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView ans_quest;
    }
}

