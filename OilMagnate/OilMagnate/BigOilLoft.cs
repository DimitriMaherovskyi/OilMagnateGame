using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OilMagnate.Models.Abstraction;

namespace OilMagnate.Models
{
    public class BigOilLoft : IOilLoft //Велика вишка
    {
        public int StartWorkerSalary { get; set; }

        public BigOilLoft(int startWorkerSalary)
        {
            StartWorkerSalary = startWorkerSalary;
            ExtractionPerTurn = 20;
            Workers = new List<IWorker>()
            {
                new Worker(StartWorkerSalary),
                new Worker(StartWorkerSalary),
                new Worker(StartWorkerSalary),
                new Worker(StartWorkerSalary),
                new Worker(StartWorkerSalary),
                new Worker(StartWorkerSalary)
            };
            BuildPrice = 2500;
            MaintancePricePerTurn = 75;
        }

        public int ExtractionPerTurn { get; private set; } //Скільки добуває за хід

        public List<IWorker> Workers { get; private set; } //Робітники

        public int BuildPrice { get; private set; }  //Вартість побудови

        public int MaintancePricePerTurn { get; private set; } //Витрати за вхід

        public void RecalculateExtractionPerTurn(int newWorkersSalary)
        {
            double salaryIncreaseCoef = newWorkersSalary / 10;
            double extractionEfficiency = ExtractionPerTurn;
            extractionEfficiency *= salaryIncreaseCoef;
        }
    }
}
