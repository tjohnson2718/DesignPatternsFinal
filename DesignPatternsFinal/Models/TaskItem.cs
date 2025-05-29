using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsFinal.Models
{
    /// <summary>
    /// Product: Represents the complex object being built by the builder.
    /// In this project, TaskItem is the scheduled task with optional properties.
    /// </summary>
    public class TaskItem
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; } = 0;

    }
}
