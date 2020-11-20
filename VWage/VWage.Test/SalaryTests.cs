using NUnit.Framework;
using VSalary.Console;

namespace VSalary.Test
{
    public class SalaryTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Tax_Should_Be_Zero_If_Income_Is_In_First_Range()
        {
            //Arrange
            double taxableIncome = 17000;
            double tax = 0;
            MedicareLevy medicareLevy = new MedicareLevy("Medicare Levy", 2);
            BudgetRepairLevy budgetRepairLevy = new BudgetRepairLevy("Budget Repair Levy", 2);
            IncomeTax incomeTax = new IncomeTax("Income Tax", 5);
            Income income = new Income();
            SalaryDetails sd = new SalaryDetails(medicareLevy, budgetRepairLevy, incomeTax, income);
            //Act
            tax = sd.CalculateIncomeTax(taxableIncome);
            //Assert
            Assert.AreEqual(0,tax,"Tax should be zero");
        }

        [Test]
        public void Medicare_Levy_Should_Be_Zero_If_Income_Is_In_First_Range()
        {
            //Arrange
            double taxableIncome = 17000;
            double tax = 0;
            MedicareLevy medicareLevy = new MedicareLevy("Medicare Levy", 2);
            BudgetRepairLevy budgetRepairLevy = new BudgetRepairLevy("Budget Repair Levy", 2);
            IncomeTax incomeTax = new IncomeTax("Income Tax", 5);
            Income income = new Income();
            SalaryDetails sd = new SalaryDetails(medicareLevy, budgetRepairLevy, incomeTax, income);
            //Act
            tax = sd.CalculateMedicareLevy(taxableIncome);
            //Assert
            Assert.AreEqual(0, tax, "Levy should be zero");
        }

        [Test]
        public void Budget_Repair_Levy_Should_Be_Zero_If_Income_Is_In_First_Range()
        {
            //Arrange
            double taxableIncome = 100000;
            double tax = 0;
            MedicareLevy medicareLevy = new MedicareLevy("Medicare Levy", 2);
            BudgetRepairLevy budgetRepairLevy = new BudgetRepairLevy("Budget Repair Levy", 2);
            IncomeTax incomeTax = new IncomeTax("Income Tax", 5);
            Income income = new Income();
            SalaryDetails sd = new SalaryDetails(medicareLevy, budgetRepairLevy, incomeTax, income);
            //Act
            tax = sd.CalculateBudgetRepairLevy(taxableIncome);
            //Assert
            Assert.AreEqual(0, tax, "Tax should be zero");
        }
    }
}