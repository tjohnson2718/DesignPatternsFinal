﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsFinal.Models;

namespace DesignPatternsFinal.State
{
    public class CompletedState : ITaskState
    {
        public string StateName => "Completed";
        public string StateHandleText { get; set; } = "Task is already completed.";
        public string StateExecuteText { get; set; } = "Task is already completed.";

        public string Handle(TaskContext context)
        {
            return StateHandleText;
        }

        public string Edit(TaskContext context, Action<TaskItem> editAction)
        {
            string text = "Cannot edit a completed task.";
            return text;
        }

        public string Cancel(TaskContext context)
        {
            string text = "Cannot cancel a completed task.";
            return text;
        }

        public string Execute(TaskContext context)
        {
            return StateExecuteText;
        }
    }
}

