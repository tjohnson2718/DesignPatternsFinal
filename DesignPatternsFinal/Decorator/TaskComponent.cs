using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsFinal.Models;

namespace DesignPatternsFinal.Decorator
{
    public class TaskComponent : ITaskComponent
    {
        private readonly TaskItem _task;

        public TaskComponent(TaskItem task)
        {
            _task = task;
        }

        public void Execute()
        {
            Console.WriteLine($"Executing task: {_task.Title}");
        }
    }
}
