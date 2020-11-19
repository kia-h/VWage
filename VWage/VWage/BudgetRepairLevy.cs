using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWage.Console
{
    public class BudgetRepairLevy:Deductible
    {
        private string _name;
        private int _numberOfRange;
        private Dictionary<string, TaxableIncomePercentage> TaxBrackets;
        public BudgetRepairLevy(string name, int numberOfRange)
        {
            Name = "Budget Repair Levy";
            TaxBrackets = new Dictionary<string, TaxableIncomePercentage>();
            AddTaxBrackets();
        }

       
        public void AddTaxBrackets()
        {
            var first = new TaxableIncomePercentage(1, 0, 180000, 0);
            var second = new TaxableIncomePercentage(2, 180001, double.MaxValue, 2);
            TaxBrackets.Add("first", first);
            TaxBrackets.Add("second", second);
        }

        public TaxableIncomePercentage GetTaxBracket(double income)
        {
            if (income <= 180000)
            {
                return TaxBrackets["first"];
            }
            else if (180001 <= income )
            {
                return TaxBrackets["second"];
            }
            
            else return new TaxableIncomePercentage(0, 0, 0, 0);
        }

        public double CalculateDeduction(in double income)
        {
            var bracket = GetTaxBracket(income);
            var currentOrder = bracket.Order;
            double deduction = 0;
            if (currentOrder == 1)
            {
                return 0;
            }
            else if (currentOrder == 2)
            {
                var excess = income - TaxBrackets["first"].MaxAmount;
                deduction = Math.Ceiling(excess * bracket.Percentage / 100);

            }
            return deduction;
        }
    }
}
