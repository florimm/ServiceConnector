﻿using MediatorCommand.Internal;

namespace MediatorCommand
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Default mediator implementation relying on single- and multi instance delegates for resolving handlers.
    /// </summary>
    public class Mediator : IMediator
    {
        private readonly SingleInstanceFactory _singleInstanceFactory;

        private readonly MultiInstanceFactory _multiInstanceFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="Mediator"/> class.
        /// </summary>
        /// <param name="singleInstanceFactory">The single instance factory.</param>
        /// <param name="multiInstanceFactory">The multi instance factory.</param>
        public Mediator(SingleInstanceFactory singleInstanceFactory, MultiInstanceFactory multiInstanceFactory)
        {
            _singleInstanceFactory = singleInstanceFactory;
            _multiInstanceFactory = multiInstanceFactory;
        }

        public TResponse Send<TResponse>(IRequest<TResponse> request)
        {
            var defaultHandler = GetHandler(request);

            var result = defaultHandler.Handle(request);

            return result;
        }

        public async Task<TResponse> SendAsync<TResponse>(IAsyncRequest<TResponse> request)
        {
            var defaultHandler = GetHandler(request);

            var result = await defaultHandler.Handle(request);

            return result;
        }

        public async Task<TResponse> SendAsync<TResponse>(ICancellableAsyncRequest<TResponse> request, CancellationToken cancellationToken)
        {
            var defaultHandler = GetHandler(request);

            var result = await defaultHandler.Handle(request, cancellationToken);

            return result;
        }

        public void Publish(INotification notification)
        {
            var notificationHandlers = GetNotificationHandlers(notification);

            foreach (var handler in notificationHandlers)
            {
                handler.Handle(notification);
            }
        }

        public async Task PublishAsync(IAsyncNotification notification)
        {
            var notificationHandlers = GetNotificationHandlers(notification)
                .Select(handler => handler.Handle(notification))
                .ToArray();

            await Task.WhenAll(notificationHandlers);
        }

        public async Task PublishAsync(ICancellableAsyncNotification notification, CancellationToken cancellationToken)
        {
            var notificationHandlers = GetNotificationHandlers(notification)
                .Select(handler => handler.Handle(notification, cancellationToken))
                .ToArray();

            await Task.WhenAll(notificationHandlers);
        }

        private RequestHandlerWrapper<TResponse> GetHandler<TResponse>(IRequest<TResponse> request)
        {
            return GetHandler<RequestHandlerWrapper<TResponse>, TResponse>(request,
                typeof(IExecut<,>),
                typeof(RequestHandlerWrapper<,>));
        }

        private AsyncRequestHandlerWrapper<TResponse> GetHandler<TResponse>(IAsyncRequest<TResponse> request)
        {
            return GetHandler<AsyncRequestHandlerWrapper<TResponse>, TResponse>(request,
                typeof(IAsyncRequestHandler<,>),
                typeof(AsyncRequestHandlerWrapper<,>));
        }

        private CancellableAsyncRequestHandlerWrapper<TResponse> GetHandler<TResponse>(ICancellableAsyncRequest<TResponse> request)
        {
            return GetHandler<CancellableAsyncRequestHandlerWrapper<TResponse>, TResponse>(request,
                typeof(ICancellableAsyncRequestHandler<,>),
                typeof(CancellableAsyncRequestHandlerWrapper<,>));
        }

        private TWrapper GetHandler<TWrapper, TResponse>(object request, Type handlerType, Type wrapperType)
        {
            var requestType = request.GetType();

            var genericHandlerType = handlerType.MakeGenericType(requestType, typeof(TResponse));
            var genericWrapperType = wrapperType.MakeGenericType(requestType, typeof(TResponse));

            var handler = GetHandler(request, genericHandlerType);

            return (TWrapper) Activator.CreateInstance(genericWrapperType, handler);
        }

        private object GetHandler(object request, Type handlerType)
        {
            try
            {
                return _singleInstanceFactory(handlerType);
            }
            catch (Exception e)
            {
                throw BuildException(request, e);
            }
        }

        private IEnumerable<NotificationHandlerWrapper> GetNotificationHandlers(INotification notification)
        {
            return GetNotificationHandlers<NotificationHandlerWrapper>(notification,
                typeof(INotificationHandler<>),
                typeof(NotificationHandlerWrapper<>));
        }

        private IEnumerable<AsyncNotificationHandlerWrapper> GetNotificationHandlers(IAsyncNotification notification)
        {
            return GetNotificationHandlers<AsyncNotificationHandlerWrapper>(notification,
                typeof(IAsyncNotificationHandler<>),
                typeof(AsyncNotificationHandlerWrapper<>));
        }

        private IEnumerable<CancellableAsyncNotificationHandlerWrapper> GetNotificationHandlers(ICancellableAsyncNotification notification)
        {
            return GetNotificationHandlers<CancellableAsyncNotificationHandlerWrapper>(notification,
                typeof (ICancellableAsyncNotificationHandler<>),
                typeof(CancellableAsyncNotificationHandlerWrapper<>));
        }

        private IEnumerable<TWrapper> GetNotificationHandlers<TWrapper>(object notification, Type handlerType, Type wrapperType)
        {
            var notificationType = notification.GetType();

            var genericHandlerType = handlerType.MakeGenericType(notificationType);
            var genericWrapperType = wrapperType.MakeGenericType(notificationType);

            return GetNotificationHandlers(notification, genericHandlerType)
                .Select(handler => Activator.CreateInstance(genericWrapperType, handler))
                .Cast<TWrapper>()
                .ToList();
        }

        private IEnumerable<object> GetNotificationHandlers(object notification, Type handlerType)
        {
            try
            {
                return _multiInstanceFactory(handlerType);
            }
            catch (Exception e)
            {
                throw BuildException(notification, e);
            }
        }

        private static InvalidOperationException BuildException(object message, Exception inner)
        {
            return new InvalidOperationException("Handler was not found for request of type " + message.GetType() + ".\r\nContainer or service locator not configured properly or handlers not registered with your container.", inner);
        }
    }
}