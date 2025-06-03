using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsFinal.Models;

namespace DesignPatternsFinal.Services
{
    public class TaskSchedulerService
    {
        private readonly List<TaskItem> _tasks = new();

        public void AddTask(TaskItem task) => _tasks.Add(task);
        public List<TaskItem> GetAllTasks() => _tasks;
        public TaskItem? GetTask(int index) => (index >= 0 && index < _tasks.Count) ? _tasks[index] : null;
    }
}
