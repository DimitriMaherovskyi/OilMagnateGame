using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilMagnate.Models.Abstraction
{
    public interface IBuilding
    {
        int BuildPrice { get; }
        int MaintancePricePerTurn { get; }
        List<IWorker> Workers { get; }
    }
}
