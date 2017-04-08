using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilMagnate.Managers
{
    public static class GameStatsManager
    {
        // Money.
        public static int TotalMoney { get; private set; }
        public static int LastTurnIncome { get; private set; }
        public static int OilSaleIncome { get; private set; }
        public static int BuildingMaitance { get; private set; }
        public static int WorkersPainments { get; private set; }
        // Oil.
        public static int OilExtractionPerTurn { get; private set; }
        public static int OilPumpedInStorages { get; private set; }
        public static int OilSaleQuantity { get; private set; }
        public static int OilTurnowers { get; private set; }

        public static void GetWorkersTotalPaiments(int paiments)
        {
            WorkersPainments = WorkersPainments;
        }

        public static void GetBuildingsMoneyMaintance(int maintance)
        {
            BuildingMaitance = maintance;
        }

        public static void GetTotalMoney(int totalMoney)
        {
            TotalMoney = totalMoney;
        }

        public static void GetMoneyIncome(int income)
        {
            LastTurnIncome = income;
        }
    }
}
