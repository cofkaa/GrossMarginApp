namespace GrossMarginApp.Interfaces
{
    public interface ICustomer
    {
        int Id { get; }
        string Name { get; }
        string Email { get; }
        string PhoneNumber { get; }
        string Address { get; }
        string City { get; }
        string State { get; }
        string PostalCode { get; }
        string Country { get; }
    }
}
