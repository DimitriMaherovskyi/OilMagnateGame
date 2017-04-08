using System.Collections.Generic;

namespace OilMagnate.Models.Abstraction
{
    public interface IOilPlate
    {
        int MaximumOilPerTurn { get; }
        int OilPerTurn { get; set; }
        List<IOilLoft> OilLofts { get; set; }
        List<IOilStorage> OilStorages { get; set; }
    }
}
