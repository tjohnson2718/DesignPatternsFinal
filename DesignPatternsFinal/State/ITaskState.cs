using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsFinal.State;

namespace DesignPatternsFinal.State
{
    /// <summary>
    /// State Pattern Interface.
    /// 
    /// The State pattern allows an object to alter its behavior when its internal state changes,
    /// appearing to change its class. Each state is encapsulated in a separate class.
    /// 
    /// In this project, ITaskState defines the contract for task states (Pending, In Progress, Completed, etc.),
    /// enabling TaskContext to delegate state-specific behavior and transitions.
    /// 
    /// This pattern is useful in any project where an object’s behavior depends on its state,
    /// as it promotes cleaner code, easier state management, and open/closed principle compliance.
    /// </summary>
    public interface ITaskState
    {
        
        /// <summary>
        /// The name of the current state, useful for display or logging.
        /// </summary>
        string StateName { get; }
        string StateHandleText { get; set; }
        string StateExecuteText { get; set; }

        /// <summary>
        /// Handles the transition to the next state or performs state-specific actions.
        /// </summary>
        /// <param name="context">The context whose state is being managed</param>
        string Handle(TaskContext context);
        string Edit(TaskContext context, Action<Models.TaskItem> editAction);
        string Cancel(TaskContext context);
        string Execute(TaskContext context);
    }
}
