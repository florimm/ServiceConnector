namespace ServiceConnector.Contracts
{
    public abstract class BaseCommand : ICommand
    {
        public string Name { get; set; }

        public DataEnums Type { get; set; }

        public OutputData Result { get; set; }

        public InputData InputData { get; set; }
    }
}