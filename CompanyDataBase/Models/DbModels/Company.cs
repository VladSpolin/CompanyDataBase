namespace CompanyDataBase.Models.DbModels
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
