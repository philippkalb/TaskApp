using System;
using System.Collections.ObjectModel;
using TestApp2.infrastructure;
using TestApp2.model;
using TestApp2.view.model;
using Xamarin.Forms;

namespace TestApp2
{
    public partial class CreateTaskView : ContentPage {

        private ObservableCollection<TaskViewModel> tasks = new ObservableCollection<TaskViewModel>();
        private TaskListViewModel taskList;

        public CreateTaskView(ObservableCollection<TaskViewModel> tasks, TaskListViewModel taskListId) {
            InitializeComponent();
            this.tasks = tasks;
            taskList = taskListId;

        }

        public async void OnAddButtonClicked(object sender, EventArgs e) {

            var task = new Task {
                Name = ListNameEntry.Text,
                TaskListId = taskList.Id,
                Fulfilled = false
            };
            var database = DependencyService.Get<ISQLite>().GetConnection();
            database.Insert(task);

            tasks.Add(new TaskViewModel {
                Id = task.Id,
                Name = task.Name,
                Count = task.Count,
                TaskListId = task.TaskListId
            });
            MessagingCenter.Send(taskList, "BackToStartPage");

            await Navigation.PopModalAsync(true);
        }

        public async void OnCancelButtonClicked(object sender, EventArgs e) {
            await Navigation.PopModalAsync(true);
        }

    }
}
