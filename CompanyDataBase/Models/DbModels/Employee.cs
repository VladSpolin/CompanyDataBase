namespace CompanyDataBase.Models.DbModels
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public uint Age { get; set; }
        public decimal Salary { get; set; }
        public int? CompanyId { get; set; }
        public Company ItsCompany { get; set; }
    }
}
