using GrossMarginApp.DataModels;

namespace GrossMarginApp.Tests
{
    public class SalesValuesTests
    {
        [Test]
        public void WhenSalesValueCollectInvoices_ShouldReturnCorrectMargin()
        {
            // arrange
            SalesValues salesvalues = new SalesValues();
            salesvalues.AddSalesInvoicesValue(10);
            salesvalues.AddSalesInvoicesValue(100);
            // act

            // assert
            Assert.AreEqual(110, salesvalues.GrossMargin);
        }

        [Test]
        public void WhenSalesValueCollectCosts_ShouldReturnCorrectMargin()
        {
            // arrange
            SalesValues salesvalues = new SalesValues();
            salesvalues.AddSalesInvoicesValue(10);
            salesvalues.AddSalesInvoicesValue(100);
            salesvalues.AddProductionCosts(1);
            salesvalues.AddTransportCosts(2);
            salesvalues.AddVariableCosts(3);
            // act

            // assert
            Assert.AreEqual(104, salesvalues.GrossMargin);
        }

        [Test]
        public void WhenSalesValueCollectCosts_ShouldReturnCorrectPercMargin()
        {
            // arrange
            SalesValues salesvalues = new SalesValues();
            salesvalues.AddSalesInvoicesValue(10);
            salesvalues.AddSalesInvoicesValue(100);
            salesvalues.AddProductionCosts(1);
            salesvalues.AddTransportCosts(2);
            salesvalues.AddVariableCosts(3);
            // act

            // assert
            Assert.AreEqual(94.55, Math.Round(salesvalues.PercGrossMargin, 2));
        }

        [Test]
        public void WhenSalesValueCollectInvoices_ShouldReturnCorrectPercMargin()
        {
            // arrange
            SalesValues salesvalues = new SalesValues();
            salesvalues.AddSalesInvoicesValue(10);
            salesvalues.AddSalesInvoicesValue(100);
            // act

            // assert
            Assert.AreEqual(100, salesvalues.PercGrossMargin);
        }

        [Test]
        public void WhenSalesValueHasNoIvoices_ShouldReturnCorrectPercMargin()
        {
            // arrange
            SalesValues salesvalues = new SalesValues();
            salesvalues.AddProductionCosts(1);
            salesvalues.AddTransportCosts(2);
            salesvalues.AddVariableCosts(3);
            // act

            // assert
            Assert.AreEqual(0, Math.Round(salesvalues.PercGrossMargin, 2));
        }
    }
}