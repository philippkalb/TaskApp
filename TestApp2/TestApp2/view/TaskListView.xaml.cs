using System;
using System.Collections.ObjectModel;
using System.Linq;
using TestApp2.infrastructure;
using TestApp2.view.model;
using System.Reflection;
using Xamarin.Forms;

namespace TestApp2
{
    public partial class TaskListView : ContentPage {

        private ObservableCollection<TaskViewModel> tasks = new ObservableCollection<TaskViewModel>();
        private model.TaskList taskList;
        
        public TaskListView(model.TaskList item)
        {
            InitializeComponent();

            var assembly = typeof(TaskListView).GetTypeInfo().Assembly;
            foreach (var res in assembly.GetManifestResourceNames()) {
                System.Diagnostics.Debug.WriteLine("found resource: " + res);
            }
            
            EmployeeView.ItemsSource = tasks;
            taskList = item;
            loadTasksforList(item.Id);
            Title = item.Name;
            
        }

        public void loadTasksforList(long listId) {
            tasks.Clear();
            var database = DependencyService.Get<ISQLite>().GetConnection();
            var tasksQuery = database.Table<model.Task>().Where(x => x.TaskListId == listId);

            foreach(var task in tasksQuery) {
                var model = new TaskViewModel {
                    Id = task.Id,
                    Count = task.Count,
                    Name = task.Name,
                    TaskListId = task.TaskListId
                };
                if (task.Fulfilled) {
                    model.statusImage = "Checked.png";
                } else {
                    model.statusImage = "Unchecked.png";
                }

                tasks.Add(model);
            }
        }

        public void OnTapped(object sender, ItemTappedEventArgs e) {
            var taskModel = (TaskViewModel)e.Item;

            var database = DependencyService.Get<ISQLite>().GetConnection();
            var task = database.Get<model.Task>(y => y.Id == taskModel.Id);
            if (task.Fulfilled) {
                task.Fulfilled = false;
            } else {
                task.Fulfilled = true;
            }
            database.Update(task);
            loadTasksforList(taskList.Id);

        }

        public void OnDelete(object sender, EventArgs e) {
            var mi = ((MenuItem)sender);
            var id = (mi.BindingContext as TaskViewModel).Id;

            var database = DependencyService.Get<ISQLite>().GetConnection();
            database.Delete<model.Task>(id);
            tasks.Remove(tasks.FirstOrDefault(X => X.Id == id));            
        }


        public async void addNewItem(object sender, EventArgs e) {
            var createListController = new CreateTaskView(tasks, taskList.Id);
            await Navigation.PushModalAsync(createListController, true);
        }

    }

}
