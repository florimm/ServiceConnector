using MediatorCommand;

namespace ServiceConnector.Contracts
{
    public class Bootstrap
    {
        public Bootstrap()
        {
            //x.Scan(scanner =>
            //{
            //    //scanner.TheCallingAssembly();
            //    //scanner.IncludeNamespaceContainingType<ApplicationTimingRequest>();
            //    //scanner.IncludeNamespaceContainingType<ApplicationProcess>();
            //    //scanner.IncludeNamespaceContainingType<SE.DatabaseLayer.ApplicationTimingDB>();
            //    //scanner.IncludeNamespaceContainingType<SE.Entities.CESDecision>();
            //    //scanner.WithDefaultConventions();


            //    scanner.AssemblyContainingType<ApplicationTimingRequest>();
            //    //scanner.IncludeNamespaceContainingType<ApplicationTimingRequest>();
            //    scanner.ConnectImplementationsToTypesClosing(typeof(IExecut<,>));
            //    scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
            //    scanner.ConnectImplementationsToTypesClosing(typeof(IPreExecute<>));
            //    scanner.ConnectImplementationsToTypesClosing(typeof(IPostExecute<,>));
            //});
            ////x.For(typeof(IExecut<,>)).DecorateAllWith(typeof(CommandPipeline<,>));
        }
    }

    

}