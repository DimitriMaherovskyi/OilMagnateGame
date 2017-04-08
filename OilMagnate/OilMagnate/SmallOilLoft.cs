using OilMagnate.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilMagnate.Models
{
    public class SmallOilLoft : IOilLoft
    {
        public SmallOilLoft()
        {
            ExtractionPerTurn = 10;
            Workers = new List<IWorker>()
            {
                new Worker(),
                new Worker(),
                new Worker(),
                new Worker()
            };
            BuildPrice = 1000;
            MaintancePricePerTurn = 50;
        }

        public int ExtractionPerTurn { get; private set; }

        public List<IWorker> Workers { get; private set; }

        public int BuildPrice { get; private set; }

        public int MaintancePricePerTurn { get; private set; }
    }
}
