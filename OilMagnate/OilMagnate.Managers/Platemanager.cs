using OilMagnate.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OilMagnate.Managers
{
    public class PlateManager
    {
        private IEnumerable<IOilPlate> _plates;

        public PlateManager(IEnumerable<IOilPlate> plates)
        {
            _plates = plates;
        }

        public int CountAllPlatesOilIncome() //Повертає сумарну кількість нафти за хід
        {
            var totalOilIncome = 0;
            foreach (var plate in _plates)
            {
                totalOilIncome += CountOilIncome(plate);
            }

            return totalOilIncome;
        }

        public int CountAllPlatesIncome() //Повертає кількість добутих грошей за хід
        {
            var totalIncome = 0;
            foreach (var plate in _plates)
            {
                totalIncome += CountPlateIncome(plate);
            }

            return totalIncome;
        }

        public int CountOilIncome(IOilPlate plate) //Повертає дохід з 1 території з вирахуваними витратами
        {
            var profit = (from loft in plate.OilLofts
                          select loft.ExtractionPerTurn).Sum();

            return profit;
        }

        public int CountPlateIncome(IOilPlate plate) //Повертає грошовий дохід
        {
            var income = CountPlateProfit(plate) - CountPlateLoss(plate);

            return income;
        }

        public void AddOilLoft(IOilPlate plate, IOilLoft loft) //Поставити вишку
        {
            plate.OilLofts.Add(loft);
            CountPlateExtraction(plate);
        }

        public void AddOilStorage(IOilPlate plate, IOilStorage storage) //Додати склад
        {
            plate.OilStorages.Add(storage);
        }

        private void CountPlateExtraction(IOilPlate plate) //Порахувати скільки можна витягнути з території
        {
            var extraction = (from loft in plate.OilLofts
                              select loft.ExtractionPerTurn).Sum();

            if (extraction > plate.MaximumOilPerTurn)
            {
                plate.OilPerTurn = plate.MaximumOilPerTurn;
            }
            else
            {
                plate.OilPerTurn = extraction;
            }
        }

        private int CountPlateProfit(IOilPlate plate) //Рахуватиме грошовий дохід з 1 території
        {
            // ToDo
            // Storage management.
            return 0;
        }

        private int CountPlateLoss(IOilPlate plate) //Рахує втрати на підтримку будівель та на зарплати працівників
        {
            var oilLofts = new List<IBuilding>(plate.OilLofts);
            var oilStorages = new List<IBuilding>(plate.OilStorages);
            var buildings = oilLofts.Concat(oilStorages);

            var buildingLoss = (from building in buildings
                                select building.MaintancePricePerTurn).Sum();

            var workersLoss = (from building in buildings
                               from worker in building.Workers
                               select worker.SalaryPerTurn).Sum();

            return buildingLoss + workersLoss;
        }
    }
}
