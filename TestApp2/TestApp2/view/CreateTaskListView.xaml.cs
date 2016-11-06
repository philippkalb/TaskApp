using System;
using System.Collections.ObjectModel;
using TestApp2.infrastructure;
using Xamarin.Forms;

namespace TestApp2
{
    public partial class CreateTaskListView : ContentPage {

        private ObservableCollection<model.TaskList> tasklists;

        public CreateTaskListView(ObservableCollection<model.TaskList> tasklist)
        {
            InitializeComponent();
            tasklists = tasklist;            
        }

    
        public async void OnCreateButtonClicked(object sender, EventArgs e)
        {

            var tasklist = new model.TaskList {
                Name = ListNameEntry.Text
            };
            tasklists.Add(tasklist);

            var database = DependencyService.Get<ISQLite>().GetConnection();
            database.Insert(tasklist);

            await Navigation.PopModalAsync(true);
        }

        public async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }
    }
}
