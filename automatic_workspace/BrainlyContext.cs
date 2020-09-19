using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace automatic_workspace
{
    public class BrainlyContext: DbContext
    {
        public DbSet<OperatorWorkspace>  OperatorsWorkspace { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql(Properties.Settings.Default.brainlyString)
                .UseSnakeCaseNamingConvention();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary keys
            modelBuilder.Entity<OperatorWorkspace>()
                .HasKey(op => op.IdUser);

            modelBuilder.Entity<Status>()
                .HasKey(s => s.IdStatus);

            modelBuilder.Entity<User>()
                .HasKey(u => u.IdUser);

            modelBuilder.Entity<Subject>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Question>()
                .HasKey(q => q.IdQuestion);

            modelBuilder.Entity<Answer>()
                .HasKey(a => new { a.QuestionId, a.UserIdAns });

            // Indexes
            modelBuilder.Entity<OperatorWorkspace>()
                .HasIndex("Login")
                .HasName("lab6.public.operators_workspace.operator_table_login_uindex")
                .IsUnique();

            // Relations
            modelBuilder.Entity<User>()
                .HasOne(u => u.Status)
                .WithMany()
                .HasForeignKey(u => u.StatusId);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Subject)
                .WithMany()
                .HasForeignKey(q => q.SubjectId);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.User)
                .WithMany()
                .HasForeignKey(q => q.UserId);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.User)
                .WithMany(u => u.Answers)
                .HasForeignKey(a => a.UserIdAns);
        }
    }

    public class OperatorWorkspace
    {
        public OperatorWorkspace() { }
        public OperatorWorkspace(string login, string password)
        {
            Login = login;
            Password = password;
        }
        public int IdUser { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class Status
    {
        public int IdStatus { get; set; }
        public string StatusName { get; set; }
    }

    public class User
    {
        public int IdUser { get; set; }
        public string Login { get; set; }
        public int Age { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }

        public IList<Answer> Answers { get; set; }
    }

    public class Subject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
    }

    public class Question
    {
        public int IdQuestion { get; set; }
        public int LinkId { get; set; }
        public int CountView { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public IList<Answer> Answers { get; set; }
    }

    public class Answer
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int UserIdAns { get; set; }
        public User User { get; set; }
        public int CountLike { get; set; }
    }
}
