using System;
using System.Collections.ObjectModel;
using TestApp2.infrastructure;
using Xamarin.Forms;

namespace TestApp2
{
    public partial class TaskListView : ContentPage {

        private ObservableCollection<model.Task> tasks = new ObservableCollection<model.Task>();
        private model.TaskList taskList;

        public TaskListView(model.TaskList item)
        {
            InitializeComponent();

            EmployeeView.ItemsSource = tasks;
            taskList = item;
            loadTasksforList(item.Id);
        }

        public void loadTasksforList(long listId) {

            var database = DependencyService.Get<ISQLite>().GetConnection();
            var tasksQuery = database.Table<model.Task>().Where(x => x.TaskListId == listId);

            foreach(var task in tasksQuery) {
                tasks.Add(task);
            }
        }


        public async void addNewItem(object sender, EventArgs e)
        {
            var createListController = new CreateTaskView(tasks, taskList.Id);
            await Navigation.PushModalAsync(createListController, true);
        }

    }

}
