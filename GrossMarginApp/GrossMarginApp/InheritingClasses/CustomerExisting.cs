using GrossMarginApp.BaseClasses;
using GrossMarginApp.DataModels;

namespace GrossMarginApp.InheritingClasses
{
    public class CustomerExisting : CustomerBase
    {
        public CustomerExisting(int id) : base(id)
        {
            ReadCustomerDataFromFile();
        }
        private void ReadCustomerDataFromFile()
        {
            if (!File.Exists(this.CustomerFilePath))
                throw new Exception($"Nie znaleziono klienta o id {this.Id}");

            List<string> lines = FileUtils.ReadProperiesFromFile(this.CustomerFilePath);
            string[] lineText;
            foreach (var line in lines)
            {
                lineText = line.Split("=");
                SetCustomerProperty(lineText[0], lineText[1]);
            }
        }
        private void SetCustomerProperty(string propertyName, string value)
        {
            switch (propertyName)
            {
                case "Name":
                    SetName(value);
                    break;
                case "Email":
                    SetEmail(value);
                    break;
                case "PhoneNumber":
                    SetPhoneNumber(value);
                    break;
                case "Address":
                    SetAddress(value);
                    break;
                case "City":
                    SetCity(value);
                    break;
                case "State":
                    SetState(value);
                    break;
                case "PostalCode":
                    SetPostalCode(value);
                    break;
                case "Country":
                    SetCountry(value);
                    break;
                default:
                    break;
            }
        }
        public SalesValues GetSalesValues()
        {
            var salesValues = new SalesValues();
            salesValues.AddSalesInvoicesValue(this.SalesInvoices.Sum);
            salesValues.AddProductionCosts(this.TransportCosts.Sum);
            salesValues.AddTransportCosts(this.ProductionCosts.Sum);
            salesValues.AddVariableCosts(this.VariableCosts.Sum);
            return salesValues;
        }
        public void ReadAllValuesFromFiles()
        {
            ReadSalesInvoicesFromFile();
            ReadProductionCostsValuesFromFile();
            ReadTransportCostsValuesFromFile();
            ReadVariableCostsValuesFromFile();
        }
        public void ReadSalesInvoicesFromFile()
        {
            this.SalesInvoices.ReadValuesFromFile();
        }
        public void ReadTransportCostsValuesFromFile()
        {
            this.TransportCosts.ReadValuesFromFile();
        }
        public void ReadProductionCostsValuesFromFile()
        {
            this.ProductionCosts.ReadValuesFromFile();
        }
        public void ReadVariableCostsValuesFromFile()
        {
            this.VariableCosts.ReadValuesFromFile();
        }
        public void AddSalesInvoiceValue(string value)
        {
            this.SalesInvoices.WriteValueInFile(value);
        }
        public void AddSalesInvoiceValue(float value)
        {
            this.SalesInvoices.WriteValueInFile(value);
        }
        public void AddProductionCostValue(string value)
        {
            this.ProductionCosts.WriteValueInFile(value);
        }
        public void AddProductionCostValue(float value)
        {
            this.VariableCosts.WriteValueInFile(value);
        }
        public void AddTransportCostValue(string value)
        {
            this.TransportCosts.WriteValueInFile(value);
        }
        public void AddTransportCostValue(float value)
        {
            this.VariableCosts.WriteValueInFile(value);
        }
        public void AddVariableCostValue(string value)
        {
            this.VariableCosts.WriteValueInFile(value);
        }
        public void AddVariableCostValue(float value)
        {
            this.VariableCosts.WriteValueInFile(value);
        }
    }
}
