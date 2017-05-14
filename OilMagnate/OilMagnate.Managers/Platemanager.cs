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

        public int CountAllPlatesOilIncome()
        {
            var totalOilIncome = 0;
            foreach (var plate in _plates)
            {
                totalOilIncome += CountOilIncome(plate);
            }

            Console.WriteLine("Total oil income " + totalOilIncome);

            return totalOilIncome;
        }

        public int CountAllPlatesIncome()
        {
            var totalIncome = 0;
            foreach (var plate in _plates)
            {
                totalIncome += CountPlateIncome(plate);
            }

            return totalIncome;
        }

        public int CountOilIncome(IOilPlate plate)
        {
            var profit = (from loft in plate.OilLofts
                          select loft.ExtractionPerTurn).Sum();

            return profit;
        }

        public int CountPlateIncome(IOilPlate plate)
        {
            var income = CountPlateProfit(plate) - CountPlateLoss(plate);

            return income;
        }

        public void AddOilLoft(IOilPlate plate, IOilLoft loft)
        {
            plate.OilLofts.Add(loft);
            CountPlateExtraction(plate);
        }

        public void AddOilStorage(IOilPlate plate, IOilStorage storage)
        {
            plate.OilStorages.Add(storage);
        }

        private void CountPlateExtraction(IOilPlate plate)
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

        private int CountPlateProfit(IOilPlate plate)
        {
            // ToDo
            // Storage management.
            return 0;
        }

        private int CountPlateLoss(IOilPlate plate)
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
