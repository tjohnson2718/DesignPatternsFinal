using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsFinal.Models;

namespace DesignPatternsFinal.Builder
{
    /// <summary>
    /// Director: Defines the construction process for TaskItem objects.
    /// Uses an ITaskBuilder to build tasks with required or all properties.
    /// This separates the construction logic from the representation.
    /// </summary>
    public class TaskDirector
    {
        /// <summary>
        /// Constructs a basic task with only a title.
        /// </summary>
        public TaskItem ConstructBasicTask(ITaskBuilder builder, string title)
        {
            return builder.SetTitle(title).Build();
        }

        /// <summary>
        /// Constructs a full task with title, description, due date, and priority.
        /// </summary>
        public TaskItem ConstructFullTask(ITaskBuilder builder, string title, string description, DateTime dueDate, int priority)
        {
            return builder.SetTitle(title)
                          .SetDescription(description)
                          .SetDueDate(dueDate)
                          .SetPriority(priority)
                          .Build();
        }
    }
}
