using NUnit.Framework;
using VWage.Console;

namespace VWage.Test
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
            SalaryDetails sd = new SalaryDetails();
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
            SalaryDetails sd = new SalaryDetails();
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
            SalaryDetails sd = new SalaryDetails();
            //Act
            tax = sd.CalculateBudgetRepairLevy(taxableIncome);
            //Assert
            Assert.AreEqual(0, tax, "Tax should be zero");
        }
    }
}