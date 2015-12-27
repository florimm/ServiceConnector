using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using NUnit.Framework;
using ServiceConnector.Contracts;

namespace Tests
{
    [TestFixture]
    public class TestEngine
    {
        [Test]
        public void TestEngine2()
        {
            BaseEngine engine = new BaseEngine();

            Assert.IsNotNull(engine.Execute());
        }
        [Test]
        public void TestEngineWithCommands()
        {
            var engine = new BaseEngine();
            engine.AddCommand(new CMD());
            engine.AddCommand(new CMD());
            engine.AddCommand(new CMD());
            Assert.IsNotNull(engine.Execute());
        }
    }
    public class BaseEngine : BaseServiceEngine
    {
        
    }
    public class CMD : BaseCommand
    {
        public bool DataExecuted { get; set; }
        public override void BeforeRun()
        {
            
        }

        public override void Run()
        {
            //this.WorkingData = new CommandWorkingData();
            DataExecuted = true;
        }

        public override void AfterRun()
        {
            
        }
    }
}
