using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsFinal.Models;

namespace DesignPatternsFinal.State
{
    public class InProgressState : ITaskState
    {
        public string StateName => "In Progress";
        public string StateHandleText { get; set; } = "Handling... Task is now in Completed State.";
        public string StateExecuteText { get; set; } = "Executing task from the In Progress State... Task executed";

        public string Handle(TaskContext context)
        {
            context.SetState(new CompletedState());
            return StateHandleText;
        }

        public string Edit(TaskContext context, Action<TaskItem> editAction)
        {
            string text = "Editing in In Progress.";

            // Allow limited editing
            editAction(context.Task);
            return text;
        }

        public string Cancel(TaskContext context)
        {
            string text = "Task cancelled from In Progress state.";
            context.SetState(new CancelledState());
            return text;
        }

        public string Execute(TaskContext context)
        {
            Handle(context); // Transition to Completed state after execution
            // Simulate execution
            return StateExecuteText;
        }
    }
}

