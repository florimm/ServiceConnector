namespace MediatorCommand
{
    /// <summary>   
    /// Defines a handler for a request
    /// </summary>
    /// <typeparam name="TRequest">The type of request being handled</typeparam>
    /// <typeparam name="TResponse">The type of response from the handler</typeparam>
    public interface IExecute<in TRequest, out TResponse>
        where TRequest : ICommand<TResponse>
    {
        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        TResponse Handle(TRequest message);
    }


    public interface IPreExecute<in TRequest>
    {
        void Handle(TRequest request);
    }

    public interface IPostExecute<in TRequest, in TResponse>
    {
        void Handle(TRequest request, TResponse response);
    }
}