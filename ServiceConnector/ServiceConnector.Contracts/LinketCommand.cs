using System.Collections.Generic;
using System.Linq;

namespace ServiceConnector.Contracts
{
    public class LinketCommand<T>
    {
        public T Value { get; set; }
        public int Depth { get; set; }
        public int Nr { get; set; }

        public List<LinketCommand<T>> Childs { get; set; }

        public void AddChild(LinketCommand<T> data)
        {
            this.Childs.Add(data);
        }
        public void DeleteChild(LinketCommand<T> data)
        {
            this.Childs.Remove(this.Childs.Single(c => c.Depth == data.Depth && data.Nr == c.Nr));
        }
    }
}