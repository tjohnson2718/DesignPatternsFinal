using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void Handle(TaskContext context)
        {
            context.SetState(new InProgressState());
        }
    }
}
