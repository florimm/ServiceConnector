using System.Threading;
using System.Threading.Tasks;

namespace MediatorCommand.Internal
{
    internal abstract class CancellableAsyncNotificationHandlerWrapper
    {
        public abstract Task Handle(ICancellableAsyncNotification message, CancellationToken canellationToken);
    }

    internal class CancellableAsyncNotificationHandlerWrapper<TNotification> : CancellableAsyncNotificationHandlerWrapper
        where TNotification : ICancellableAsyncNotification
    {
        private readonly ICancellableAsyncNotificationHandler<TNotification> _inner;

        public CancellableAsyncNotificationHandlerWrapper(ICancellableAsyncNotificationHandler<TNotification> inner)
        {
            _inner = inner;
        }

        public override Task Handle(ICancellableAsyncNotification message, CancellationToken cancellationToken)
        {
            return _inner.Handle((TNotification)message, cancellationToken);
        }
    }
}