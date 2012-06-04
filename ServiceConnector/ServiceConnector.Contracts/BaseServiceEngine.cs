namespace ServiceConnector.Contracts
{
    public abstract class BaseServiceEngine : IServiceEngine
    {
        public bool SuppressExceptions { get; set; }

        public EngineInput Input { get; set; }

        public EngineOutput Execute()
        {
            return new EngineOutput();
        }
        //public static void DoTree<T>(Tree<T> tree, Action<T> action)
        //{
        //    if (tree == null) return;
        //    var left = Task.Factory.StartNew(() => DoTree(tree.Left, action));
        //    var right = Task.Factory.StartNew(() => DoTree(tree.Right, action));
        //    action(tree.Data);

        //    try
        //    {
        //        Task.WaitAll(left, right);
        //    }
        //    catch (AggregateException)
        //    {
        //        //handle exceptions here
        //    }
        //}

        //// By using Parallel.Invoke
        //public static void DoTree2<T>(Tree<T> tree, Action<T> action)
        //{
        //    if (tree == null) return;
        //    Parallel.Invoke(
        //        () => DoTree2(tree.Left, action),
        //        () => DoTree2(tree.Right, action),
        //        () => action(tree.Data)
        //    );
        //}

    }
}