using System;
using System.Collections.Generic;

namespace ServiceConnector
{
    public interface IService
    {
        string Name { get; }
    }

    public abstract class BaseService : IService
    {
        public abstract string Name
        {
            get;
        }

        public abstract IInputParameterAdapter InputParameterAdapter { get;set;}
    }

    public interface IInputParameterAdapter
    {
        Dictionary<string, object> Convert();
    }
}
