using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsFinal.Decorator
{
    /// <summary>
    /// Decorator Pattern Interface.
    /// 
    /// The Decorator pattern allows behavior to be added to individual objects, dynamically,
    /// without affecting the behavior of other objects from the same class.
    /// 
    /// In this project, ITaskComponent defines the contract for task execution.
    /// Concrete decorators (e.g., LoggingTaskDecorator, NotificationTaskDecorator, AuditTaskDecorator, RetryTaskDecorator)
    /// wrap a task to add features like logging, notifications, auditing, or retry logic at runtime.
    /// 
    /// This pattern is useful in any project where you want to add features to objects without 
    /// modifying their code, supporting open/closed principle and flexible feature composition.
    /// </summary>
    public interface ITaskComponent
    {
        void Execute();
    }
}
