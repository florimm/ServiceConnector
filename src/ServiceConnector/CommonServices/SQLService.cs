namespace ServiceConnector.CommonServices
{
    public class SQLService : BaseService
    {
        public override string Name => "SQLService";

        public override IInputParameterAdapter InputParameterAdapter { get; set; }
    }
}
