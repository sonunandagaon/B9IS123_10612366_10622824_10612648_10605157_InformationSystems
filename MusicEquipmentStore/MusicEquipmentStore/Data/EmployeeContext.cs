using Microsoft.EntityFrameworkCore;

namespace MusicEquipmentStore.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
        }

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeLogin> EmployeeLogin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();
            //var connectingstring = configuration.GetConnectionString("AppDb");
            //optionsBuilder.UseSqlServer(connectingstring);

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-DGLDM4B\\MSSQLSERVER2019;Database=Employee;Trusted_Connection=true;TrustServerCertificate=true;");

            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Server=DESKTOP-JI65VED\\SQLEXPRESS;Database=Employee;Trusted_Connection=True;");
            //}
        }

    }
}
