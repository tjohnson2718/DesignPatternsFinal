using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsFinal.Models;

namespace DesignPatternsFinal.State
{
    public class CancelledState : ITaskState
    {
        public string StateName => "Cancelled";
        public string StateHandleText { get; set; } = "Task is cancelled and cannot transition.";
        public string StateExecuteText { get; set; } = "Cannot execute a cancelled task.";

        public string Handle(TaskContext context)
        {
            return StateHandleText;
        }

        public string Edit(TaskContext context, Action<TaskItem> editAction)
        {
            string text = "Cannot edit a cancelled task.";
            return text;
        }

        public string Cancel(TaskContext context)
        {
            string text = "Task is already cancelled.";
            return text;
        }

        public string Execute(TaskContext context)
        {
            return StateExecuteText;
        }
    }
}

