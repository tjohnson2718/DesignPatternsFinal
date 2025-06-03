using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsFinal.Decorator
{
    public class AuditTaskDecorator : TaskDecorator
    {
        public AuditTaskDecorator(ITaskComponent component) : base(component) { }
        
        public override void Execute()
        {
            Console.WriteLine("Audit: Starting task execution.");
            base.Execute();
            Console.WriteLine("Audit: Task execution finished.");
        }
    }
}
