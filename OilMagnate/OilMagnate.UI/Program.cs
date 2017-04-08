using OilMagnate.Core;
using OilMagnate.Managers;
using OilMagnate.Models;
using OilMagnate.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilMagnate.UI
{
    class Program
    {
        public const int StartingSalary = 10;

        static void Main(string[] args)
        {
            var plates = new List<IOilPlate>()
            {
                new OilPlate(50),
                new OilPlate(0),
                new OilPlate(400)
            };

            var oilMagnate = new OilMagnateManager(plates);
            oilMagnate.AddOilLoft(0, new SmallOilLoft(StartingSalary));
            oilMagnate.AddOilLoft(2, new BigOilLoft(StartingSalary));
            oilMagnate.AddOilStorage(0, new SmallOilStorage(StartingSalary));
            oilMagnate.NextTurn();
            oilMagnate.NextTurn();
            oilMagnate.NextTurn();
            oilMagnate.NextTurn();
            oilMagnate.NextTurn();
            oilMagnate.NextTurn();
            oilMagnate.NextTurn();
            oilMagnate.NextTurn();
            oilMagnate.NextTurn();
            oilMagnate.NextTurn();
            oilMagnate.NextTurn();
            oilMagnate.NextTurn();
            oilMagnate.NextTurn();
            oilMagnate.NextTurn();
            oilMagnate.NextTurn();
            oilMagnate.NextTurn();
            oilMagnate.NextTurn();

            Console.WriteLine();
        }
    }
}
