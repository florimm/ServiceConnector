using System;

namespace ServiceConnector.Contracts
{
    public class EngineExcepiton : Exception
    {
        public EngineExcepiton(string message) : base(message)
        {
            
        }
    }
}