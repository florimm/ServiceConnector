using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceConnector.Contracts
{
    public interface IServiceEngine
    {
        bool SuppressExceptions { get; set; }
        EngineWorkingData WorkingData { get; set; }
        List<LinketCommand<ICommand>> Commands { get; }
        void AddCommand(ICommand cmd);
        EngineWorkingData Execute();
        ILogger Logger { get; set; }
    }
}
