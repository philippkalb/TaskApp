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

            if (ListNameEntry.Text == null || ListNameEntry.Text.Length <= 0) {
                await Navigation.PopModalAsync(true);
                return;
            }
            AddNewTask();
            MessagingCenter.Send(taskList, "BackToStartPage");

            await Navigation.PopModalAsync(true);
        }


        void OnCompleted(object sender, EventArgs e) {
            AddNewTask();
            ListNameEntry.Text = string.Empty;
        }


        private void AddNewTask() {
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
        }


        public async void OnCancelButtonClicked(object sender, EventArgs e) {
            await Navigation.PopModalAsync(true);
        }

    }
}
