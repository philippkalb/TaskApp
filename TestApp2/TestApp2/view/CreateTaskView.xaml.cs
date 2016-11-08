using System;
using System.Collections.ObjectModel;
using TestApp2.infrastructure;
using TestApp2.view.model;
using Xamarin.Forms;

namespace TestApp2
{
    public partial class CreateTaskView : ContentPage {

        private ObservableCollection<TaskViewModel> tasks = new ObservableCollection<TaskViewModel>();
        private long taskListId;

        public CreateTaskView(ObservableCollection<TaskViewModel> tasks, long taskListId) {
            InitializeComponent();
            this.tasks = tasks;
            this.taskListId = taskListId;

        }

        public async void OnAddButtonClicked(object sender, EventArgs e) {

            var task = new model.Task {
                Name = ListNameEntry.Text,
                TaskListId = taskListId,
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

            await Navigation.PopModalAsync(true);
        }

        public async void OnCancelButtonClicked(object sender, EventArgs e) {
            await Navigation.PopModalAsync(true);
        }

    }
}
