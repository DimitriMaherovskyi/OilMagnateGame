using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OilMagnate.Models.Abstraction;
using OilMagnate.Managers;

namespace OilMagnate.Core
{
    public class OilMagnateManager
    {
        private readonly List<IOilPlate> _plates;
        private readonly PlateManager _plateManager;
        private readonly OilPriceManager _oilPriceManager;
        private int _totalMoney;

        public OilMagnateManager(IEnumerable<IOilPlate> plates)
        {
            _plates = new List<IOilPlate>(plates);
            _plateManager = new PlateManager(_plates);
            _oilPriceManager = new OilPriceManager();
            _totalMoney = 1000; //Стартові гроші
        }

        public void NextTurn()
        {
            _oilPriceManager.ChangeOilPrice(); //Встановити нову ціну на нафту
            CountMoney(); //Порахувати зароблене за хід
        }

        public void AddOilLoft(int plateIndex, IOilLoft loft) //Поставити вишку
        {
            _plateManager.AddOilLoft(_plates[plateIndex], loft);
            _totalMoney -= loft.BuildPrice;
        }

        public void AddOilStorage(int plateIndex, IOilStorage storage) //Поставити склад
        {
            _plateManager.AddOilStorage(_plates[plateIndex], storage);
            _totalMoney -= storage.BuildPrice;
        }

        private void CountMoney() //Порахувати гроші за хід
        {
            var totalMoneyPerTurn = 0;
            totalMoneyPerTurn += _plateManager.CountAllPlatesIncome();

            _totalMoney += totalMoneyPerTurn;
        }

        public void RecalculateWorkersSalary(int newSalaryPerTurn) //Перерахувати всім нову зарплату
        {
            foreach(var plate in _plates)
            {
                foreach(var oilLoft in plate.OilLofts)
                {
                    foreach(var worker in oilLoft.Workers)
                    {
                        worker.SalaryPerTurn = newSalaryPerTurn;
                    }

                    oilLoft.RecalculateExtractionPerTurn(newSalaryPerTurn);
                }

                foreach(var oilStorage in plate.OilStorages)
                {
                    foreach(var worker in oilStorage.Workers)
                    {
                        worker.SalaryPerTurn = newSalaryPerTurn;
                    }
                }
            }
        }
    }
}
