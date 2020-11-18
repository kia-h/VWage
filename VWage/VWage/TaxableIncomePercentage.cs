using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWage.Console
{
    public class TaxableIncomePercentage
    {
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }

        public double Percentage { get; set; }
        public decimal ExtraAmount { get; set; }

        public TaxableIncomePercentage(decimal minAmount, decimal maxAmount, double percentage, decimal extraAmount=0)
        {
            MinAmount = minAmount;
            MaxAmount = maxAmount;
            Percentage = percentage;
            ExtraAmount = extraAmount;
        }
    }
}
