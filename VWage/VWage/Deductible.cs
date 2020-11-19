using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWage.Console
{
    public class Deductible
    {
        public string Name{ get; set; }
        
        public List<TaxableIncomePercentage> TaxBrackets { get; set; }

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
