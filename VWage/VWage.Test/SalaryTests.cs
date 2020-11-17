using NUnit.Framework;

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
            decimal taxableIncome = 17000;
            decimal tax = 0;
            //Act
            tax = Income.CalculateTax(taxableIncome);
            //Assert
            Assert.AreEqual(0,tax,"Tax should be zero");
        }

        [Test]
        public void Medicare_Levy_Should_Be_Zero_If_Income_Is_In_First_Range()
        {
            //Arrange
            decimal taxableIncome = 17000;
            decimal tax = 0;
            //Act
            tax = Income.CalculateMedicareLevy(taxableIncome);
            //Assert
            Assert.AreEqual(0, tax, "Levy should be zero");
        }

        [Test]
        public void Budget_Repair_Levy_Should_Be_Zero_If_Income_Is_In_First_Range()
        {
            //Arrange
            decimal taxableIncome = 100000;
            decimal tax = 0;
            //Act
            tax = Income.CalculateBudgetReparLevy(taxableIncome);
            //Assert
            Assert.AreEqual(0, tax, "Tax should be zero");
        }
    }
}