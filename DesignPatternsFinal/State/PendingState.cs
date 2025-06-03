using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsFinal.Models;
using DesignPatternsFinal.State;

namespace DesignPatternsFinal.State
{
    /// <summary>
    /// Concrete State: Represents the "Pending" state of a task.
    /// Handles the transition from Pending to In Progress.
    /// </summary>
    public class PendingState : ITaskState
    {
        public string StateName => "Pending";
        public string StateHandleText { get; set; } = "Handling... Task is now in Progress State.";
        public string StateExecuteText { get; set; } = "Cannot execute a task in a Pending state.";

        public string Cancel(TaskContext context)
        {
            string text = "Task cancelled from Pending state.";
            context.SetState(new CancelledState());
            return text;
        }

        public string Edit(TaskContext context, Action<TaskItem> editAction)
        {
            string text = "Task edited in Pending state.";
            editAction(context.Task);
            return text;
        }

        public string Execute(TaskContext context)
        {
            return StateExecuteText;
        }

        public string Handle(TaskContext context)
        {
            context.SetState(new InProgressState());
            return StateHandleText;
        }
    }
}
