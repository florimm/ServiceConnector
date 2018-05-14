using System.Collections.Generic;

namespace ServiceConnector.CommonAdapters
{
    public class TextToSqlAdapter : IInputParameterAdapter
    {
        public Dictionary<string, object> input { get; set; }

        public string Name => "TextToSqlAdapter";

        public Dictionary<string, object> Convert()
        {
            return input;
        }
    }


    public class DefaultAdapter : IInputParameterAdapter
    {
        public Dictionary<string, object> input { get; set; }

        public string Name => "DefaultAdapter";

        public Dictionary<string, object> Convert()
        {
            return input;
        }
    }
}
