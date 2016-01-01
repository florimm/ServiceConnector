using System.Collections.Generic;
using MediatorCommand;
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
            var engine = new BaseServiceEngine();

            Assert.IsNotNull(engine.Execute());
        }
        [Test]
        public void TestEngineWithCommands()
        {
            var engine = new BaseServiceEngine();
            engine.AddCommand(new CmdCommand());
            engine.AddCommand(new CmdCommand());
            engine.AddCommand(new CmdCommand());
            Assert.IsNotNull(engine.Execute());
        }
    }
    public class CmdCommand : BaseCommand
    {
        public bool DataExecuted { get; set; }

        public override void Run()
        {
            DataExecuted = true;
        }
    }
}
