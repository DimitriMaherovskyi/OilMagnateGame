using OilMagnate.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilMagnate.Models
{
    class Worker : IWorker
    {
        public Worker(int SalaryPerTurn)
        {
            this.SalaryPerTurn = SalaryPerTurn;
        }

        public int SalaryPerTurn { get; set; } //Зарплата за хід
    }
}
