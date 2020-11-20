using System;

namespace VSalary.Console
{

    /// <summary>
    /// this class is responsible of running the application
    /// it gets user inputs, validates and does the calculation 
    /// </summary>
    public class SalaryDetails
    {
        private readonly MedicareLevy _medicareLevy; 
        private readonly BudgetRepairLevy _budgetRepairLevy; 
        private readonly IncomeTax _incomeTax;
        private readonly Income _income;

        public SalaryDetails(MedicareLevy medicareLevy, BudgetRepairLevy budgetLevy, IncomeTax incomeTax,Income income)
        {
            _medicareLevy = medicareLevy;
            _budgetRepairLevy = budgetLevy;
            _incomeTax = incomeTax;
            _income = income;
        }

        public  double CalculateSuper(double grossIncome)
        {
            return Math.Ceiling(grossIncome * 9.5 / 100);
        }

        public double CalculateMedicareLevy(in double taxableIncome)
        {
            return _medicareLevy.CalculateDeduction(taxableIncome);
        }

        public double CalculateIncomeTax(in double taxableIncome)
        {
            return _incomeTax.CalculateDeduction(taxableIncome);
        }

        public double CalculateBudgetRepairLevy(in double taxableIncome)
        {
            return _budgetRepairLevy.CalculateDeduction(taxableIncome);
        }

        public (string, int) GetFrequencyWord(char frequency)
        {
            if (frequency.ToString().ToLower().Equals("m"))
            {
                return ("month", 12);
            }
            if (frequency.ToString().ToLower().Equals("f"))
            {
                return ("fortnightly", 26);
            }
            return frequency.ToString().ToLower().Equals("w") ? ("weekly", 52) : (string.Empty, 0);
        }

        public double GetSalary()
        {
            string grossPackage;
            while (true)
            {
                System.Console.Write("Enter your salary package amount:");

                grossPackage = System.Console.ReadLine();
                if (!grossPackage.IsNumber() || !grossPackage.IsPositive())
                {
                    System.Console.WriteLine("Please enter valid salary. salary needs to be a positive numeric value.");
                    System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>");
                }
                else
                    break;
            }
            return Convert.ToDouble(grossPackage);
        }

        public char GetFrequency()
        {
            char incomeFrequency;
            while (true)
            {
                System.Console.Write("Enter your pay frequency (W for weekly, F for fortnightly, M for monthly): ");
                incomeFrequency = System.Console.ReadKey().KeyChar;
                if (!incomeFrequency.IsValidFrequency())
                {
                    System.Console.WriteLine("\nPlease enter a valid input from following list: [w,W,f,F,m,M]");
                    System.Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>");
                }
                else
                    break;
            }

            return incomeFrequency;
        }

        public void PrintSalaryDetails(double grossPackage, char incomeFrequency)
        {
            double totalDeductions;
            _income.GrossPackage = grossPackage;
            _income.Frequency = incomeFrequency;
            System.Console.WriteLine("\nCalculating salary details...");
            System.Console.WriteLine($"\nGross package: {_income.GrossPackage:C}");
            _income.Superannuation = CalculateSuper(_income.GrossPackage);
            System.Console.WriteLine($"Superannuation: {_income.Superannuation:C}");
            _income.TaxableIncome = Math.Floor(_income.GrossPackage - CalculateSuper(_income.GrossPackage));
            System.Console.WriteLine($"\nTaxable income: {_income.TaxableIncome:C}");
            System.Console.WriteLine("\nDeductions:");
            _income.Deductions += CalculateMedicareLevy(_income.TaxableIncome);
            System.Console.WriteLine($"Medicare Levy: {CalculateMedicareLevy(_income.TaxableIncome):C}");
            _income.Deductions += CalculateBudgetRepairLevy(_income.TaxableIncome);
            System.Console.WriteLine($"Budget Repair Levy: {CalculateBudgetRepairLevy(_income.TaxableIncome):C}");
            _income.Deductions += CalculateIncomeTax(_income.TaxableIncome);
            System.Console.WriteLine($"Income Tax: {CalculateIncomeTax(_income.TaxableIncome):C}");
            _income.NetIncome = _income.TaxableIncome - _income.Deductions;
            System.Console.WriteLine($"\nNet Income: {_income.NetIncome:C}");

            var (frequency, numberOfPayment) = GetFrequencyWord(_income.Frequency);
            _income.PayPacket = _income.NetIncome / numberOfPayment;
            System.Console.WriteLine($"Pay packet: {Math.Ceiling(_income.PayPacket):C} per {frequency}");
            System.Console.WriteLine("\nPress any key to end...");
        }

        public Income GetIncome()
        {
            return _income;
        }

        public void Runner()
        {
            var gross = GetSalary();
            var frequency = GetFrequency();
            PrintSalaryDetails(gross, frequency);
            //GetIncome();
        }

        public void WriteToFile()
        {
            //TODO:: write the same screen output to a file, json maybe!
            //use GetIncome()
        }
    }
}
