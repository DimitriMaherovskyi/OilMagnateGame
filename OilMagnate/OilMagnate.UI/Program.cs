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
        static void Main(string[] args)
        {
            bool endGame = false;

            int StartingSalary;

            Random rnd = new Random();

            var plates = new List<IOilPlate>()
            {
                new OilPlate(rnd.Next(0, 500)),
                new OilPlate(rnd.Next(0, 500)),
                new OilPlate(rnd.Next(0, 500))
            };

            Console.WriteLine("What wold be the starting salary for workers? (Advice: start from 10)");
            double salary;
            Double.TryParse(Console.ReadLine(), out salary);
            if(salary > 0)
            {
                StartingSalary = (int)salary;
            }
            else
            {
                StartingSalary = 10;
            }
            Console.WriteLine("Starting salary = " + StartingSalary);

            var oilMagnate = new OilMagnateManager(plates);

            do
            {

                bool addMore = false;
                bool continueGame = true;

                do
                {
                    Console.WriteLine();
                    Console.WriteLine("What would You like to add?");
                    Console.WriteLine("1 = Big Oil Loft");
                    Console.WriteLine("2 = Small Oil Loft");
                    Console.WriteLine("3 = Oil Storage");
                    Console.WriteLine("Any other key = Nothing");
                    ConsoleKeyInfo answer = Console.ReadKey();
                    if (answer.KeyChar == '1')
                    {
                        oilMagnate.AddOilLoft(2, new BigOilLoft(StartingSalary));
                    }
                    else if (answer.KeyChar == '2')
                    {
                        oilMagnate.AddOilLoft(0, new SmallOilLoft(StartingSalary));
                    }
                    else if (answer.KeyChar == '3')
                    {
                        oilMagnate.AddOilStorage(0, new SmallOilStorage(StartingSalary));
                    }
                    else
                    {
                        continueGame = false;
                    }

                    Console.WriteLine();

                    if (continueGame)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Would You like to add something more?");
                        Console.WriteLine("Y = Yes");
                        Console.WriteLine("Any other key = No");
                        ConsoleKeyInfo addAnswer = Console.ReadKey();
                        if (addAnswer.KeyChar == 'Y' || addAnswer.KeyChar == 'y')
                        {
                            addMore = true;
                        }
                        else
                        {
                            addMore = false;
                        }

                        Console.WriteLine();
                    }

                    continueGame = true;
                }
                while (addMore);

                Console.WriteLine();
                oilMagnate.NextTurn();
                Console.WriteLine();
            }
            while (true);
        } 
    }
}
