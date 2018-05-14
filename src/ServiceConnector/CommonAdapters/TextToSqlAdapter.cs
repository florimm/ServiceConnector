using System.Collections.Generic;

namespace ServiceConnector.CommonAdapters
{
    public class TextToSqlAdapter : IInputParameterAdapter
    {
        private readonly Dictionary<string, object> input;

        public TextToSqlAdapter(Dictionary<string, object> input)
        {
            this.input = input;
        }

        public Dictionary<string, object> Convert()
        {
            return input;
        }
    }
}
