using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsFinal.Decorator
{
    public class RetryTaskDecorator : TaskDecorator
    {
        private readonly int _maxRetries;

        public RetryTaskDecorator(ITaskComponent component, int maxRetries = 3) : base(component)
        {
            _maxRetries = maxRetries;
        }

        public override void Execute()
        {
            int attempt = 0;
            while (true)
            {
                try
                {
                    attempt++;
                    base.Execute();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Retry {attempt}: {ex.Message}");
                    if (attempt >= _maxRetries)
                    {
                        Console.WriteLine("Max retries reached. Task failed.");
                        break;
                    }
                }
            }
        }
    }
}
