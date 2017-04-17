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
        public int StartWorkerSalary { get; set; }

        public SmallOilStorage(int startWorkerSalary)
        {
            StartWorkerSalary = startWorkerSalary;
            MaximumOilCapacity = 20;
            BuildPrice = 1000;
            MaintancePricePerTurn = 50;
            Workers = new List<IWorker>()
            {
                new Worker(StartWorkerSalary),
                new Worker(StartWorkerSalary)
            };
        }

        public int MaximumOilCapacity { get; } //Максимальний Об'єм нафти

        public int CurrentOilCapacity { get; set; } 

        public int BuildPrice { get; } //Варість побудови

        public int MaintancePricePerTurn { get; } //Вартість амортизації за хід

        public List<IWorker> Workers { get; } //Робітники
    }
}
