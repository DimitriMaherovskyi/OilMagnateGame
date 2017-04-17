namespace OilMagnate.Models.Abstraction
{
    public interface IOilStorage : IBuilding
    {
        int MaximumOilCapacity { get; }
        int CurrentOilCapacity { get; set; }
    }
}
