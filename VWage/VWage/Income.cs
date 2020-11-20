namespace VSalary.Console
{
    public class Income
    {
        public double GrossPackage { get; set; }

        public double Superannuation { get; set; }
        
        public double TaxableIncome { get; set; }
        
        public double NetIncome { get; set; }
        
        public double PayPacket { get; set; }
        public char Frequency { get; set; }

        //public List<Deductible> Deductions { get; set; }
        public double Deductions { get; set; }
    }
}
