using GrossMarginApp;
using GrossMarginApp.BaseClasses;
using GrossMarginApp.InheritingClasses;

public class Program
{
    private static void Main(string[] args)
    {

        Console.WriteLine("===================================================");
        Console.WriteLine("Witamy w Programie MB do obliczania marży sprzedaży");
        Console.WriteLine("===================================================");
        Console.WriteLine();


        var input = "";
        CustomerBase customer = null;
        while (input != null)
        {
            MenuUtils.ShowMainMenu();
            Console.WriteLine($"Podaj numer klienta:");
            input = Console.ReadLine();
            switch (input.ToUpper().Trim())
            {
                case MenuUtils.newCustomer:
                    customer = new CustomerNew();
                    UpdateCustomerData(customer);
                    break;
                case MenuUtils.customersList:
                    ShowCustomersList();
                    break;
                case MenuUtils.quit:
                    return;
                default:
                    customer = null;
                    if (int.TryParse(input, out int customerId))
                    {
                        try
                        {
                            customer = new CustomerExisting(customerId);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                    }
                    break;
            }
            if (customer != null)
            {
                customer = ShowSelectedCustomer(customer);
            }
        }
    }
    private static void ShowCustomersList()
    {
        if (CustomerBase.LastCustomerNo() == 0)
        {
            Console.WriteLine($"Brak zdefinowanych klientów");
            return;
        }

        for (int i = 1; i <= CustomerBase.LastCustomerNo(); i++)
        {
            try
            {
                var customer = new CustomerExisting(i);
                Console.WriteLine($"{customer.Id} - {customer.Name}");
            }
            catch (Exception ex) { }
        }
    }
    private static CustomerBase ShowSelectedCustomer(CustomerBase customer)
    {
        var input = "";

        while (input != null)
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"Klient Id   : {customer.Id}");
            Console.WriteLine($"Nazwa       : {customer.Name}");
            Console.WriteLine($"Email       : {customer.Email}");
            Console.WriteLine($"Nr tel      : {customer.PhoneNumber}");
            Console.WriteLine($"Adress      : {customer.Address}");
            Console.WriteLine($"Misto       : {customer.City}");
            Console.WriteLine($"Województwo : {customer.State}");
            Console.WriteLine($"Kod pocztowy: {customer.PostalCode}");
            Console.WriteLine($"Kraj        : {customer.Country}");
            Console.WriteLine("---------------------------------------------------");
            MenuUtils.ShowSelectedCustomerMenu();
            input = Console.ReadLine();
            switch (input.ToUpper().Trim())
            {
                case MenuUtils.update:
                    UpdateCustomerData(customer);
                    break;
                case MenuUtils.write:
                    customer.SaveCustomerDataInFile();
                    break;
                case MenuUtils.salesValues:
                    if (customer.Id <= CustomerBase.LastCustomerNo())
                        ShowCustomerValues(customer.Id);
                    else
                        Console.WriteLine("Najpierw zapisz klienta.");
                    break;
                case MenuUtils.back:
                    return null;
            }
        }
        return null;
    }

    private static void ShowCustomerValues(int customerId)
    {
        var customer = new CustomerExisting(customerId);
        var input = "";
        var inputValue = "";

        while (input != null)
        {
            customer.ReadAllValuesFromFiles();
            var salesValues = customer.GetSalesValues();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"Klient Id   : {customer.Id}");
            Console.WriteLine($"Sprzedaż         : {salesValues.SalesInvoicesValue}");
            Console.WriteLine($"Koszty produkcji : {salesValues.ProductionCosts}");
            Console.WriteLine($"Koszty transportu: {salesValues.TransportCosts}");
            Console.WriteLine($"Koszty zmienne   : {salesValues.VariableCosts}");
            Console.WriteLine($"Koszty ogólem    : {salesValues.TotalCosts}");
            Console.WriteLine($"Marża            : {salesValues.GrossMargin}");
            Console.WriteLine($"Marża %          : {salesValues.PercGrossMargin}");
            Console.WriteLine("---------------------------------------------------");
            MenuUtils.ShowCustomerValuesMenu();

            input = Console.ReadLine();

            switch (input.ToUpper().Trim())
            {
                case MenuUtils.back:
                    return;
                case MenuUtils.addSalesInvoice:
                case MenuUtils.addProductionCost:
                case MenuUtils.addTransportCost:
                case MenuUtils.addVariableCost:
                    Console.WriteLine("Podaj wartość:");
                    inputValue = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Błędny wybór.");
                    break;
            }
            if (!string.IsNullOrEmpty(inputValue))
            {
                switch (input.ToUpper().Trim())
                {
                    case MenuUtils.addSalesInvoice:
                        customer.AddSalesInvoiceValue(inputValue);
                        break;
                    case MenuUtils.addProductionCost:
                        customer.AddProductionCostValue(inputValue);
                        break;
                    case MenuUtils.addTransportCost:
                        customer.AddTransportCostValue(inputValue);
                        break;
                    case MenuUtils.addVariableCost:
                        customer.AddVariableCostValue(inputValue);
                        break;
                }
            }
        }
    }

    private static void UpdateCustomerData(CustomerBase customer)
    {
        string input;
        Console.WriteLine($"Podaj Nazwę (ENTER - pomiń)");
        input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input))
        {
            customer.SetName(input);
        }
        Console.WriteLine($"Podaj Email (ENTER - pomiń)");
        input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input))
        {
            customer.SetEmail(input);
        }
        Console.WriteLine($"Podaj Nr telefonu (ENTER - pomiń)");
        input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input))
        {
            customer.SetPhoneNumber(input);
        }
        Console.WriteLine($"Podaj Adres (ENTER - pomiń)");
        input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input))
        {
            customer.SetAddress(input);
        }
        Console.WriteLine($"Podaj Miasto (ENTER - pomiń)");
        input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input))
        {
            customer.SetCity(input);
        }
        Console.WriteLine($"Podaj Województwo (ENTER - pomiń)");
        input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input))
        {
            customer.SetState(input);
        }
        Console.WriteLine($"Podaj Kod pocztowy (ENTER - pomiń)");
        input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input))
        {
            customer.SetPostalCode(input);
        }
        Console.WriteLine($"Podaj Kraj (ENTER - pomiń)");
        input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input))
        {
            customer.SetCountry(input);
        }
    }
}
