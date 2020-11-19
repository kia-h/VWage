using System;
using VWage.Console;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            SalaryDetails sd  = new SalaryDetails();
            Console.WriteLine("Hello World!");
            var income = 18000;
            Console.WriteLine($"1st medicare levy: {sd.CalculateMedicareLevy(income)}");
            Console.WriteLine($"1st budget levy: {sd.CalculateBudgetRepairLevy(income)}");
            Console.WriteLine($"1st income : {sd.CalculateIncomeTax(income)}");
            Console.WriteLine("-----------------------------");
            var income2 = 25000;
            Console.WriteLine($"2medicare levy: {sd.CalculateMedicareLevy(income2)}");
            Console.WriteLine($"2budget levy: {sd.CalculateBudgetRepairLevy(income2)}");
            Console.WriteLine($"2income: {sd.CalculateIncomeTax(income2)}");
            Console.WriteLine("-----------------------------");
            var income3 = 40000;
            Console.WriteLine($"3medicare levy: {sd.CalculateMedicareLevy(income3)}");
            Console.WriteLine($"3budget levy: {sd.CalculateBudgetRepairLevy(income3)}");
            Console.WriteLine($"3income: {sd.CalculateIncomeTax(45000)}");
            Console.WriteLine("-----------------------------");
            var income4 = 80000;
            Console.WriteLine($"4medicare levy: {sd.CalculateMedicareLevy(income4)}");
            Console.WriteLine($"4 budget levy: {sd.CalculateBudgetRepairLevy(200000)}");
            Console.WriteLine($"4income: {sd.CalculateIncomeTax(95000)}");

            Console.WriteLine("5th income--------------------------");
            Console.WriteLine($"5 income: {sd.CalculateIncomeTax(200000)}");
            Console.ReadKey();
        }
    }
}
