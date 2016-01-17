using System;

namespace ServiceConnector.Contracts
{
    public class EngineException : Exception
    {
        public EngineException(string message) : base(message)
        {
            
        }
    }
}