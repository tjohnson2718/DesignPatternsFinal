using System;
using NUnit.Framework;
using DesignPatternsFinal.State;
using DesignPatternsFinal.Models;

namespace Test.State
{
    [TestFixture]
    public class TaskStateTests
    {
        [Test]
        public void State_TransitionsAndBehaviors_WorkAsExpected()
        {
            var task = new TaskItem { Title = "State Test" };
            var context = task.StateContext;

            // Initial state should be Pending
            Assert.That(context.GetStateName(), Is.EqualTo("Pending"));

            // Edit is allowed in Pending
            var editMsg = context.Edit(t => t.Description = "Edited in Pending");
            Assert.That(editMsg, Does.Contain("Pending"));
            Assert.That(task.Description, Is.EqualTo("Edited in Pending"));

            // Execute is not allowed in Pending
            var execMsg = context.Execute();
            StringAssert.Contains("Cannot execute a task in a Pending state", execMsg);

            // Advance to In Progress
            var handleMsg = context.NextState();
            Assert.That(context.GetStateName(), Is.EqualTo("In Progress"));
            Assert.That(handleMsg, Does.Contain("Progress"));

            // Edit is allowed in In Progress
            var editMsg2 = context.Edit(t => t.Description = "Edited in Progress");
            Assert.That(editMsg2, Does.Contain("In Progress"));
            Assert.That(task.Description, Is.EqualTo("Edited in Progress"));

            // Execute is allowed in In Progress (should transition to Completed)
            var execMsg2 = context.Execute();
            Assert.That(handleMsg, Does.Contain("Progress"));
            Assert.That(context.GetStateName(), Is.EqualTo("Completed"));

            // Edit is not allowed in Completed
            var editMsg3 = context.Edit(t => t.Description = "Should not change");
            StringAssert.Contains("Cannot edit a completed task", editMsg3);
            Assert.That(task.Description, Is.EqualTo("Edited in Progress"));
        }

        [Test]
        public void State_CancelBehavior_Works()
        {
            var task = new TaskItem { Title = "Cancel Test" };
            var context = task.StateContext;

            // Cancel from Pending
            var cancelMsg = context.Cancel();
            Assert.That(context.GetStateName(), Is.EqualTo("Cancelled"));
            StringAssert.Contains("task cancelled from pending state", cancelMsg.ToLower());

            // Try to execute after cancel
            var execMsg = context.Execute();
            StringAssert.Contains("Cannot execute a cancelled task", execMsg);
        }
    }
}
