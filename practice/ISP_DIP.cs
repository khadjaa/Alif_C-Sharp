/*
Выберите знакомый вам программный проект или модуль или, если необходимо, создайте новый и примените 
концепции ISP и DIP для улучшения его дизайна.

1.  Определите интерфейс или класс в вашем проекте, для которого было бы полезно следовать принципу 
разделения интерфейсов (ISP). Рефакторите его, разбив на более мелкие, более конкретные интерфейсы или классы.

2.  Проанализируйте проект на предмет зависимостей между модулями и компонентами. Определите области, 
в которых применение принципа инверсии зависимостей (DIP) может привести к улучшению дизайна программного обеспечения.

3.  Внесите необходимые изменения, чтобы применить DIP, обеспечив зависимость модулей более высокого 
уровня от абстракций, а не от инстанций.
*/

using System;
using System.Collections.Generic;

interface ITask
{
    void GetDetails();
    void Assign(string assignee);
}

interface IBugTask : ITask
{
    void ReproduceIssue();
}

interface IFeatureTask : ITask
{
    void SetPriority(int priority);
}

interface IUserStoryTask : ITask
{
    void BreakDown();
}

class BugTask : IBugTask
{
    public void GetDetails()
    {
        Console.WriteLine("Getting bug task details...");
    }

    public void Assign(string assignee)
    {
        Console.WriteLine($"Assigning bug task to {assignee}...");
    }

    public void ReproduceIssue()
    {
        Console.WriteLine("Reproducing issue for bug task...");
    }
}

class FeatureTask : IFeatureTask
{
    public void GetDetails()
    {
        Console.WriteLine("Getting feature task details...");
    }

    public void Assign(string assignee)
    {
        Console.WriteLine($"Assigning feature task to {assignee}...");
    }

    public void SetPriority(int priority)
    {
        Console.WriteLine($"Setting priority for feature task to {priority}...");
    }
}

class UserStoryTask : IUserStoryTask
{
    public void GetDetails()
    {
        Console.WriteLine("Getting user story task details...");
    }

    public void Assign(string assignee)
    {
        Console.WriteLine($"Assigning user story task to {assignee}...");
    }

    public void BreakDown()
    {
        Console.WriteLine("Breaking down user story task...");
    }
}

class TaskManager
{
    private List<ITask> _tasks;

    public TaskManager(List<ITask> tasks)
    {
        _tasks = tasks;
    }

    public void AssignTask(ITask task, string assignee)
    {
        task.Assign(assignee);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var bugTask = new BugTask();
        var featureTask = new FeatureTask();
        var userStoryTask = new UserStoryTask();

        var tasks = new List<ITask> { bugTask, featureTask, userStoryTask };

        var taskManager = new TaskManager(tasks);

        foreach (var task in tasks)
        {
            task.GetDetails();
            taskManager.AssignTask(task, "John");
            if (task is IBugTask)
            {
                ((IBugTask)task).ReproduceIssue();
            }
            else if (task is IFeatureTask)
            {
                ((IFeatureTask)task).SetPriority(1);
            }
            else if (task is IUserStoryTask)
            {
                ((IUserStoryTask)task).BreakDown();
            }
        }
    }
}