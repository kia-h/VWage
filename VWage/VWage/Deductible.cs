using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSalary.Console
{
    /// <summary>
    /// This class represents the deductible. it acts as a base c
    /// </summary>
    public abstract class Deductible
    {
        protected string Name{ get; set; }

        private List<TaxableIncomePercentage> TaxBrackets { get; set; }

        public string GetName()
        {
            return Name;
        }

        public void AddTaxBracket(TaxableIncomePercentage taxBracket)
        {
            TaxBrackets.Add(taxBracket);
        }
    }
}
