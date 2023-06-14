using System.Reflection.Metadata.Ecma335;

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

            string line;
            using (var reader = File.OpenText(this.CustomerFilePath))
            {
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        string[] lineText = line.Split("=");
                        if (lineText.Length == 2)
                            SetCustomerData(lineText[0], lineText[1]);
                    }
                } while (line != null);
            }
        }
    }
}
