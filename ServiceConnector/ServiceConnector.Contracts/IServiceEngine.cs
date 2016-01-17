using System.Collections.Generic;
using MediatorCommand;

namespace ServiceConnector.Contracts
{
    public interface IServiceEngine
    {
        bool SuppressExceptions { get; set; }
        EngineWorkingData WorkingData { get; set; }
        //List<LinketCommand<ICommand>> Commands { get; }
        //void AddCommand(ICommand cmd);
        EngineWorkingData Execute();
        ILogger Logger { get; set; }
    }
}
