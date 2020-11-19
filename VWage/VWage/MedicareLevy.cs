using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWage.Console
{
    public class MedicareLevy:Deductible
    {
        private string _name;
        private int _numberOfRange;
        private Dictionary<string, TaxableIncomePercentage> TaxBrackets;
        public MedicareLevy(string name, int numberOfRange)
        {
            Name = "Medicare Levy";
            TaxBrackets=new Dictionary<string, TaxableIncomePercentage>();
            AddTaxBrackets();

        }

        public void AddTaxBrackets()
        {
            var first = new TaxableIncomePercentage(1,0,21335,0);
            var second = new TaxableIncomePercentage(2,21336,26668,10);
            var third = new TaxableIncomePercentage(3,26669,double.MaxValue,  2);
            TaxBrackets.Add("first",first);
            TaxBrackets.Add("second",second);
            TaxBrackets.Add("third",third);

        }

        public TaxableIncomePercentage GetTaxBracket(double income)
        {
            if (income <= 21355)
            {
                return TaxBrackets["first"];
            }
            else if (21336 <= income && income <= 26668)
            {
                return TaxBrackets["second"];
            }
            else if (26669 <= income)
            {
                return TaxBrackets["third"];
            }
            else return new TaxableIncomePercentage(0,0,0,0);
        }

        public double CalculateDeduction(double income)
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
                deduction = Math.Ceiling(excess * bracket.Percentage/100);
                
            }
            else if (currentOrder == 3)
            {
                var excess = income - TaxBrackets["second"].MaxAmount;
                deduction = Math.Ceiling(income * 2 / 100);
            }

            return deduction;
        }
    }
}
