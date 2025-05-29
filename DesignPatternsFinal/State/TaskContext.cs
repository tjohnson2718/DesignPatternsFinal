using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsFinal.State;

namespace DesignPatternsFinal.State
{
    /// <summary>
    /// Context: Maintains a reference to the current state and allows state transitions.
    /// The context delegates state-specific behavior to the current state object.
    /// In this project, TaskContext represents a task whose behavior changes as its state changes.
    /// </summary>
    public class TaskContext
    {
        private ITaskState _state;

        /// <summary>
        /// Initializes the context with the default state (Pending).
        /// </summary>
        public TaskContext()
        {
            _state = new PendingState();
        }

        /// <summary>
        /// Sets the current state to a new state.
        /// </summary>
        public void SetState(ITaskState state)
        {
            _state = state;
        }

        /// <summary>
        /// Triggers the current state's Handle method, which may transition to another state.
        /// </summary>
        public void NextState()
        {
            _state.Handle(this);
        }

        /// <summary>
        /// Gets the name of the current state.
        /// </summary>
        public string GetStateName() => _state.StateName;
    }
}
