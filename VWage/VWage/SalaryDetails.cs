using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWage.Console
{
    public  class SalaryDetails
    {
        MedicareLevy medicareLevy=new MedicareLevy("m",3);
        BudgetRepairLevy budgetRepairLevy = new BudgetRepairLevy("b",2);
        IncomeTax incomeTax = new IncomeTax("i",5);

        public double CalculateMedicareLevy(in double taxableIncome)
        {
            //medicareLevy.AddTaxBrackets();
            return medicareLevy.CalculateDeduction(taxableIncome);
        }

        public double CalculateIncomeTax(in double taxableIncome)
        {
            return incomeTax.CalculateDeduction(taxableIncome);
        }

        public double CalculateBudgetRepairLevy(in double taxableIncome)
        {
            return budgetRepairLevy.CalculateDeduction(taxableIncome);
        }
    }
}
