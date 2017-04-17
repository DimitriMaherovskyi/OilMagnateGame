using OilMagnate.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilMagnate.Managers
{
    public class OilSaleManager
    {
        private IEnumerable<IOilPlate> _plates;

        public OilSaleManager(IEnumerable<IOilPlate> plates)
        {
            _plates = plates;
        }

        public void SptitOilByStorages(int totalOil)
        {
            IOilStorage oilStorage = null;
            while (oilStorage == null || totalOil != 0)
            {
                oilStorage = (from plate in _plates
                              from storage in plate.OilStorages
                              where storage.CurrentOilCapacity < storage.MaximumOilCapacity
                              select storage).FirstOrDefault();

                var residualCapacity = oilStorage.MaximumOilCapacity - oilStorage.CurrentOilCapacity;
                if (residualCapacity >= totalOil)
                {
                    oilStorage.CurrentOilCapacity += totalOil;
                    totalOil = 0;
                }
                else
                {
                    oilStorage.CurrentOilCapacity = oilStorage.MaximumOilCapacity;
                    totalOil -= residualCapacity;
                }
            }
        }

        // Витягнення нафти зі складу по 10 й продаж.
        public int SellOil(int oilPrice)
        {
            var sellAmount = 10;
            var totalIncome = 0;
            while (true)
            {
                var oilStorage = (from plate in _plates
                                  from storage in plate.OilStorages
                                  where storage.CurrentOilCapacity >= sellAmount
                                  select storage).FirstOrDefault();

                if (oilStorage == null)
                {
                    break;
                }

                oilStorage.CurrentOilCapacity -= sellAmount;
                totalIncome += sellAmount * oilPrice;
            }

            return totalIncome;
        }
    }
}
