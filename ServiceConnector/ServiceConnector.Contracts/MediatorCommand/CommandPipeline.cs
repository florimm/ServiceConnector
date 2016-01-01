namespace MediatorCommand
{
    public class CommandPipeline<TInput, TOutput>
        : IExecut<TInput, TOutput>
        where TInput : IRequest<TOutput>
    {

        private readonly IPreExecute<TInput>[] preExecutes;
        private readonly IExecut<TInput, TOutput> requestHander;
        private readonly IPostExecute<TInput, TOutput>[] postExecutes;

        public CommandPipeline(
            IExecut<TInput, TOutput> requestHander,
            IPreExecute<TInput>[] preExecutes,
            IPostExecute<TInput, TOutput>[] postExecutes
            )
        {
            this.requestHander = requestHander;
            this.preExecutes = preExecutes;
            this.postExecutes = postExecutes;
        }


        public TOutput Handle(TInput message)
        {
            foreach (var preRequestHandler in preExecutes)
            {
                preRequestHandler.Handle(message);
            }

            var result = requestHander.Handle(message);

            foreach (var postRequestHandler in postExecutes)
            {
                postRequestHandler.Handle(message, result);
            }

            return result;
        }
    }
}