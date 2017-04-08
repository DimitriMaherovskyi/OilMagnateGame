using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OilMagnate.Models.Abstraction;

namespace OilMagnate.Models
{
    public class BigOilLoft : IOilLoft
    {
        public BigOilLoft()
        {
            ExtractionPerTurn = 20;
            Workers = new List<IWorker>()
            {
                new Worker(),
                new Worker(),
                new Worker(),
                new Worker(),
                new Worker(),
                new Worker()
            };
            BuildPrice = 2500;
            MaintancePricePerTurn = 75;
        }

        public int ExtractionPerTurn { get; private set; }

        public List<IWorker> Workers { get; private set; }

        public int BuildPrice { get; private set; }

        public int MaintancePricePerTurn { get; private set; }
    }
}
