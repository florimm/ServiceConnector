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
        string Name { get; set; }
        Dictionary<string, object> Convert();
    }
}
