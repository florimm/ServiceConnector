using System;

namespace ServiceConnector.Contracts
{
    public abstract class BaseCommand : ICommand
    {
        protected BaseCommand()
        {
            WorkingData = new CommandWorkingData();
        }

        public string Name
        {
            get
            {
                return this.GetType().Name;
            }
        }

        public string Id { get; set; }

        public DataEnums Type { get; set; }


        public CommandWorkingData WorkingData { get; set; }

        public virtual void BeforeRun()
        {
            
        }

        public abstract void Run();

        public virtual void AfterRun()
        {
            
        }

        public void Execute()
        {
            try
            {
                BeforeRun();
                Run();
                AfterRun();
            }
            catch (Exception ex)
            {
                new EngineExcepiton(ex.Message);
            }
        }
    }
}