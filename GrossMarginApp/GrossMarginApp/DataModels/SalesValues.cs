using GrossMarginApp.Iterfaces;

namespace GrossMarginApp.DataModels
{
    public class SalesValues : ISalesValues
    {
        public float SalesInvoicesValue { get; private set; }
        public float TransportCosts { get; private set; }
        public float ProductionCosts { get; private set; }
        public float VariableCosts { get; private set; }
        public float TotalCosts => TransportCosts + ProductionCosts + VariableCosts;
        public float GrossMargin => SalesInvoicesValue - TotalCosts;
        public float PercGrossMargin => SalesInvoicesValue != 0 ? GrossMargin / SalesInvoicesValue * 100 : 0;

        public SalesValues()
        {
            this.SalesInvoicesValue = 0;
            this.TransportCosts = 0;
            this.ProductionCosts = 0;
            this.VariableCosts = 0;
        }
        public void AddSalesInvoicesValue(float value)
        {
            SalesInvoicesValue += value;
        }
        public void AddTransportCosts(float value)
        {
            this.TransportCosts += value;
        }
        public void AddProductionCosts(float value)
        {
            this.ProductionCosts += value;
        }
        public void AddVariableCosts(float value)
        {
            this.VariableCosts += value;
        }
    }
}
