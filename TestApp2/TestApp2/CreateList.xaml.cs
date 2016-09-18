using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace TestApp2
{
    public partial class CreateList : ContentPage
    {
        private ObservableCollection<ListofTasks> tasklist;

        public CreateList(ObservableCollection<ListofTasks> tasklist)
        {
            InitializeComponent();
            this.tasklist = tasklist;
            
        }

        public async void OnCreateButtonClicked(object sender, EventArgs e)
        {
            tasklist.Add(new ListofTasks() { DisplayName = ListNameEntry.Text });
            await Navigation.PopModalAsync(true);
        }

        public async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }
    }
}
