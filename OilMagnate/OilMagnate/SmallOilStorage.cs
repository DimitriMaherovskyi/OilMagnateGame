using OilMagnate.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilMagnate.Models
{
    public class SmallOilStorage : IOilStorage
    {
        public SmallOilStorage()
        {
            OilCapacity = 20;
            BuildPrice = 1000;
            MaintancePricePerTurn = 50;
            Workers = new List<IWorker>()
            {
                new Worker(),
                new Worker()
            };
        }

        public int OilCapacity { get; }

        public int BuildPrice { get; }

        public int MaintancePricePerTurn { get; }

        public List<IWorker> Workers { get; }
    }
}
