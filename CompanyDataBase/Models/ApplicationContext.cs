using Microsoft.EntityFrameworkCore;
using CompanyDataBase.Models.DbModels;
using CompanyDataBase.Models.Seeds;

namespace CompanyDataBase.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brigadier>().Property(e => e.Number).HasMaxLength(15);
            modelBuilder.Entity<Client>().Property(c=>c.Number).HasMaxLength(15);
            modelBuilder.Seed();
            
        }
     

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Builder> Builders { get; set; }
        public DbSet<Brigadier> Brigadiers { get; set; }
        public DbSet<Brigade> Brigades { get; set;}
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<SpecialEquipment> SpecialEquipments { get; set; }
        public DbSet<TypeOfWork> TypeOfWorks { get; set; }
        public DbSet<BuildingMaterial> BuildingMaterials { get; set; }
        public DbSet<MaterialUse> MaterialUses { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
