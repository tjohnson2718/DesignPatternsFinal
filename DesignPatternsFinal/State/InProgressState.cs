using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsFinal.State;

namespace DesignPatternsFinal.State
{
    /// <summary>
    /// Concrete State: Represents the "In Progress" state of a task.
    /// Handles the transition from In Progress to Completed.
    /// </summary>
    public class InProgressState : ITaskState
    {
        public string StateName => "In Progress";
        public void Handle(TaskContext context)
        {
            context.SetState(new CompletedState());
        }
    }
}
