using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace TodoList
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<TaskItem> tasks;
        public ObservableCollection<TaskItem> Tasks
        {
            get { return tasks; }
            set
            {
                tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Tasks = new ObservableCollection<TaskItem>();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            DateTime dueDate = dpDueDate.SelectedDate.HasValue ? dpDueDate.SelectedDate.Value : DateTime.Now;

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description) || !dpDueDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Please fill in all fields.", "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (dueDate.Date < DateTime.Today)
            {
                MessageBox.Show("Please select a future date.", "Invalid Date", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            TaskItem task = new TaskItem { Title = title, Description = description, DueDate = dueDate, Completed = false };
            Tasks.Add(task);
            txtTitle.Text = "Title";
            txtDescription.Text = "Description";
            dpDueDate.SelectedDate = null;
        }

        private void EditTask_Click(object sender, RoutedEventArgs e)
        {
            if (lvTasks.SelectedItem != null)
            {
                TaskItem task = (TaskItem)lvTasks.SelectedItem;
                var editWindow = new EditTaskWindow(task);
                editWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a task to edit.", "No Task Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (lvTasks.SelectedItem != null)
            {
                Tasks.Remove((TaskItem)lvTasks.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select a task to delete.", "No Task Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void MarkAsComplete_Click(object sender, RoutedEventArgs e)
        {
            if (lvTasks.SelectedItem != null)
            {
                TaskItem task = (TaskItem)lvTasks.SelectedItem;
                task.Completed = true;
            }
            else
            {
                MessageBox.Show("Please select a task to mark as complete.", "No Task Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFilter?.SelectedItem == null || Tasks == null) return;

            string filter = (cmbFilter.SelectedItem as ComboBoxItem)?.Content.ToString();
            ICollectionView view = CollectionViewSource.GetDefaultView(Tasks);
            view.Filter = null;

            if (filter == "Completed")
            {
                view.Filter = item => ((TaskItem)item).Completed;
            }
            else if (filter == "Incomplete")
            {
                view.Filter = item => !((TaskItem)item).Completed;
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Title" || tb.Text == "Description") // Checking if it has the placeholder text
            {
                tb.Text = string.Empty;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(tb.Text)) // If nothing was inputted, set back to placeholder
            {
                tb.Text = tb.Name == "txtTitle" ? "Title" : "Description";
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class TaskItem : INotifyPropertyChanged
    {
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private DateTime dueDate;
        public DateTime DueDate
        {
            get { return dueDate; }
            set
            {
                dueDate = value;
                OnPropertyChanged(nameof(DueDate));
            }
        }

        private bool completed;
        public bool Completed
        {
            get { return completed; }
            set
            {
                completed = value;
                OnPropertyChanged(nameof(Completed));
            }
        }

        public bool IsOverdue
        {
            get { return DateTime.Now > DueDate && !Completed; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
