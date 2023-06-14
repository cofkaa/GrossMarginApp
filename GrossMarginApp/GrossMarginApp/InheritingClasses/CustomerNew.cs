namespace GrossMarginApp.InheritingClasses
{
    public class CustomerNew : CustomerBase
    {
        public CustomerNew() : base(GetNextCustomerNo()) { }

        private static int GetNextCustomerNo()
        {
            var lastCustomerNo = LastCustomerNo();
            lastCustomerNo++;
            return lastCustomerNo;
        }
        public void SaveNewCustomerInFile()
        {
            CreateDirectoryIfNotExists();
            using (var writer = File.AppendText(customersFilePath))
            {
                writer.WriteLine(this.Id);
            }
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
    }
}
