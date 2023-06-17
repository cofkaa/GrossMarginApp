using GrossMarginApp.InheritingClasses;

namespace GrossMarginApp.Tests
{
    public class CustomerNewTests
    {
        [Test]
        public void WhenCustomerNewIsSaved_ShouldCustomersNumberIncrease()
        {
            // arrange
            CustomerNew customer = new CustomerNew();
            var numberOfCustomers = CustomerNew.LastCustomerNo();
            // act
            customer.SaveNewCustomerInFile();
            numberOfCustomers++;
            // assert
            Assert.AreEqual(numberOfCustomers, CustomerNew.LastCustomerNo());
        }

        [Test]
        public void WhenCustomerNewIsSaved_ShouldCustomerFileExists()
        {
            // arrange
            CustomerNew customer = new CustomerNew();

            // act
            customer.SaveNewCustomerInFile();

            // assert
            Assert.AreEqual(true, File.Exists(customer.CustomerFilePath));
        }
    }
}