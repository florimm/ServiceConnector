namespace ServiceConnector.Contracts
{
    public interface ICommand
    {
        string Name { get; set; }
        DataEnums Type { get; set; }
        OutputData Result { get; set; }
        InputData InputData { get; set; }
    }
}