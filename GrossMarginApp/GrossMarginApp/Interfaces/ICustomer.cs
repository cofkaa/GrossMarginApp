using GrossMarginApp.BaseClasses;

namespace GrossMarginApp.Interfaces
{
    public interface ICustomer
    {
        string CustomerFilePath { get; }
        int Id { get; }
        string Name { get; }
        string Email { get; }
        string PhoneNumber { get; }
        string Address { get; }
        string City { get; }
        string State { get; }
        string PostalCode { get; }
        string Country { get; }
        ValuesBase SalesInvoices { get; }
        ValuesBase TransportCosts { get; }
        ValuesBase ProductionCosts { get; }
        ValuesBase VariableCosts { get; }
        void SetName(string name);
        void SetEmail(string email);
        void SetPhoneNumber(string phoneNumber);
        void SetAddress(string address);
        void SetCity(string city);
        void SetState(string state);
        void SetPostalCode(string postalCode);
        void SetCountry(string country);
        void SaveCustomerDataInFile();
    }
}
