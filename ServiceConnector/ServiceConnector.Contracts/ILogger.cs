using System;

namespace ServiceConnector.Contracts
{
    public interface ILogger
    {
        void Write(string message, Exception ex);
    }
}