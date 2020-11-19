using System;
using VWage.Console;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            Income income = new Income();
            SalaryDetails sd  = new SalaryDetails();
            Console.Write("Enter your salary package amount:");
            income.GrossPackage = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your pay frequency (W for weekly, F for fortnightly, M for monthly): ");
            income.Frequency = Console.ReadKey().KeyChar;
            Console.WriteLine("\nCalculating salary details...");
            Console.WriteLine($"\nGross package: {income.GrossPackage:C}");
            income.Superannuation = sd.CalculateSuper(income.GrossPackage);
            Console.WriteLine($"Superannuation: {income.Superannuation:C}");
            income.TaxableIncome = Math.Floor(income.GrossPackage - sd.CalculateSuper(income.GrossPackage));
            Console.WriteLine($"\nTaxable income: {income.TaxableIncome:C}");
            Console.WriteLine("\nDeductions:");
            income.Deductions += sd.CalculateMedicareLevy(income.TaxableIncome);
            Console.WriteLine($"Medicare Levy: {sd.CalculateMedicareLevy(income.TaxableIncome):C}");
            income.Deductions += sd.CalculateBudgetRepairLevy(income.TaxableIncome);
            Console.WriteLine($"Budget Repair Levy: {sd.CalculateBudgetRepairLevy(income.TaxableIncome):C}");
            income.Deductions += sd.CalculateIncomeTax(income.TaxableIncome);
            Console.WriteLine($"Income Tax: {sd.CalculateIncomeTax(income.TaxableIncome):C}");
            income.NetIncome = income.TaxableIncome - income.Deductions;
            Console.WriteLine($"\nNet Income: {income.NetIncome}:C");
            
            income.PayPacket = income.NetIncome / 12;
            Console.WriteLine($"Pay packet: {Math.Ceiling(income.PayPacket):C} per month");
            //Console.WriteLine("Hello World!");
            //var income = 18000;
            //var super = sd.CalculateSuper(income);
            //Console.WriteLine($"1st medicare levy: {sd.CalculateMedicareLevy(income)}");
            //Console.WriteLine($"1st budget levy: {sd.CalculateBudgetRepairLevy(income)}");
            //Console.WriteLine($"1st income : {sd.CalculateIncomeTax(income)}");
            //Console.WriteLine("-----------------------------");
            //var income2 = 25000;
            //Console.WriteLine($"2medicare levy: {sd.CalculateMedicareLevy(income2)}");
            //Console.WriteLine($"2budget levy: {sd.CalculateBudgetRepairLevy(income2)}");
            //Console.WriteLine($"2income: {sd.CalculateIncomeTax(income2)}");
            //Console.WriteLine("-----------------------------");
            //var income3 = 40000;
            //Console.WriteLine($"3medicare levy: {sd.CalculateMedicareLevy(income3)}");
            //Console.WriteLine($"3budget levy: {sd.CalculateBudgetRepairLevy(income3)}");
            //Console.WriteLine($"3income: {sd.CalculateIncomeTax(45000)}");
            //Console.WriteLine("-----------------------------");
            //var income4 = 80000;
            //Console.WriteLine($"4medicare levy: {sd.CalculateMedicareLevy(income4)}");
            //Console.WriteLine($"4 budget levy: {sd.CalculateBudgetRepairLevy(200000)}");
            //Console.WriteLine($"4income: {sd.CalculateIncomeTax(95000)}");

            //Console.WriteLine("5th income--------------------------");
            //Console.WriteLine($"5 income: {sd.CalculateIncomeTax(200000)}");
            Console.WriteLine("\nPress any key to end...");
            Console.ReadKey();
        }
    }
}
