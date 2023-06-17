using GrossMarginApp.BaseClasses;
using GrossMarginApp.InheritingClasses;
using GrossMarginApp.Interfaces;

namespace GrossMarginApp.Tests
{
    public class CustomerExistingTests
    {
        [Test]
        public void WhenCustomerExistingIsSaved_ShouldCustomersNumberNotChange()
        {
            // arrange
            CustomerExisting customer;
            try
            {
                customer = new CustomerExisting(1);
            }
            catch (Exception)
            {
                CustomerNew customerNew = new CustomerNew();
                customerNew.SaveCustomerDataInFile();
                customer = new CustomerExisting(1);
            }
            var numberOfCustomers = CustomerBase.LastCustomerNo();

            // act
            customer.SaveCustomerDataInFile();

            // assert
            Assert.AreEqual(numberOfCustomers, CustomerBase.LastCustomerNo());
        }

        [Test]
        public void WhenCustomerSetNameAndSaveData_ShouldReturnCorrentNameFromFile()
        {
            // arrange
            CustomerNew customerNew = new CustomerNew();
            customerNew.SetName("Nowy Klient Sp. z o.o.");
            customerNew.SaveCustomerDataInFile();
            CustomerExisting customer = new CustomerExisting(customerNew.Id);
            customer.SetName("Firma Sp. z o.o.");
            customer.SaveCustomerDataInFile();
            // act
            customer = new CustomerExisting(customerNew.Id);

            // assert
            Assert.AreEqual("Firma Sp. z o.o.", customer.Name);
        }
    }
}