using System;
using System.Collections.Generic;

namespace VSalary.Console
{
    public class IncomeTax : Deductible
    {
        private string _name;
        private int _numberOfRange;
        private Dictionary<string, TaxableIncomePercentage> TaxBrackets;

        public IncomeTax(string name, int numberOfRange)
        {
            Name = "Income Tax";
            TaxBrackets = new Dictionary<string, TaxableIncomePercentage>();
            AddTaxBrackets();
        }

        private void AddTaxBrackets()
        {
            var first = new TaxableIncomePercentage(1, 0, 18200, 0);
            var second = new TaxableIncomePercentage(2, 18201, 37000, 19);
            var third = new TaxableIncomePercentage(3, 37001, 87000, 32.5, 3572);
            var fourth = new TaxableIncomePercentage(4, 87001, 180000, 37, 19822);
            
            var fifth = new TaxableIncomePercentage(5, 1800001, double.MaxValue, 47, 54232);
            TaxBrackets.Add("first", first);
            TaxBrackets.Add("second", second);
            TaxBrackets.Add("third", third);
            TaxBrackets.Add("fourth", fourth);
            TaxBrackets.Add("fifth", fifth);

        }

        private TaxableIncomePercentage GetTaxBracket(double income)
        {
            if (income <= 18200)
            {
                return TaxBrackets["first"];
            }
            else if (18201 <= income && income <=37000)
            {
                return TaxBrackets["second"];
            }
            else if (37001 <= income && income <= 87000)
            {
                return TaxBrackets["third"];
            }
            else if (87001 <= income && income <= 180000)
            {
                return TaxBrackets["fourth"];
            }
            else if (180001 < income )
            {
                return TaxBrackets["fifth"];
            }

            else return new TaxableIncomePercentage(0, 0, 0, 0);
        }

        public double CalculateDeduction(in double income)
        {
            var bracket = GetTaxBracket(income);
            var currentOrder = bracket.Order;
            double deduction = 0;
            switch (currentOrder)
            {
                case 1:
                    return 0;
                case 2:
                {
                    var excess = income - TaxBrackets["first"].MaxAmount;
                    deduction = Math.Ceiling(excess * bracket.Percentage / 100);
                    break;
                }
                case 3:
                {
                    var excess = income - TaxBrackets["second"].MaxAmount;
                    deduction = Math.Ceiling(excess * bracket.Percentage / 100) + TaxBrackets["third"].ExtraAmount;
                    break;
                }
                case 4:
                {
                    var excess = income - TaxBrackets["third"].MaxAmount;
                    deduction = Math.Ceiling(excess * bracket.Percentage / 100) + TaxBrackets["fourth"].ExtraAmount;
                    break;
                }
                case 5:
                {
                    var excess = income - TaxBrackets["fourth"].MaxAmount;
                    deduction = Math.Ceiling(excess * bracket.Percentage / 100) + TaxBrackets["fifth"].ExtraAmount;
                    break;
                }
            }
            return deduction;
        }

    }
}
