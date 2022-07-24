namespace CompanyDataBase.Models.DbModels
{
    public class SpecialEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? FacilityId { get; set; }
        public Facility ItsFacility { get; set; }
    }
}
