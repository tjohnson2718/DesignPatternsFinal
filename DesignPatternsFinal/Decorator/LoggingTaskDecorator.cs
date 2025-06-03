using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsFinal.Decorator
{
    public class LoggingTaskDecorator : TaskDecorator
    {
        public LoggingTaskDecorator(ITaskComponent component) : base(component) { }

        public override void Execute()
        {
            Console.WriteLine("Logging: Task execution started.");
            base.Execute();
            Console.WriteLine("Logging: Task execution finished.");
        }
        

    }
}
