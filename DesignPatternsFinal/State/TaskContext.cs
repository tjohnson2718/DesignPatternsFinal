using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsFinal.State;
using DesignPatternsFinal.Models;

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
        public TaskItem Task { get; set; }

        /// <summary>
        /// Initializes the context with the default state (Pending).
        /// </summary>
        public TaskContext(TaskItem task)
        {
            Task = task;
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
        public string NextState()
        {
            return _state.Handle(this);
        }

        /// <summary>
        /// Gets the name of the current state.
        /// </summary>
        public string GetStateName() => _state.StateName;

        /// <summary>
        /// Performs an edit operation on the task, using the state-specific behavior.
        /// </summary>
        public string Edit(Action<TaskItem> editAction) => _state.Edit(this, editAction);

        /// <summary>
        /// Cancels the task, trasitioning to the Cancelled state if applicable.
        /// </summary>
        public string Cancel() => _state.Cancel(this);

        /// <summary>
        /// Performs the execution logic for the current state, using the state specific behavior.
        /// </summary>
        public string Execute() => _state.Execute(this);
    }
}
