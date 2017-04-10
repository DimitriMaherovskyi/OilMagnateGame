using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OilMagnate.Models.Abstraction;

namespace OilMagnate.Models
{
    public class OilPlate : IOilPlate
    {
        public OilPlate(int maximumOilPerTurn)
        {
            MaximumOilPerTurn = maximumOilPerTurn;
            OilLofts = new List<IOilLoft>();
            OilStorages = new List<IOilStorage>();
        }

        public int MaximumOilPerTurn { get; private set; } //Максимальна кількість нафти за хід
        public int OilPerTurn { get; set; } //Нафта за хід
        public List<IOilLoft> OilLofts { get; set; } //Вишок
        public List<IOilStorage> OilStorages { get; set; } //Склади
    }
}
