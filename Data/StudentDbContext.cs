using FirstProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Data
{
    public class StudentDbContext : DbContext

    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MyDatabase;Integrated Security=true");
        }

        public DbSet<FirstProject.Models.College> College { get; set; } = default!;
    }



    
}
