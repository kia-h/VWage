using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWage.Console
{
    public class TaxableIncomePercentage
    {
        public int Order { get; set; }
        public double MinAmount { get; set; }
        public double MaxAmount { get; set; }

        public double Percentage { get; set; }
        public double ExtraAmount { get; set; }

        public TaxableIncomePercentage(int order, double minAmount, double maxAmount, double percentage, double extraAmount =0)
        {
            Order = order;
            MinAmount = minAmount;
            MaxAmount = maxAmount;
            Percentage = percentage;
            ExtraAmount = extraAmount;
        }
    }
}
