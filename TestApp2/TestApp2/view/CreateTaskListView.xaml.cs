using System;
using System.Collections.ObjectModel;
using TestApp2.infrastructure;
using TestApp2.model;
using Xamarin.Forms;

namespace TestApp2
{
    public partial class CreateTaskListView : ContentPage {

        private ObservableCollection<TaskListViewModel> tasklists;

        public CreateTaskListView(ObservableCollection<TaskListViewModel> tasklist)
        {
            InitializeComponent();
            tasklists = tasklist;            
        }

    
        public async void OnCreateButtonClicked(object sender, EventArgs e)
        {
            var tasklist = new TaskList {
                Name = ListNameEntry.Text
            };
            var database = DependencyService.Get<ISQLite>().GetConnection();
            database.Insert(tasklist);

            var model = new TaskListViewModel(tasklist.Id, tasklist.Name, 0);
            tasklists.Add(model);

            await Navigation.PopModalAsync(true);
        }

        public async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }
    }
}
