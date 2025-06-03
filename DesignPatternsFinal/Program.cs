using DesignPatternsFinal.Models;
using DesignPatternsFinal.State;
using DesignPatternsFinal.Services;
using DesignPatternsFinal.Builder;
using DesignPatternsFinal.Decorator;

var taskService = new TaskSchedulerService();
var director = new TaskDirector();

while (true)
{
    Console.WriteLine("\nTask Scheduler");
    Console.WriteLine("1. Add Task");
    Console.WriteLine("2. List Tasks");
    Console.WriteLine("3. Advance Task State");
    Console.WriteLine("4. Edit Task");
    Console.WriteLine("5. Cancel Task");
    Console.WriteLine("6. Execute Task");
    Console.WriteLine("7. Exit");
    Console.Write("Choose an option: ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            AddTask(taskService);
            break;
        case "2":
            ListTasks(taskService);
            break;
        case "3":
            AdvanceTaskState(taskService);
            break;
        case "4":
            EditTask(taskService);
            break;
        case "5":
            CancelTask(taskService);
            break;
        case "6":
            ExecuteTask(taskService);
            break;
        case "7":
            return;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

/// <summary>
/// Uses the Builder pattern to construct a TaskItem step-by-step.
/// </summary>
void AddTask(TaskSchedulerService taskService)
{
    // Create the builder with the default _task
    var builder = new TaskBuilder();

    // Set the properties of the object form the user's input
    Console.Write("Title: ");
    builder.SetTitle(Console.ReadLine() ?? "");

    Console.Write("Description (optional): ");
    var desc = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(desc)) builder.SetDescription(desc);
    Console.Write("Due Date (yyyy-MM-dd, optional): ");
    var due = Console.ReadLine();
    if (DateTime.TryParse(due, out var dueDate)) builder.SetDueDate(dueDate);

    Console.Write("Priority (int, optional): ");
    var prio = Console.ReadLine();
    if (int.TryParse(prio, out var priority)) builder.SetPriority(priority);

    Console.Write("Tags (comma separated, optional): ");
    var tagsInput = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(tagsInput))
        builder.SetTags(tagsInput.Split(',').Select(t => t.Trim()).Where(t => t.Length > 0).ToList());

    Console.Write("Estimated Duration (minutes, optional): ");
    var durationInput = Console.ReadLine();
    if (int.TryParse(durationInput, out var minutes))
        builder.SetEstimatedDuration(TimeSpan.FromMinutes(minutes));

    try
    {
        var task = builder.Build();
        taskService.AddTask(task);
        Console.WriteLine("Task added.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

/// <summary>
/// Lists all tasks, showing their state and properties.
/// </summary>
void ListTasks(TaskSchedulerService taskService)
{
    var tasks = taskService.GetAllTasks();
    if (tasks.Count == 0)
    {
        Console.WriteLine("No tasks found.");
    }
    else
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            var t = tasks[i];
            var tags = t.Tags != null && t.Tags.Count > 0 ? string.Join(", ", t.Tags) : "None";
            var duration = t.EstimatedDuration.HasValue ? $"{t.EstimatedDuration.Value.TotalMinutes} min" : "N/A";
            Console.WriteLine($"{i + 1}. {t.Title} | State: {t.StateContext.GetStateName()} | Due: {t.DueDate?.ToShortDateString() ?? "N/A"} | Priority: {t.Priority} | Tags: {tags} | Est. Duration: {duration}");
        }
    }
}

/// <summary>
/// Uses the State pattern to advance the state of a task.
/// </summary>
void AdvanceTaskState(TaskSchedulerService taskService)
{
    Console.Write("Enter task number to advance state: ");
    if (int.TryParse(Console.ReadLine(), out int idx) && taskService.GetTask(idx - 1) is TaskItem advTask)
    {
        var msg = advTask.StateContext.NextState();
        Console.WriteLine(msg);
        Console.WriteLine($"Task '{advTask.Title}' state is now: {advTask.StateContext.GetStateName()}");
    }
    else
    {
        Console.WriteLine("Invalid task number.");
    }
}

/// <summary>
/// Uses the State pattern to edit a task, only if the current state allows it.
/// </summary>
void EditTask(TaskSchedulerService taskService)
{
    Console.Write("Enter task number to edit: ");
    if (int.TryParse(Console.ReadLine(), out int idx) && taskService.GetTask(idx - 1) is TaskItem editTask)
    {
        var msg = editTask.StateContext.Edit(task =>
        {
            Console.Write("New Title (leave blank to keep current): ");
            var newTitle = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newTitle)) task.Title = newTitle;

            Console.Write("New Description (leave blank to keep current): ");
            var newDesc = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newDesc)) task.Description = newDesc;
        });
        Console.WriteLine(msg);
    }
    else
    {
        Console.WriteLine("Invalid task number.");
    }
}

/// <summary>
/// Uses the State pattern to cancel a task, only if the current state allows it.
/// </summary>
void CancelTask(TaskSchedulerService taskService)
{
    Console.Write("Enter task number to cancel: ");
    if (int.TryParse(Console.ReadLine(), out int idx) && taskService.GetTask(idx - 1) is TaskItem cancelTask)
    {
        var msg = cancelTask.StateContext.Cancel();
        Console.WriteLine(msg);
        Console.WriteLine($"Task '{cancelTask.Title}' state is now: {cancelTask.StateContext.GetStateName()}");
    }
    else
    {
        Console.WriteLine("Invalid task number.");
    }
}

/// <summary>
/// Uses the Decorator pattern to dynamically add features to task execution,
/// and the State pattern to ensure execution is only allowed in the correct state.
/// </summary>
void ExecuteTask(TaskSchedulerService taskService)
{
    Console.Write("Enter task number to execute: ");
    if (int.TryParse(Console.ReadLine(), out int execIdx) && taskService.GetTask(execIdx - 1) is TaskItem execTask)
    {
        // State pattern: Only allow execution if the state allows it
        var stateMsg = execTask.StateContext.Execute();

        // Decorator pattern: Add features to execution
        ITaskComponent component = new TaskComponent(execTask);

        Console.Write("Add logging? (y/n): ");
        if (Console.ReadLine()?.Trim().ToLower() == "y")
            component = new LoggingTaskDecorator(component);

        Console.Write("Add notification? (y/n): ");
        if (Console.ReadLine()?.Trim().ToLower() == "y")
            component = new NotificationTaskDecorator(component);

        Console.Write("Add audit? (y/n): ");
        if (Console.ReadLine()?.Trim().ToLower() == "y")
            component = new AuditTaskDecorator(component);

        Console.Write("Add retry? (y/n): ");
        if (Console.ReadLine()?.Trim().ToLower() == "y")
            component = new RetryTaskDecorator(component);

        Console.WriteLine(stateMsg);

        // Execute the task with all decorators applied
        component.Execute();
    }
    else
    {
        Console.WriteLine("Invalid task number.");
    }
}
