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

        void AddSalesInvoicesValue(float value);
        void AddTransportCosts(float value);
        void AddProductionCosts(float value);
        void AddVariableCosts(float value);
    }
}
