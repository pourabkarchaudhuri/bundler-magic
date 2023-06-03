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
        private Label lblTitle;
        private Label lblDescription;
        private List<Task> tasks;

        public MainForm()
        {
            InitializeComponents();
            tasks = new List<Task>();
        }

        private void InitializeComponents()
        {
            // Color customization
            Color backgroundColor = Color.FromArgb(33, 33, 33);
            Color foregroundColor = Color.White;
            Color buttonColor = Color.FromArgb(0, 123, 255);
            Color buttonHoverColor = Color.FromArgb(0, 86, 179);

            lstTasks = new ListBox();
            lstTasks.Location = new Point(10, 10);
            lstTasks.Size = new Size(400, 200);
            lstTasks.BackColor = backgroundColor;
            lstTasks.ForeColor = foregroundColor;

            lblTitle = new Label();
            lblTitle.Location = new Point(10, 220);
            lblTitle.Size = new Size(100, 30);
            lblTitle.Text = "Task:";
            lblTitle.ForeColor = foregroundColor;

            txtTitle = new TextBox();
            txtTitle.Location = new Point(120, 220);
            txtTitle.Size = new Size(290, 30);
            txtTitle.BackColor = backgroundColor;
            txtTitle.ForeColor = foregroundColor;

            lblDescription = new Label();
            lblDescription.Location = new Point(10, 260);
            lblDescription.Size = new Size(100, 30);
            lblDescription.Text = "Description:";
            lblDescription.ForeColor = foregroundColor;

            txtDescription = new TextBox();
            txtDescription.Location = new Point(120, 260);
            txtDescription.Size = new Size(290, 100);
            txtDescription.Multiline = true;
            txtDescription.BackColor = backgroundColor;
            txtDescription.ForeColor = foregroundColor;

            btnCreateTask = new Button();
            btnCreateTask.Location = new Point(10, 370);
            btnCreateTask.Size = new Size(100, 30);
            btnCreateTask.Text = "Create Task";
            btnCreateTask.BackColor = buttonColor;
            btnCreateTask.ForeColor = foregroundColor;
            btnCreateTask.FlatStyle = FlatStyle.Flat;
            btnCreateTask.FlatAppearance.BorderSize = 0;
            btnCreateTask.FlatAppearance.MouseOverBackColor = buttonHoverColor;
            btnCreateTask.Click += BtnCreateTask_Click;

            btnUpdateTask = new Button();
            btnUpdateTask.Location = new Point(120, 370);
            btnUpdateTask.Size = new Size(100, 30);
            btnUpdateTask.Text = "Update Task";
            btnUpdateTask.BackColor = buttonColor;
            btnUpdateTask.ForeColor = foregroundColor;
            btnUpdateTask.FlatStyle = FlatStyle.Flat;
            btnUpdateTask.FlatAppearance.BorderSize = 0;
            btnUpdateTask.FlatAppearance.MouseOverBackColor = buttonHoverColor;
            btnUpdateTask.Click += BtnUpdateTask_Click;

            btnDeleteTask = new Button();
            btnDeleteTask.Location = new Point(230, 370);
            btnDeleteTask.Size = new Size(100, 30);
            btnDeleteTask.Text = "Delete Task";
            btnDeleteTask.BackColor = buttonColor;
            btnDeleteTask.ForeColor = foregroundColor;
            btnDeleteTask.FlatStyle = FlatStyle.Flat;
            btnDeleteTask.FlatAppearance.BorderSize = 0;
            btnDeleteTask.FlatAppearance.MouseOverBackColor = buttonHoverColor;
            btnDeleteTask.Click += BtnDeleteTask_Click;

            btnMarkAsCompleted = new Button();
            btnMarkAsCompleted.Location = new Point(340, 370);
            btnMarkAsCompleted.Size = new Size(100, 30);
            btnMarkAsCompleted.Text = "Mark as Completed";
            btnMarkAsCompleted.BackColor = buttonColor;
            btnMarkAsCompleted.ForeColor = foregroundColor;
            btnMarkAsCompleted.FlatStyle = FlatStyle.Flat;
            btnMarkAsCompleted.FlatAppearance.BorderSize = 0;
            btnMarkAsCompleted.FlatAppearance.MouseOverBackColor = buttonHoverColor;
            btnMarkAsCompleted.Click += BtnMarkAsCompleted_Click;

            Controls.Add(lstTasks);
            Controls.Add(lblTitle);
            Controls.Add(txtTitle);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(btnCreateTask);
            Controls.Add(btnUpdateTask);
            Controls.Add(btnDeleteTask);
            Controls.Add(btnMarkAsCompleted);

            // Form customization
            BackColor = backgroundColor;
            ForeColor = foregroundColor;
            Text = "Task Management App";
            Size = new Size(460, 420);
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
