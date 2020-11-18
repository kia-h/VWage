using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWage.Console
{
    public class Income
    {
        public decimal GrossPackage { get; set; }

        public decimal Superannuation { get; set; }
        
        public decimal TaxableIncome { get; set; }
        
        public decimal NetIncome { get; set; }
        
        public decimal PayPacket { get; set; }

        public List<Deductible> Deductions { get; set; }

    }

}
