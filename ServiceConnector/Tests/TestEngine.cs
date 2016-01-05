using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MediatorCommand;
using NUnit.Framework;
using ServiceConnector.Contracts;
using StructureMap;

namespace Tests
{
    [TestFixture]
    public class TestEngine
    {
        private Container container;
        [SetUp]
        public void Setup()
        {
            container = new Container(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssemblyContainingType<Ping>(); // Our assembly with requests & handlers
                    scanner.ConnectImplementationsToTypesClosing(typeof(IExecute<,>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IPreExecute<>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IPostExecute<,>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncNotificationHandler<>));
                });
                cfg.For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
                cfg.For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));
                cfg.For(typeof(IExecute<,>)).DecorateAllWith(typeof(CommandPipeline<,>));
                cfg.For<IMediator>().Use<Mediator>();
            });
        }
        [Test]
        public void TestEngine2()
        {
            var mediator = container.GetInstance<IMediator>();
            mediator.Send(new Ping());
        }

        public class Ping : IRequest<Pong>
        {
            public string Message { get; set; }
        }
        public class Pong : IRequest<Pong>
        {
            public string Message { get; set; }
        }

        public class PingHandler : IExecute<Ping, Pong>
        {
            public Pong Handle(Ping message)
            {
                System.Diagnostics.Debug.Write("Handler");
                return new Pong { Message = message.Message + " Pong" };
            }
        }
        public class PingPreHandler :IPreExecute<Ping> 
        {
            public void Handle(Ping request)
            {
                System.Diagnostics.Debug.Write("Pre");
            }
        }

        public class PingPostHandler : IPostExecute<Ping, Pong>
        {
            public void Handle(Ping request, Pong response)
            {
                System.Diagnostics.Debug.Write("Post");
            }
        }
        public class Pinged : INotification
        {

        }
        public class PingNotification : INotificationHandler<Pinged>
        {
            public void Handle(Pinged notification)
            {
                throw new NotImplementedException();
            }
        }
    }
}
