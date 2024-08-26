using Data.Map;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Escola.Data.Repositories
{
    public class Context : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Register> Register { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentMap());
            modelBuilder.ApplyConfiguration(new TeacherMap());
            modelBuilder.ApplyConfiguration(new ClassMap());
            modelBuilder.ApplyConfiguration(new RegisterMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
