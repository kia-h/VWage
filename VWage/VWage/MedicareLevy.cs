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
        public MedicareLevy(string name, int numberOfRange)
        {
            Name = "Medicare Levy";
        }

        public void AddTaxBrackets()
        {
            var first = new TaxableIncomePercentage(0,21355,0);
            var second = new TaxableIncomePercentage(21336,26668,10);
            var third = new TaxableIncomePercentage(26669,decimal.MaxValue, 2);
        }
    }
}
