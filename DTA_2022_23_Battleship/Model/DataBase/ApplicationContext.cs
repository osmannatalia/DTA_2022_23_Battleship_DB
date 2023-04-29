using Microsoft.EntityFrameworkCore;


namespace DTA_2022_23_Battleship.Model.DataBase
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Statistic> Statistics { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=myDB.db");
        }
    }
}
