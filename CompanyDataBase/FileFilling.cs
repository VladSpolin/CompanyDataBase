using CompanyDataBase.Models;

using Microsoft.EntityFrameworkCore;

namespace CompanyDataBase
{
    public class FileFilling
    {  
        public  void Fill(string facilityname)
        {
            string result = string.Empty;
            using (var db= new ApplicationContext())
            {
                var companies = db.Companies.Include(c=>c.Employees).ToList();
                foreach(var company in companies)
                {
                    result += $"{company.Name}. Destination - {company.Adress}\nWorkers: \n";
                    foreach(var employee in company.Employees)
                    {
                        result += $"{employee.Name}. Age  - {employee.Age}. Salary - {employee.Salary}\n";
                    }
                }
                var brigades = db.Brigades.Include(b=>b.ItsBrigadier).Include(b=>b.TypeOfWorks).ToList();
                result += $"Brigades:\n";
                foreach ( var brigade in brigades)
                {
                    result += $"{brigade.Name}. Brigadier - {brigade.ItsBrigadier.Name}. Type of work - {brigade.TypeOfWorks.Name}\n";
                }
                Microsoft.Data.SqlClient.SqlParameter param = new Microsoft.Data.SqlClient.SqlParameter("@name", facilityname);
                var uses = db.MaterialUses.FromSqlRaw("GetMaterialUseByFacility @name", param).ToList();
                result += $"Material use where facility = {facilityname}:\n";
                foreach (var use in uses)
                {
                    result += $"{use.BuildingMaterialId} - {use.Count}\n";
                }
            }
            File.WriteAllText(@$"{Environment.CurrentDirectory}/Info.txt", result);
        }



    }
}
