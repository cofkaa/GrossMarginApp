namespace GrossMarginApp
{
    public abstract class MenuUtils
    {
        public const string newCustomer = "N";
        public const string customersList = "L";
        public const string update = "U";
        public const string write = "W";
        public const string salesValues = "S";
        public const string back = "B";
        public const string quit = "Q";
        public const string addSalesInvoice = "I";
        public const string addProductionCost = "P";
        public const string addTransportCost = "T";
        public const string addVariableCost = "V";

        private const string newCustomerText = "Nowy klient";
        private const string customersListText = "Lista klientów";
        private const string updateText = "Zmień dane";
        private const string writeText = "Zapisz zmiany";
        private const string salesValuesText = "Wartości klienta";
        private const string backText = "Powrót";
        private const string quitText = "Zakończ";
        private const string addSalesInvoiceText = "Dodaj fakturę sprzedaży";
        private const string addProductionCostText = "Koszt producji";
        private const string addTransportCostText = "Koszt transportu";
        private const string addVariableCostText = "Koszt zmienny";
        private static void ShowMenu(string[] keyList, string[] keyFunctionList)
        {
            Console.WriteLine("---------------------------------------------------");
            for (int i = 0; i < keyList.Length; i++)
            {
                Console.Write($" {keyList[i]} - {keyFunctionList[i]} |");
            }
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");
        }
        public static void ShowMainMenu()
        {
            string[] keyList = { newCustomer, customersList, quit };
            string[] keyFunctionList = { newCustomerText, customersListText, quitText };

            ShowMenu(keyList, keyFunctionList);
        }
        public static void ShowSelectedCustomerMenu()
        {
            string[] keyList = { update, write, salesValues, back };
            string[] keyFunctionList = { updateText, writeText, salesValuesText, backText };

            ShowMenu(keyList, keyFunctionList);
        }

        public static void ShowCustomerValuesMenu()
        {
            string[] keyList = { addSalesInvoice, addProductionCost, addTransportCost, addVariableCost, back };
            string[] keyFunctionList = { addSalesInvoiceText, addProductionCostText, addTransportCostText, addVariableCostText, backText };

            ShowMenu(keyList, keyFunctionList);
        }
    }
}
