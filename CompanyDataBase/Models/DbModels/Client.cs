namespace CompanyDataBase.Models.DbModels
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ulong Number { get; set; }
        public Facility ItsFacility { get; set; }
    }
}
