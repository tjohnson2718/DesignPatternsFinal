using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsFinal.Models;

namespace DesignPatternsFinal.Builder
{
    /// <summary>
    /// Builder Interface: Specifies methods for setting up parts of a TaskItem.
    /// This allows step-by-step construction of a TaskItem with optional properties.
    /// </summary>
    public interface ITaskBuilder
    {
        ITaskBuilder SetTitle(string title);
        ITaskBuilder SetDescription(string description);
        ITaskBuilder SetDueDate(DateTime dueDate);
        ITaskBuilder SetPriority(int priority);

        TaskItem Build();
    }
}
