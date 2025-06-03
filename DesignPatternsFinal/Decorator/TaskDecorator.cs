using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsFinal.Decorator
{
    /// <summary>
    /// Abstract base class for task decorators.
    /// You can wrap a component with multiple decorators to dynamically add behavior to tasks.
    /// </summary>
    public abstract class TaskDecorator : ITaskComponent
    {
        // Each TaskDecorator holds a reference to the ITaskComponent that it decorates.
        protected readonly ITaskComponent _component;

        // Initializes the decorator with a specific ITaskComponent.
        protected TaskDecorator(ITaskComponent component)
        {
            _component = component;
        }

        // Performs the task execution by calling the Execute method on the decorated component.
        public virtual void Execute()
        {
            _component.Execute(); // Delegate to the next component in the chain
        }
    }
}
