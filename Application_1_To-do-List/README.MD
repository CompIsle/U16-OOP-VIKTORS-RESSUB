# To-Do List Application

This To-Do List application is a simple, intuitive tool built in C# with WPF, allowing you to manage tasks efficiently. The application lets you create, edit, delete, and mark tasks as completed, and also provides filtering options to view tasks based on their completion status.


## Installation
To install the application, clone the repository to your local machine, open the solution file in Visual Studio 2022, and run the application.

    git clone https://github.com/[yourusername]/todolist


## Usage

1. **Adding a Task:** To add a new task, enter the task's title and description into the corresponding fields and select a due date using the DatePicker. After entering all details, click the 'Add Task' button to add the task to the list. If successful, the fields will be cleared for the next task.

2. **Editing a Task:** To edit a task, select a task from the list and click 'Edit Task'. A new window will appear with the task details populated in the fields. After making your modifications, click 'Update Task' to save the changes.

3. **Deleting a Task:** To delete a task, select the task from the list and click 'Delete Task'. The selected task will be removed from the list.

4. **Marking a Task as Complete:** To mark a task as completed, select the task from the list and click 'Mark as Complete'. The selected task will be marked as completed, and its color will change to green.

5. **Filtering Tasks:** You can filter the tasks by their completion status. Use the 'Filter' dropdown menu to select one of the following options: 'All', 'Completed', or 'Incomplete'. The task list will update based on the selected filter.


### **Remember to select a task from the list before clicking 'Edit Task', 'Delete Task', or 'Mark as Complete'. If no task is selected, a warning message will appear.**