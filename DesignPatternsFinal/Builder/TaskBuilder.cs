using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsFinal.Models;

namespace DesignPatternsFinal.Builder
{
    /// <summary>
    /// Concreate Builder: Implements the ITaskBuilder interface to construct TaskItem objects.
    /// Each method sets a property and returns the builder for fluent chaining.
    /// 
    /// The builder is initialized with an empty task. Then you can use the Set methods to add
    /// properties to the task. Finally, calling Build() returns the constructed TaskItem and 
    /// resets the builder for future use.
    /// </summary>
    public class TaskBuilder : ITaskBuilder
    {
        private TaskItem _task = new TaskItem();

        /// <summary>
        /// Returns the constructed TaskItem and resets the builder for future use.
        /// </summary>
        /// <returns>TaskItem object</returns>
        public TaskItem Build()
        {
            if (string.IsNullOrWhiteSpace(_task.Title))
            {
                throw new ArgumentException("Task must have a title.");
            }

            var result = _task;
            _task = new TaskItem();
            return result;
        }

        public ITaskBuilder SetDescription(string description)
        {
            _task.Description = description;
            return this;
        }

        public ITaskBuilder SetDueDate(DateTime dueDate)
        {
            _task.DueDate = dueDate;
            return this;
        }

        public ITaskBuilder SetEstimatedDuration(TimeSpan duration)
        {
            _task.EstimatedDuration = duration;
            return this;
        }

        public ITaskBuilder SetPriority(int priority)
        {
            _task.Priority = priority;
            return this;
        }

        public ITaskBuilder SetTags(List<string> tags)
        {
            _task.Tags = tags ?? new List<string>();
            return this;
        }

        public ITaskBuilder SetTitle(string title)
        {
            _task.Title = title;
            return this;
        }
    }
}
