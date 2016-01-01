namespace ServiceConnector.Contracts
{
    public interface ICommand
    {
        string Name { get;}
        string Id { get; set; }
        DataEnums Type { get; set; }
        CommandWorkingData WorkingData { get; set; }

        void BeforeRun();
        void Run();
        void AfterRun();
        void Execute();
    }
}