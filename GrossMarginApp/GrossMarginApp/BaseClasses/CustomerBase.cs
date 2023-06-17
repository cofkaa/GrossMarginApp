using GrossMarginApp.Interfaces;

namespace GrossMarginApp.BaseClasses
{
    public abstract class CustomerBase : ICustomer
    {
        private const string customersfileName = "0_Customers.txt";
        private const string customerfileName = "Customer.txt";
        protected const string dirName = "Data";
        protected const string customersFilePath = $"{dirName}\\{customersfileName}";
        public string CustomerFilePath => $"{dirName}\\{Id}_{customerfileName}";
        public int Id { get; private set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string Address { get; protected set; }
        public string City { get; protected set; }
        public string State { get; protected set; }
        public string PostalCode { get; protected set; }
        public string Country { get; protected set; }
        public ValuesBase SalesInvoices { get; private set; }
        public ValuesBase TransportCosts { get; private set; }
        public ValuesBase ProductionCosts { get; private set; }
        public ValuesBase VariableCosts { get; private set; }
        public CustomerBase(int id)
        {
            this.Id = id;
            this.Name = string.Empty;
            this.Email = string.Empty;
            this.PhoneNumber = string.Empty;
            this.Address = string.Empty;
            this.City = string.Empty;
            this.State = string.Empty;
            this.PostalCode = string.Empty;
            this.Country = string.Empty;
            this.SalesInvoices = new ValuesBase(dirName, $"{Id}_SalesInvoices");
            this.TransportCosts = new ValuesBase(dirName, $"{Id}_TransportCosts");
            this.ProductionCosts = new ValuesBase(dirName, $"{Id}_ProductionCosts");
            this.VariableCosts = new ValuesBase(dirName, $"{Id}_VariableCosts");
        }
        public virtual void SaveCustomerDataInFile()
        {
            using (var writer = File.CreateText(this.CustomerFilePath))
            {
                writer.WriteLine($"Id={this.Id}");
                writer.WriteLine($"Name={this.Name}");
                writer.WriteLine($"Email={this.Email}");
                writer.WriteLine($"PhoneNumber={this.PhoneNumber}");
                writer.WriteLine($"Address={this.Address}");
                writer.WriteLine($"City={this.City}");
                writer.WriteLine($"State={this.State}");
                writer.WriteLine($"PostalCode={this.PostalCode}");
                writer.WriteLine($"Country={this.Country}");
            }
        }

        public static int LastCustomerNo()
        {
            List<int> values = FileUtils.ReadIntValuesFromFile(customersFilePath);
            if (values.Count > 0)
                return values[values.Count - 1];
            return 0;
        }
    }
}
