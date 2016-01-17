namespace MediatorCommand.Internal
{
    internal abstract class RequestHandlerWrapper<TResult>
    {
        public abstract TResult Handle(ICommand<TResult> message);
    }

    internal class RequestHandlerWrapper<TCommand, TResult> : RequestHandlerWrapper<TResult>
        where TCommand : ICommand<TResult>
    {
        private readonly IExecute<TCommand, TResult> _inner;

        public RequestHandlerWrapper(IExecute<TCommand, TResult> inner)
        {
            _inner = inner;
        }

        public override TResult Handle(ICommand<TResult> message)
        {
            return _inner.Handle((TCommand)message);
        }
    }
}