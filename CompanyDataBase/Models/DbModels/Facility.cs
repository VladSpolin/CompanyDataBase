namespace CompanyDataBase.Models.DbModels
{
    public class Facility
    {
        public int Id { get; set;}
        public string Name { get; set;}
        public string Adress { get; set;}
        public int? ClientId { get; set;}
        public Client ItsClient { get; set;}
        public int? TypeOfWorkId { get; set;}
        public TypeOfWork WorkType { get; set;}
        public List<Brigade> BrigadeList { get; set;}
    }
}
