using System;
using System.Windows;

namespace TodoList
{
    public partial class EditTaskWindow : Window
    {
        public TaskItem TaskItem { get; set; }

        public EditTaskWindow(TaskItem taskItem)
        {
            InitializeComponent();
            TaskItem = taskItem;
            txtTitle.Text = TaskItem.Title;
            txtDescription.Text = TaskItem.Description;
            dpDueDate.SelectedDate = TaskItem.DueDate;
        }

        private void UpdateTask_Click(object sender, RoutedEventArgs e)
        {
            string title = txtTitle.Text;
            string description = txtDescription.Text;
            DateTime dueDate = dpDueDate.SelectedDate.HasValue ? dpDueDate.SelectedDate.Value : DateTime.Now;

            if (dueDate.Date < DateTime.Today)
            {
                MessageBox.Show("Please select a future date.", "Invalid Date", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(title))
            {
                TaskItem.Title = title;
                TaskItem.Description = description;
                TaskItem.DueDate = dueDate;
                this.Close();
            }
        }
    }
}
