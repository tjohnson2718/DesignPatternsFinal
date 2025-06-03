using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DesignPatternsFinal.Models;
using DesignPatternsFinal.Decorator;

namespace Test.Decorator
{
    [TestFixture]
    public class TaskDecoratorTests
    {
        [Test]
        public void Decorator_StackingBehaviors_Works()
        {
            var task = new TaskItem { Title = "Decorate Me" };
            ITaskComponent component = new TaskComponent(task);
            component = new LoggingTaskDecorator(component);
            component = new NotificationTaskDecorator(component);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                component.Execute();
                var output = sw.ToString();
                StringAssert.Contains("Logging: Task execution started.", output);
                StringAssert.Contains("Executing task: Decorate Me", output);
                StringAssert.Contains("Notification: Execution logic has been performed", output);
                StringAssert.Contains("Logging: Task execution finished.", output);
            }
        }

        [Test]
        public void Decorator_RetryDecorator_RetriesOnException()
        {
            // Custom component that throws on first call, succeeds on second
            int callCount = 0;
            ITaskComponent faultyComponent = new TestFaultyComponent(() => ++callCount);

            ITaskComponent retryComponent = new RetryTaskDecorator(faultyComponent, maxRetries: 2);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                retryComponent.Execute();
                var output = sw.ToString();
                StringAssert.Contains("Retry 1", output);
                // Do NOT expect "Retry 2" since the second attempt succeeds
                Assert.That(callCount, Is.EqualTo(2));
            }
        }

        private class TestFaultyComponent : ITaskComponent
        {
            private readonly Func<int> _onExecute;
            public TestFaultyComponent(Func<int> onExecute) => _onExecute = onExecute;
            public void Execute()
            {
                if (_onExecute() == 1)
                    throw new Exception("Fail first time");
                Console.WriteLine("Success on retry");
            }
        }
    }
}
