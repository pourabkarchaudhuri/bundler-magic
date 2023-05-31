using System;
using System.Collections.Generic;

namespace TaskManagementApp
{
    class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }

    class TaskManager
    {
        private List<Task> tasks;

        public TaskManager()
        {
            tasks = new List<Task>();
        }

        public void CreateTask(string title, string description)
        {
            Task task = new Task
            {
                Title = title,
                Description = description,
                IsCompleted = false
            };

            tasks.Add(task);
            Console.WriteLine("Task created successfully.");
        }

        public void UpdateTask(int taskIndex, string title, string description)
        {
            if (taskIndex >= 0 && taskIndex < tasks.Count)
            {
                Task task = tasks[taskIndex];
                task.Title = title;
                task.Description = description;
                Console.WriteLine("Task updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid task index.");
            }
        }

        public void DeleteTask(int taskIndex)
        {
            if (taskIndex >= 0 && taskIndex < tasks.Count)
            {
                tasks.RemoveAt(taskIndex);
                Console.WriteLine("Task deleted successfully.");
            }
            else
            {
                Console.WriteLine("Invalid task index.");
            }
        }

        public void MarkTaskAsCompleted(int taskIndex)
        {
            if (taskIndex >= 0 && taskIndex < tasks.Count)
            {
                Task task = tasks[taskIndex];
                task.IsCompleted = true;
                Console.WriteLine("Task marked as completed.");
            }
            else
            {
                Console.WriteLine("Invalid task index.");
            }
        }

        public void DisplayTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                Task task = tasks[i];
                string status = task.IsCompleted ? "[Completed]" : "[Pending]";
                Console.WriteLine($"Task {i + 1}: {status}");
                Console.WriteLine($"Title: {task.Title}");
                Console.WriteLine($"Description: {task.Description}");
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();

            while (true)
            {
                Console.WriteLine("Task Management Application");
                Console.WriteLine("1. Create Task");
                Console.WriteLine("2. Update Task");
                Console.WriteLine("3. Delete Task");
                Console.WriteLine("4. Mark Task as Completed");
                Console.WriteLine("5. Display Tasks");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter task title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter task description: ");
                        string description = Console.ReadLine();
                        taskManager.CreateTask(title, description);
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.Write("Enter the index of the task to update: ");
                        int updateIndex = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter new task title: ");
                        string newTitle = Console.ReadLine();
                        Console.Write("Enter new task description: ");
                        string newDescription = Console.ReadLine();
                        taskManager.UpdateTask(updateIndex - 1, newTitle, newDescription);
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.Write("Enter the index of the task to delete: ");
                        int deleteIndex = Convert.ToInt32(Console.ReadLine());
                        taskManager.DeleteTask(deleteIndex - 1);
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.Write("Enter the index of the task to mark as completed: ");
                        int completeIndex = Convert.ToInt32(Console.ReadLine());
                        taskManager.MarkTaskAsCompleted(completeIndex - 1);
                        Console.WriteLine();
                        break;
                    case 5:
                        taskManager.DisplayTasks();
                        Console.WriteLine();
                        break;
                    case 6:
                        Console.WriteLine("Exiting the application...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
