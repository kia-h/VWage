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
        public BudgetRepairLevy(string name, int numberOfRange)
        {
            Name = "Budget Repair Levy";
        }

        public void AddTaxBrackets()
        {
            var first = new TaxableIncomePercentage(0, 180000, 0);
            var second = new TaxableIncomePercentage(180001, decimal.MaxValue, 2);
        }
    }
}
