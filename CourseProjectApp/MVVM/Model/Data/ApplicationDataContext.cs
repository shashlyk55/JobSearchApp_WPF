using Microsoft.EntityFrameworkCore;

namespace Practic_App.MVVM.Model.Data
{
    public class ApplicationDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Response> Responses { get; set; }
        

        public ApplicationDataContext() {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка связей для Response
            modelBuilder.Entity<Response>()
                .HasOne(a => a.Vacancy)
                .WithMany(j => j.Responses)
                .HasForeignKey(a => a.VacancyId);

            // Настройка связей для Response
            modelBuilder.Entity<Response>()
                .HasOne(a => a.User)
                .WithMany(u => u.Responses)
                .HasForeignKey(a => a.UserId);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=JobMarketDB;Integrated Security=True;TrustServerCertificate=True;");
        }
    }
}
