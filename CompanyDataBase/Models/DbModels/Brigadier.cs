namespace CompanyDataBase.Models.DbModels
{
    public class Brigadier: Employee
    {
        public int? BrigadeId { get; set; }
        public Brigade ItsBrigade { get; set; }
        public ulong Number { get; set; }
    }
}
