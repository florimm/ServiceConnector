using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatorCommand;

namespace ServiceConnector.Contracts
{
    public class BaseServiceEngine : IServiceEngine
    {
        public BaseServiceEngine()
        {
            //Commands = new List<LinketCommand<ICommand>>();
            WorkingData = new EngineWorkingData();
        }
        public bool SuppressExceptions { get; set; }

        public ILogger Logger { get; set; }

        public EngineWorkingData WorkingData { get; set; }

        //public void AddCommand(ICommand cmd)
        //{
        //    SetId(cmd);
        //    var cmd2 = new LinketCommand<ICommand> {Value = cmd};
        //    //Commands.Add(cmd2);
        //}
        //public void AddFirst(ICommand cmd)
        //{
        //    //this.Commands.AddFirst(cmd);
        //}
        //public void AddAfterCommand(ICommand cmd)
        //{
        //    //this.Commands.AddAfter(cmd);
        //}
        //public void AddBeforeCommand(ICommand cmd)
        //{
        //    //this.Commands.AddBefore(cmd);
        //}

        public EngineWorkingData Execute()
        {
            //Parallel.ForEach(Commands, cmd =>
            //    {
            //        DoTree(cmd, c => c.Execute());
            //        WorkingData.Output.Add(cmd.Value.Id, cmd.Value.WorkingData.Output);
            //    });
            return new EngineWorkingData();
        }

        //private void DoTree(LinketCommand<ICommand> tree, Action<ICommand> action)
        //{
        //    if (tree == null) return;
        //    action(tree.Value);
            //WorkingData.Output.Add(tree.Value.Id, tree.Value.WorkingData.Output);

        //    try
        //    {
        //        Task.WaitAll(tree.Childrens.Select(task => Task.Factory.StartNew(() => DoTree(task, action))).ToArray());
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Write("Engine", ex);
        //    }
        //}

        //private void SetId(ICommand cmd)
        //{
            //string id = cmd.Name + Commands.Count;
            //int idGen = 0;
            //while (Commands.Any(c=> c.Value.Id  == id))
            //{
            //    id = cmd.Name + idGen;
            //    idGen++;
            //}
            //cmd.Id = id;
        //}

        //public List<LinketCommand<ICommand>> Commands { get; private set; }
    }
}