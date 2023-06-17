using GrossMarginApp.BaseClasses;

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
        public override void SaveCustomerDataInFile()
        {
            FileUtils.WriteValueInFile(dirName, customersFilePath, this.Id);
            base.SaveCustomerDataInFile();
        }
    }
}
