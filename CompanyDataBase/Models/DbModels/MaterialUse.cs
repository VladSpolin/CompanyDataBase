namespace CompanyDataBase.Models.DbModels
{
    public class MaterialUse
    {
        public int Id { get; set; }
        public int BuildingMaterialId { get; set; }
        public BuildingMaterial ItsBuildingMaterial { get; set; }
        public uint Count { get; set; }
        public int? FacilityId { get; set; }
        public Facility Facility { get; set; }
    }
}
