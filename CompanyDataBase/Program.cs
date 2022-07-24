using CompanyDataBase;
using CompanyDataBase.Models;
using CompanyDataBase.Models.DbModels;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationContext>();



//Не добавляет в таблицы данные и ошибок никаких не выдает

//using (ApplicationContext db = new ApplicationContext())
//{
//    Company company = new Company { Name = "BrusHouse", Adress = "Minsk, Belarus" };
//    db.Companies.Add(company);
//    db.SaveChanges();
//    db.Employees.AddRange(new Employee[]
//           {
//                new Employee{Name ="Alex", Age=20, Salary=1000, CompanyId=1},
//                new Employee{Name ="Bob", Age=21, Salary=1100, CompanyId=1},
//                new Employee{Name ="John", Age=22, Salary=1200, CompanyId=1},

//           });
//    db.SaveChanges();
//}
FileFilling file = new FileFilling();

    file.Fill("Belact");




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

