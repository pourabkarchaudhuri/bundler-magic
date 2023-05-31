using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TaskManagementApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class MainForm : Form
    {
        private ListBox lstTasks;
        private TextBox txtTitle;
        private TextBox txtDescription;
        private Button btnCreateTask;
        private Button btnUpdateTask;
        private Button btnDeleteTask;
        private Button btnMarkAsCompleted;
        private List<Task> tasks;

        public MainForm()
        {
            InitializeComponents();
            tasks = new List<Task>();
        }

        private void InitializeComponents()
        {
            lstTasks = new ListBox();
            lstTasks.Location = new Point(10, 10);
            lstTasks.Size = new Size(200, 300);

            txtTitle = new TextBox();
            txtTitle.Location = new Point(220, 10);
            txtTitle.Size = new Size(200, 30);

            txtDescription = new TextBox();
            txtDescription.Location = new Point(220, 50);
            txtDescription.Size = new Size(200, 100);
            txtDescription.Multiline = true;

            btnCreateTask = new Button();
            btnCreateTask.Location = new Point(220, 170);
            btnCreateTask.Size = new Size(200, 30);
            btnCreateTask.Text = "Create Task";
            btnCreateTask.Click += BtnCreateTask_Click;

            btnUpdateTask = new Button();
            btnUpdateTask.Location = new Point(220, 210);
            btnUpdateTask.Size = new Size(200, 30);
            btnUpdateTask.Text = "Update Task";
            btnUpdateTask.Click += BtnUpdateTask_Click;

            btnDeleteTask = new Button();
            btnDeleteTask.Location = new Point(220, 250);
            btnDeleteTask.Size = new Size(200, 30);
            btnDeleteTask.Text = "Delete Task";
            btnDeleteTask.Click += BtnDeleteTask_Click;

            btnMarkAsCompleted = new Button();
            btnMarkAsCompleted.Location = new Point(220, 290);
            btnMarkAsCompleted.Size = new Size(200, 30);
            btnMarkAsCompleted.Text = "Mark as Completed";
            btnMarkAsCompleted.Click += BtnMarkAsCompleted_Click;

            Controls.Add(lstTasks);
            Controls.Add(txtTitle);
            Controls.Add(txtDescription);
            Controls.Add(btnCreateTask);
            Controls.Add(btnUpdateTask);
            Controls.Add(btnDeleteTask);
            Controls.Add(btnMarkAsCompleted);

            Text = "Task Management App";
            Size = new Size(450, 360);
        }

        private void BtnCreateTask_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string description = txtDescription.Text;

            Task task = new Task
            {
                Title = title,
                Description = description,
                IsCompleted = false
            };

            tasks.Add(task);
            DisplayTasks();
            ClearInputs();
        }

        private void BtnUpdateTask_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstTasks.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < tasks.Count)
            {
                Task task = tasks[selectedIndex];
                task.Title = txtTitle.Text;
                task.Description = txtDescription.Text;
                DisplayTasks();
                ClearInputs();
            }
        }

        private void BtnDeleteTask_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstTasks.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < tasks.Count)
            {
                tasks.RemoveAt(selectedIndex);
                DisplayTasks();
                ClearInputs();
            }
        }

        private void BtnMarkAsCompleted_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstTasks.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < tasks.Count)
            {
                Task task = tasks[selectedIndex];
                task.IsCompleted = true;
                DisplayTasks();
                ClearInputs();
            }
        }

        private void DisplayTasks()
        {
            lstTasks.Items.Clear();

            foreach (Task task in tasks)
            {
                string status = task.IsCompleted ? "[Completed]" : "[Pending]";
                string item = $"{status} - {task.Title}: {task.Description}";
                lstTasks.Items.Add(item);
            }
        }

        private void ClearInputs()
        {
            txtTitle.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
    }
}
