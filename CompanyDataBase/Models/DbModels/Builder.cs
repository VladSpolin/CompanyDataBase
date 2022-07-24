namespace CompanyDataBase.Models.DbModels
{
    public class Builder:Employee
    {
        public int? BrigadeId { get; set; }
        public Brigade ItsBrigade { get; set; }
        public string Position { get; set; }
    }
}
