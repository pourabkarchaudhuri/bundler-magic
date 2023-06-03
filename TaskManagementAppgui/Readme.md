

# Task Management Application

This is a simple Task Management Application built using C# and .NET Framework. The application allows users to create, update, and delete tasks, as well as mark them as completed.

## Features

- Create tasks with a title and description.
- Update existing tasks with new title and description.
- Delete tasks from the task list.
- Mark tasks as completed.
- Visual theming with customizable colors.

## Getting Started

### Prerequisites

- [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework) - Make sure you have .NET Framework installed on your system.

### Installation

1. Clone the repository:

   ```
   git clone https://github.com/your-username/task-management-app.git
   ```

2. Open the project in Visual Studio Code or any other compatible C# IDE.

3. Build the project to restore the NuGet packages and compile the code.

### Usage

1. Run the application using the IDE's debugging feature or by executing the compiled executable file.

2. The application window will open, allowing you to manage your tasks.

3. To create a new task, enter the title and description in the respective input fields and click the "Create Task" button.

4. To update an existing task, select the task from the task list, update the title and description, and click the "Update Task" button.

5. To delete a task, select the task from the task list and click the "Delete Task" button.

6. To mark a task as completed, select the task from the task list and click the "Mark as Completed" button.

7. The task list will be updated to reflect the changes.

### Customization

You can customize the application's visual theme by modifying the color variables in the code. To change the colors, locate the color customization section in the code and adjust the values of the variables:

```csharp
// Color customization
Color backgroundColor = Color.FromArgb(33, 33, 33);
Color foregroundColor = Color.White;
Color buttonColor = Color.FromArgb(0, 123, 255);
Color buttonHoverColor = Color.FromArgb(0, 86, 179);
```

Feel free to experiment with different color combinations to achieve your desired theme.

---
