using System.Collections.Generic;

namespace ServiceConnector.Contracts
{
    public class Data
    {
        public Data()
        {
            Input = new Dictionary<string, object>();
            Output = new Dictionary<string, object>();
        }
        public Dictionary<string, object> Input { get; set; }
        public Dictionary<string, object> Output { get; set; }
    }
}