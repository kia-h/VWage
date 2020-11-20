namespace VSalary.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            MedicareLevy medicareLevy= new MedicareLevy("Medicare Levy",2);
            BudgetRepairLevy budgetRepairLevy = new BudgetRepairLevy("Budget Repair Levy",2);
            IncomeTax incomeTax = new IncomeTax("Income Tax",5);
            Income income = new Income();

            SalaryDetails salaryDetails = new SalaryDetails(medicareLevy,budgetRepairLevy,incomeTax,income);
            salaryDetails.Runner();            

            System.Console.ReadKey();
        }
    }
}
