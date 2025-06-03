using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsFinal.Models;

namespace DesignPatternsFinal.Builder
{
    /// <summary>
    /// Builder Pattern Interface.
    /// 
    /// The Builder pattern separates the construction of a complex object from its representation,
    /// allowing the same construction process to create different representations.
    /// 
    /// In this project, ITaskBuilder defines the steps for building a TaskItem, enabling flexible,
    /// step-by-step creation of tasks with optional properties (e.g., tags, estimated duration).
    /// 
    /// This pattern is useful in any project where objects have many optional or complex properties,
    /// as it improves readability, maintainability, and enforces object validity before creation.
    /// </summary>
    public interface ITaskBuilder
    {
        ITaskBuilder SetTitle(string title);
        ITaskBuilder SetDescription(string description);
        ITaskBuilder SetDueDate(DateTime dueDate);
        ITaskBuilder SetPriority(int priority);
        ITaskBuilder SetTags(List<string> tags);
        ITaskBuilder SetEstimatedDuration(TimeSpan duration);
        TaskItem Build();
    }
}
