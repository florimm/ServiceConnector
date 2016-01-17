using System.Collections.ObjectModel;
using System.Linq;

namespace ServiceConnector.Contracts
{
    public class NodeList<T> : Collection<Node<T>>
    {
        public NodeList() : base() { }

        public NodeList(int initialSize)
        {
            for (int i = 0; i < initialSize; i++)
                base.Items.Add(default(Node<T>));
        }

        public Node<T> FindByValue(T value)
        {
            return Items.FirstOrDefault(node => node.Value.Equals(value));
        }
    }
    public class Node<T>
    {
        //public Node()
        //{
        //    Neighbors = null;
        //}

        public Node(T data) : this(data, new NodeList<T>()) { }
        public Node(T data, NodeList<T> neighbors)
        {
            this.Value = data;
            this.Neighbors = neighbors;
        }

        public T Value { get; set; }

        public NodeList<T> Neighbors { get; set; }
    }
}