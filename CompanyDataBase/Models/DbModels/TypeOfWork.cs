namespace CompanyDataBase.Models.DbModels
{
    public class TypeOfWork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Brigade>? BrigadeList { get; set;}
        public List<Facility>? Facilities { get; set; }
    }
}
