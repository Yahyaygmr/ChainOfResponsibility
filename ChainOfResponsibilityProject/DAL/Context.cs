using Microsoft.EntityFrameworkCore;

namespace ChainOfResponsibilityProject.DAL
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-4QIIH5S;initial Catalog=ChainOfResponsibilityDb;integrated security=true;");

        }
        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}
