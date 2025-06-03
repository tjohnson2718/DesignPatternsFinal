using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsFinal.Decorator
{
    public class NotificationTaskDecorator : TaskDecorator
    {
        public NotificationTaskDecorator(ITaskComponent component) : base(component) { }
        public override void Execute()
        {
            base.Execute();
            Console.WriteLine("Notification: Execution logic has been performed");
        }
    }
}
