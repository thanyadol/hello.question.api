using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace hello.question.api.Models
{
    public class NorthwindContext : DbContext
    {
        private const string DEFAULT_SCHEMA = "dbo";

        public DbSet<Question> Questions { get; set; }
        public DbSet<SubQuestion> SubQuestions { get; set; }
        public DbSet<Choise> Choises { get; set; }
        public DbSet<SubChoise> SubChoises { get; set; }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Participant> Participants { get; set; }

        public NorthwindContext()
        { }

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }

        //model validate
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().ToTable("Question");
            modelBuilder.Entity<SubQuestion>().ToTable("SubQuestion");

            modelBuilder.Entity<Choise>().ToTable("Choise");
            modelBuilder.Entity<SubChoise>().ToTable("SubChoise");

            modelBuilder.Entity<Answer>().ToTable("Answer");
            modelBuilder.Entity<Participant>().ToTable("Participant");

            // keep this the last line
            modelBuilder.HasDefaultSchema(DEFAULT_SCHEMA);
        }
    }
}