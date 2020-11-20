using System;
using System.Collections.Generic;

namespace VSalary.Console
{
    public class BudgetRepairLevy:Deductible
    {
        private string _name;
        private int _numberOfRange;
        private readonly Dictionary<string, TaxableIncomePercentage> _taxBrackets;
        public BudgetRepairLevy(string name, int numberOfRange)
        {
            Name = "Budget Repair Levy";
            _taxBrackets = new Dictionary<string, TaxableIncomePercentage>();
            AddTaxBrackets();
        }


        private void AddTaxBrackets()
        {
            var first = new TaxableIncomePercentage(1, 0, 180000, 0);
            var second = new TaxableIncomePercentage(2, 180001, double.MaxValue, 2);
            _taxBrackets.Add("first", first);
            _taxBrackets.Add("second", second);
        }

        private TaxableIncomePercentage GetTaxBracket(double income)
        {
            if (income <= 180000)
            {
                return _taxBrackets["first"];
            }
            else if (180001 <= income )
            {
                return _taxBrackets["second"];
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
                    var excess = income - _taxBrackets["first"].MaxAmount;
                    deduction = Math.Ceiling(excess * bracket.Percentage / 100);
                    break;
                }
            }
            return deduction;
        }
    }
}
