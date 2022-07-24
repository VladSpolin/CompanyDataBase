using Microsoft.EntityFrameworkCore;
using CompanyDataBase.Models.DbModels;

namespace CompanyDataBase.Models.Seeds
{
    public static class ModelBuilderExtensions
    {
       
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(new Company { Id = 1, Name = "BrusHouse", Adress = "Minsk, Belarus" });
            modelBuilder.Entity<Employee>().HasData(new Employee[]
            {
                new Employee{Id=1,Name ="Alex", Age=20, Salary=1000, CompanyId=1},
                new Employee{Name ="Bob", Age=21, Salary=1100, CompanyId=1, Id=2},
                new Employee{Name ="John", Age=22, Salary=1200, CompanyId=1, Id=3},
            });
            modelBuilder.Entity<Brigadier>().HasData(new Brigadier[] {
            new Brigadier{Id=5,Name="Anton", Age=30, BrigadeId=1, CompanyId=1, Number=375444875745, Salary=2000},
            new Brigadier{Id=4,Name="Maxim", Age=40, BrigadeId=2, CompanyId=1, Number=375444874565, Salary=2000},
            });
            var reconstruction = new TypeOfWork { Id = 1, Name = "reconstruction" };
            var building = new TypeOfWork { Id = 2, Name = "building" };
            var lining = new TypeOfWork { Id = 3, Name = "lining" };
            modelBuilder.Entity<TypeOfWork>().HasData(new TypeOfWork[] { reconstruction, building, lining });

            modelBuilder.Entity<Brigade>().HasData(new Brigade[] {
                new Brigade{Id=1, FacilityId=1, Name="brigade of masons", TypeOfWorkId=1},
                new Brigade{Id=2, FacilityId=2, Name="brigade of plasterers", TypeOfWorkId=2 },
            });
            modelBuilder.Entity<Builder>().HasData(new Builder[] {
            new Builder{Id=6, Name="Nikolai", Age=40, BrigadeId =2, CompanyId=1, Salary=1300, Position="plasterer"},
            new Builder{Id=7, Name="Aleksandr", Age=40, BrigadeId =2, CompanyId=1, Salary=1300, Position="builder"},
            new Builder{Id=8, Name="Evgeniy", Age=40, BrigadeId =1, CompanyId=1, Salary=1300, Position="mason"},
            new Builder{Id=9, Name="Sergei", Age=40, BrigadeId =1, CompanyId=1, Salary=1300, Position="mason"},
            new Builder{Id=10, Name="Nikolai", Age=40, BrigadeId =1, CompanyId=1, Salary=1300, Position="builder"},
            });
            modelBuilder.Entity<BuildingMaterial>().HasData(new BuildingMaterial[]
            {
                new BuildingMaterial{Id=1, Name="sand", Measure="kg"},
                new BuildingMaterial{Id=2, Name="cement", Measure="kg"},
                new BuildingMaterial{Id=3, Name="brick", Measure="pallet"},
                new BuildingMaterial{Id=4, Name="oil", Measure="litres"},
            });
            modelBuilder.Entity<Client>().HasData(new Client[] {
            new Client{Id=1, Name="Vadim", Number=375111111111},
            new Client{Id=2, Name="Egor", Number=375113312211},
            });
            modelBuilder.Entity<Facility>().HasData(new Facility[] {
            new Facility{Id=1, Name="Belact", Adress="Minsk, Belarus", ClientId=1, TypeOfWorkId=1},
            new Facility{Id=2, Name="Epam", Adress="Minsk, Belarus", ClientId=2, TypeOfWorkId=2},
            });
            modelBuilder.Entity<MaterialUse>().HasData(new MaterialUse[] {
            new MaterialUse{Id=1, BuildingMaterialId=1, FacilityId=1, Count=1000},
            new MaterialUse{Id=2, BuildingMaterialId=2, FacilityId=2, Count=100},
            new MaterialUse{Id=3, BuildingMaterialId=3, FacilityId=1, Count=40},
            new MaterialUse{Id=4, BuildingMaterialId=4, FacilityId=2, Count=50},
            new MaterialUse{Id=5, BuildingMaterialId=1, FacilityId=1, Count=700},
            new MaterialUse{Id=6, BuildingMaterialId=2, FacilityId=2, Count=400},
            });
            modelBuilder.Entity<SpecialEquipment>().HasData(new SpecialEquipment[] {
            new SpecialEquipment{Id=1, Name="Amkador", FacilityId=1},
            new SpecialEquipment{Id=2, Name="Belarus", FacilityId=1},
            new SpecialEquipment{Id=3, Name="MAZ", FacilityId=1},
            new SpecialEquipment{Id=4, Name="KAMAZ", FacilityId=2},
            new SpecialEquipment{Id=5, Name="MAN", FacilityId=2},
            });
        }
    }
}
