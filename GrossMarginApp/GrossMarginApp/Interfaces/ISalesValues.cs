namespace GrossMarginApp.Iterfaces
{
    public interface ISalesValues
    {
        float SalesInvoicesValue { get; }
        float TransportCosts { get; }
        float ProductionCosts { get; }
        float VariableCosts { get; }
        float TotalCosts { get; }
        float GrossMargin { get; }
        float PercGrossMargin { get; }

        public void AddSalesInvoicesValue(float value) { }
        public void AddTransportCosts(float value) { }
        public void AddProductionCosts(float value) { }
        public void AddVariableCosts(float value) { }
    }
}
