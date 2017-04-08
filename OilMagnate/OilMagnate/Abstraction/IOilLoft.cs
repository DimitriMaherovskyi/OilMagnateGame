using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilMagnate.Models.Abstraction
{
    public interface IOilLoft : IBuilding
    { 
        int ExtractionPerTurn { get; }
        void RecalculateExtractionPerTurn(int newWorkersSalary);
    }
}
