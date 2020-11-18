using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWage.Console
{
    public class IncomeTax:Deductible
    {
        private string _name;
        private int _numberOfRange;
        public IncomeTax(string name, int numberOfRange)
        {
            Name = "Income Tax";
        }

        public void AddTaxBrackets()
        {
            var first = new TaxableIncomePercentage(0, 18200, 0);
            var second = new TaxableIncomePercentage(18201, 37000, 19);
            var third = new TaxableIncomePercentage(37001, 87000, 32.5,3572);
            var fourth = new TaxableIncomePercentage(1800001, decimal.MaxValue, 47,54232);
        }
    }
}
