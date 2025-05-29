using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsFinal.State;

namespace DesignPatternsFinal.State
{
    /// <summary>
    /// State Interface: Defines the contract for state-specific behavior.
    /// Each concrete state will implement this interface to handle state transitions and behvior.
    /// </summary>
    public interface ITaskState
    {
        /// <summary>
        /// Handles the transition to the next state or performs state-specific actions.
        /// </summary>
        /// <param name="context">The context whose state is being managed</param>
        void Handle(TaskContext context);

        /// <summary>
        /// The name of the current state, useful for display or logging.
        /// </summary>
        string StateName { get; }
    }
}
