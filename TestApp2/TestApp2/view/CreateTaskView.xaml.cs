using System;
using System.Collections.ObjectModel;
using TestApp2.infrastructure;
using Xamarin.Forms;

namespace TestApp2
{
    public partial class CreateTaskView : ContentPage {

        private ObservableCollection<model.Task> tasks = new ObservableCollection<model.Task>();
        private long taskListId;

        public CreateTaskView(ObservableCollection<model.Task> tasks, long taskListId) {
            InitializeComponent();
            this.tasks = tasks;
            this.taskListId = taskListId;

        }

        public async void OnAddButtonClicked(object sender, EventArgs e) {
            var task = new model.Task() {
                Name = ListNameEntry.Text,
                TaskListId = taskListId
            };
            tasks.Add(task);

            var database = DependencyService.Get<ISQLite>().GetConnection();
            database.Insert(task);

            await Navigation.PopModalAsync(true);
        }

        public async void OnCancelButtonClicked(object sender, EventArgs e) {
            await Navigation.PopModalAsync(true);
        }

    }
}
