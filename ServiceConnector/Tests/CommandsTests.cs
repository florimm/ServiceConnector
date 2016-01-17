using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ServiceConnector.Contracts;

namespace Tests
{
    [TestFixture]
    public class CommandsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestNodeCommands()
        {
            Node<ICommandType> parentCommand = new Node<ICommandType>(new PlusOneCommand
            {
                Name = "Command1", Input = 10,
            });
                var childCommand3 = new Node<ICommandType>(new PlusTwoCommand { Name = "ChildCOmmand3" });//13
                var chidlCommand = new Node<ICommandType>(new PlusOneCommand { Name = "ChildCommand1"});//12
                    childCommand3.Neighbors.Add(new Node<ICommandType>(new PlusTwoCommand { Name = "ChildCOmmand5" }));//15
                    chidlCommand.Neighbors.Add(new Node<ICommandType>(new PlusOneCommand { Name = "ChildCOmmand2"}));//12
                    chidlCommand.Neighbors.Add(new Node<ICommandType>(new PlusOneCommand { Name = "ChildCOmmand4" }));//12




            chidlCommand.Neighbors.Add(childCommand3);
            parentCommand.Neighbors.Add(chidlCommand);

            parentCommand.Value.Execute();//11
            Parallel.ForEach(parentCommand.Neighbors, cmd =>
                {
                    DoTree(cmd, c =>{c.Execute();}, parentCommand.Value.Input);
                });
            Assert.IsTrue(true);
        }

        private void DoTree(Node<ICommandType> tree, Action<ICommandType> action, int parameters)
        {
            if (tree == null) return;
            tree.Value.Input = parameters;
            action(tree.Value);

            try
            {
                Task.WaitAll(tree.Neighbors.Select(node => Task.Factory.StartNew(() => DoTree(node, action, tree.Value.Input))).ToArray());
            }
            catch (Exception ex)
            {
            }
        }

        public class PlusOneCommand : ICommandType
        {
            public int ValueToAdd
            {
                get { return 1; }
            }

            public int Input { get; set; }

            public string Name { get; set; }
            public void Execute()
            {
                Input += ValueToAdd;
                System.Diagnostics.Debug.WriteLine(Name +"=> " + Input);
            }
        }
        public class PlusTwoCommand : ICommandType
        {
            public int ValueToAdd
            {
                get { return 2; }
            }

            public int Input { get; set; }

            public string Name { get; set; }
            public void Execute()
            {
                Input += ValueToAdd;
                System.Diagnostics.Debug.WriteLine(Name + "=> " + Input);
            }
        }
        public interface ICommandType
        {
            int ValueToAdd { get;  }
            int Input { get; set; }
            string Name { get; set; }
            void Execute();
        }
    }
}
