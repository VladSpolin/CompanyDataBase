namespace CompanyDataBase.Models.DbModels
{
    public class Brigade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Brigadier ItsBrigadier { get; set; }
        public List<Builder> Builders { get; set; }
        public int? TypeOfWorkId { get; set; }
        public TypeOfWork TypeOfWorks { get; set; }
        public int? FacilityId { get; set; }
        public Facility Facility { get; set; }
    }
}
