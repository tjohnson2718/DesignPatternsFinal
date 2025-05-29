using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsFinal.State;

namespace DesignPatternsFinal.State
{
    /// <summary>
    /// Concrete State: Represents the "Completed" state of a task.
    /// No further transitions are allowed from this state.
    /// </summary>
    public class CompletedState : ITaskState
    {
        public string StateName => "Completed";
        public void Handle(TaskContext context)
        {
            // No further state transitions allowed from Completed
            Console.WriteLine("Task is already completed.");
        }
    }
}
