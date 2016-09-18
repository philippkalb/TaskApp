using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace TestApp2
{
    public partial class Startpage: ContentPage
    {
        ObservableCollection<ListofTasks> ListOfTasks = new ObservableCollection<ListofTasks>();

        public Startpage() {
            InitializeComponent();
            
            ListOfTasksView.ItemsSource = ListOfTasks;
            ListOfTasks.Add(new ListofTasks { DisplayName = "Wichtig" });
        }

        public async void addNewList(object sender, EventArgs e)
        {
            var createListController = new CreateList(ListOfTasks);
            await Navigation.PushModalAsync(createListController, true);
        }

        public void AddNewList(string listname)
        {
            ListOfTasks.Add(new ListofTasks { DisplayName = listname });
        }


        public async void ItemClicked(object sender, ItemTappedEventArgs e)
        {
            var item = (ListofTasks)e.Item;

            await Navigation.PushAsync(new TaskList(item));
        }
    }
    
    public class ListofTasks {
        public string DisplayName { get; set; }
    }

   


}
