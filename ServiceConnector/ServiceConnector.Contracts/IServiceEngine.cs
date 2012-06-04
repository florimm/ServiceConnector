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
        EngineInput Input { get; set; }
        EngineOutput Execute();
    }
}
