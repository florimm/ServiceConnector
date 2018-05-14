namespace ServiceConnector.CommonServices
{
    public class SQLService : BaseService
    {
        public override string Name => "SQLService";

        public override IInputParameterAdapter InputParameterAdapter { get; set; }
    }

    public class InitService : BaseService
    {
        public override string Name => "InitService";

        public override IInputParameterAdapter InputParameterAdapter { get; set; }
    }
}
